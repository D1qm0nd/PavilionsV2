using System;
using System.IO;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WPFUserControls.Handlers;

public static class ImageHandler
{
    public static byte[]? GetImageBytes(string imagePath)
    {
        try
        {
            FileStream fs = File.OpenRead(imagePath);
            byte[] data = new byte[fs.Length];
            fs.Read(data, 0, data.Length);
            return data;
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public static byte[] GetBytesFromBase64(string base64)
    {
        return Convert.FromBase64String(base64);
    }

    public static MemoryStream GetImageSource(string base64String)
    {
        byte[] imageBytes = GetBytesFromBase64(base64String);
        MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
        return ms;
    }

    public static BitmapImage GetImage(string base64)
    {
        BitmapImage image = new BitmapImage();
        image.BeginInit();
        image.StreamSource = GetImageSource(base64);
        image.EndInit();
        return image;
    }

    public static byte[]? BitmapImageToBytes(BitmapImage? image)
    {
        if (image == null) return null;
        try
        {
            byte[] bytes = new byte[1024];
            image.StreamSource.Read(bytes, 0, bytes.Length);
            SaveImage(bytes);
            return bytes;
        }
        catch
        {
            return null;
        }
    }

    public static BitmapImage? BytesToBitmapImage(byte[] bytes)
    {
        using (var stream = new MemoryStream(bytes))
        {
            var image = new BitmapImage();

            image.BeginInit();
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.StreamSource = stream;
            image.EndInit();

            return image;
        }
    }

    private static void SaveImage(byte[] bytes)
    {
        var a = @"C:\\Users\\Max\\Desktop\\";
        using (var fs = File.OpenWrite(a + "TestImageHandler.jpg"))
        {
            var res = fs.BeginWrite(bytes, 0, bytes.Length, null, null);
            fs.EndWrite(res);
            fs.Close();
        }
    }

    public static string? BitmapImageToBase64(BitmapImage image)
    {
        var bytes = BitmapImageToBytes(image);
        if (bytes == null) return null;
        try
        {
            return Convert.ToBase64String(bytes);
        }
        catch
        {
            return null;
        }
    }
}