namespace WPFUserControls;

public class CaptchaFactory<T> : ICaptchaFactory<T> 
    where T : ICaptcha, new()
{
    public T Create() => new T();
}