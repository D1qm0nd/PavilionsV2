using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Interfaces;
using WPFUserControls.Enums;
using WPFUserControls.Handlers;

namespace WPFUserControls.UserControls;

[TypeConverter(typeof(Convert))]
public partial class LoginUserControl : UserControl, INotifyPropertyChanged
{
    #region Properties & Fields

    public event PasswordHandler? PasswordChanged;

    private Brush _foreground { get; set; } = Brushes.Black;

    public Brush ForeGround
    {
        get => _foreground;
    }

    public bool LockCondition { get; set; } = false;

    private IUserData hasLogin;

    public IUserData HasLogin
    {
        get => hasLogin;
        set
        {
            hasLogin = value;
            OnPropertyChanged(nameof(HasLogin));
        }
    }

    public Func<string, bool> EmailValidate { get; set; }
    public Func<string, bool> LoginValidate { get; set; }
    public Func<string, bool> PasswordValidate { get; set; }
    public Func<string, bool> SurnameValidate { get; set; }
    public Func<string, bool> NameValidate { get; set; }
    public Func<string, bool> MiddlenameValidate { get; set; }
    public Func<string, bool> PhoneValidate { get; set; }

    private LoginCondition Condition = LoginCondition.Register;

    /// <summary>
    /// Hidden elements tags
    /// </summary>
    private int[] hideOnRegister = { -1 };

    public int[] HideOnRegister
    {
        get => hideOnRegister;
        set
        {
            hideOnRegister = value;
            Update();
        }
    }

    private int[] hideOnLogin = { -1 };

    public int[] HideOnLogin
    {
        get => hideOnLogin;
        set
        {
            hideOnLogin = value;
            Update();
        }
    }

    public Action<LoginData> MakeRegister { get; set; }

    public Func<LoginData, IUserData> MakeLogin { get; set; }

    public string GetEmail
    {
        get => Email.Text;
    }

    public string Getlogin
    {
        get => Login.Text;
    }

    public string GetPassword
    {
        get => Password.Password;
    }

    public string GetSurname
    {
        get => Surname.Text;
    }

    public string GetName
    {
        get => Name.Text;
    }

    public string GetPhone
    {
        get => PhoneNumber.Text;
    }

    public string GetMiddlename
    {
        get => Middlename.Text;
    }

    public BitmapImage? GetImage
    {
        get => ImageHandler.GetImage(Convert.ToBase64String(UserImage.Buffer));
    }

    #endregion

    public uint MaxLoginAttempts { get; set; }
    
    private uint login_attempts = 0;

    public ICaptchaFactory<ICaptcha> CaptchaFactory;
    
    public LoginUserControl()
    {
        InitializeComponent();
        UserImage.SetImageToBuffer(ImageHandler.GetBytesFromBase64(WPFUserControls.Resources.Resource.ProfileImage));
    }

    #region Methods

    public void Update()
    {
        switch (Condition)
        {
            case LoginCondition.Login:
                OnLogin();
                break;
            case LoginCondition.Register:
                OnRegister();
                break;
        }
    }

    public void SetBackground(BitmapImage image)
    {
        ControlBorder.Background = new ImageBrush() { ImageSource = image };
    }
    
    public void SetBackground(Brush background)
    {
        ControlBorder.Background = background;
    }

    public void SetForeGroundColor(Brush foreground)
    {
        _foreground = foreground;
    }

    public void Validate(params int[] hidden) //params??
    {
        var res = true;
        if (!hidden.Contains(int.Parse(Email.Tag.ToString())))
            res &= EmailValidate?.Invoke(Email.Text) ?? true;
        if (res == false) throw new ValidationException("Электронная почта обязана быть корректной");
        if (!hidden.Contains(int.Parse(Login.Tag.ToString())))
            res &= LoginValidate?.Invoke(Login.Text) ?? true;
        if (res == false) throw new ValidationException("Логин не прошел проверку");
        if (!hidden.Contains(int.Parse(Password.Tag.ToString())))
            res &= PasswordValidate?.Invoke(Password.Password) ?? true;
        if (res == false) throw new ValidationException("Пароль не прошел проверку");
        if (!hidden.Contains(int.Parse(Surname.Tag.ToString())))
            res &= SurnameValidate?.Invoke(Surname.Text) ?? true;
        if (res == false) throw new ValidationException("Фамилия не прошла проверку");
        if (!hidden.Contains(int.Parse(Name.Tag.ToString())))
            res &= NameValidate?.Invoke(Name.Text) ?? true;
        if (res == false) throw new ValidationException("Имя не прошло проверку");
        if (!hidden.Contains(int.Parse(Middlename.Tag.ToString())))
            res &= MiddlenameValidate?.Invoke(Middlename.Text) ?? true;
        if (res == false) throw new ValidationException("Отчество не прошло проверку");
        if (!hidden.Contains(int.Parse(PhoneNumber.Tag.ToString())))
            res &= PhoneValidate?.Invoke(PhoneNumber.Text) ?? true;
        if (res == false) throw new ValidationException("Номер телефона не прошел проверку");
        if (!hidden.Contains(int.Parse(UserImage.Tag.ToString())))
            res &= UserImage.Buffer != null;
        if (res == false) throw new ValidationException("Фото не было загружено");
    }

