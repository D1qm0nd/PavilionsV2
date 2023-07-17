namespace WPFUserControls;

public interface ICaptchaFactory<out T> where T: ICaptcha
{
    public T Create();
}