using System.Text.Json;
using PavilionsData.Exceptions;

namespace PavilionsData;

public static class DataWorker
{
    public static List<T>? LoadJsonFromFile<T>(string path)
    {
        List<T>? result;
        using (StreamReader r = new StreamReader(path))
        {
            string json = r.ReadToEnd();

            var document = JsonDocument.Parse(json);

            result = document.Deserialize<List<T>>();
        }

        return result;
    }

    public static void UploadJsonToFile<T>(IEnumerable<T> source, string path)
    {
        if (path.Length == 0)
            throw new FileNameException();
        if (!path.Contains(".json")) path += ".json";
        var json = JsonSerializer.SerializeToDocument(source);
        var text = json.RootElement.GetRawText();
        using (StreamWriter sw = File.CreateText(path))
        {
            sw.Write(text);
            sw.Close();
        }
    }

    public static List<T>? LoadJson<T>(string json)
    {
        var document = JsonDocument.Parse(json);
        try
        {
            var res = document?.Deserialize<List<T>>();
            return res;
        }
        catch (Exception e)
        {
            Console.WriteLine(e + json);
            throw;
        }
    }
}