    public void ChangeCondition() => ChangeCondition(null, null);

    public void SetFunctionalButtonVisibility(Visibility visibility) => FunctionalButton.Visibility = visibility;

    protected void ChangeCondition(object sender, RoutedEventArgs routedEventArgs)
    {
        if (LockCondition == false)
        {
            switch (Condition)
            {
                case LoginCondition.Login:
                {
                    Condition = LoginCondition.Register;
                    OnRegister();
                    break;
                }
                case LoginCondition.Register:
                {
                    Condition = LoginCondition.Login;
                    OnLogin();
                    break;
                }
            }
        }
    }

    public void ChangeVisibility(Grid grid, Visibility visibility, params int[] tags)
    {
        foreach (var x in tags)
        {
            foreach (Grid child in grid.Children)
            {
                if (child.Tag == null) continue;
                if (int.Parse(child.Tag.ToString()) == x) child.Visibility = visibility;
            }
        }
    }

    public void HideElements(params int[] hiddentags)
    {
        ChangeVisibility(ConditionGrid, Visibility.Collapsed, hiddentags);
    }

    private void UpdateHints()
    {
        switch (Condition)
        {
            case LoginCondition.Login:
                FunctionalButton.Content = "Регистрация";
                ActionButton.Content = "Вход";
                break;
            case LoginCondition.Register:
                FunctionalButton.Content  = "Вход в систему";
                ActionButton.Content = "Регистрация";
                break;
        }
    }
    
    protected void OnLogin()
    {
        ChangeVisibility(ConditionGrid, Visibility.Visible, new int[] { 1, 2, 3, 4, 5, 6, 7 });
        HideElements(HideOnLogin);

#if DEBUG
        this.Email.Text = "Elizor@gmail.com";
        this.Login.Text = "Elizor";
        this.Password.Password = "ynt1RS#3";
#endif

        UpdateHints();
    }


    protected void OnRegister()
    {
        ChangeVisibility(ConditionGrid, Visibility.Visible, new int[] { 0, 1, 2, 3, 4, 5, 6, 7 });
        HideElements(HideOnRegister);
        UpdateHints();
    }

    public override string ToString()
    {
        return "{ " +
               $"\"Email\":\"{Email.Text}\", " +
               $"\"Login\":\"{Login.Text}\", " +
               $"\"Password\":\"{Password.Password}\", " +
               $"\"Surname\":\"{Surname.Text}\", " +
               $"\"Name\":\"{Name.Text}\", " +
               $"\"Middlename\":\"{Middlename.Text}\", " +
               $"\"UserImage\":\"{UserImage.Buffer}\", " +
               "}";
    }

    public LoginData GetData()
    {
        var data = new LoginData(
            Email.Text,
            Login.Text,
            Password.Password,
            Surname.Text,
            Name.Text,
            Middlename.Text,
            PhoneNumber.Text,
            UserImage.Buffer);
        return data;
    }

    private void DoAction(object sender, RoutedEventArgs e)
    {
        switch (Condition)
        {
            case LoginCondition.Login:
            {
                try
                {
                    Validate(HideOnLogin);
                    HasLogin = MakeLogin?.Invoke(GetData());
                }
                catch (Exception ex)
                {
                    login_attempts += 1;
                    MessageBox.Show(ex.Message);
                    if (login_attempts > MaxLoginAttempts)
                    {
                        CaptchaFactory.Create()?.InputCaptcha();
                        login_attempts = 0;
                    }
                }

                break;
            }
            case LoginCondition.Register:
            {
                var res = false;
                try
                {
                    Validate(HideOnRegister);
                    MakeRegister?.Invoke(GetData());
                    res = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (res == true) ChangeCondition(null, null);
                }

                break;
            }
        }
    }

    #endregion

    #region AfterLoginActions

    /// <summary>
    /// Add your delegates here, which will be activated after logging in
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        if (hasLogin != null)
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion

    private void Password_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
    {
        PasswordChanged?.Invoke(Password.Password);
    }
}