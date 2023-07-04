namespace SingleTonLib
{
    public class Singleton<T> where T : class, new()
    {
        private Singleton() { }

        private static T? _instance;
        public static T Instance 
        {
            get => _instance == null ? _instance = new T() : _instance;
            private set => _instance = value;
        }
    }
}