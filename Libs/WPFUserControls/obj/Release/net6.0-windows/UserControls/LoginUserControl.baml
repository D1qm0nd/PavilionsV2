   M S B A M L   `   `   `  ���� J  FWPFUserControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:WPFUserControls.ContextsWPFUserControls.Contexts  K*clr-namespace:WPFUserControls.UserControlsWPFUserControls.UserControls  3    -WPFUserControls.UserControls.LoginUserControl   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aEmaterialdesig1http://materialdesigninxaml.net/winfx/xaml/themes  5contexts&clr-namespace:WPFUserControls.Contexts  =userControls*clr-namespace:WPFUserControls.UserControls  -     >�Name$  Control��$��40��$	��485��$	��300��
������  � 	Resources  �� MergedDictionaries �� Source��  �� $e _pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml?��� $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml?��� $z tpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.DeepPurple.xaml?��� $s mpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Lime.xaml?�%     � DataContext 0   *WPFUserControls.Contexts.NotAllowedSymbols  .���� -    ��Name$ ControlBorder�� �� CornerRadius$ 30��
��� ���
�������$��2q�._��� $��
20 20 0 20q�.��� -    �Name$ ConditionGrid�� � RowDefinitions �� $��40 ��� $��40 ��� $��40 ��� $��40 ��� $��40 ��� $��40 ��� $��40 ��� $��80 ��� $��40 ��� $��40 �.+�� $��0��
	 � Tag$	 0��.+��� -   
 ��Name$
 Email��$��5q�$	 0��.  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush
 �����$��15(� �� 	MaxLength$ 64��!   CharacterCounterVisibility$ 	Collapsed=�)  #MaterialDesignThemes.Wpf.HintAssist   Hint$' !Электронная почта������ *email_+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�   
Foreground �� *
ForeGround+���� *
ForeGround+.��� $��1��$	 1��.+��� -   $
 Login��$��5q�$	 1��
 �����$��15(�$ 80��$ 	Collapsed=�$ 
Логин������ *login_+$ PropertyChanged=�$ TwoWay=� �� *
ForeGround+���� *
ForeGround+.��� $��2��$	 2��.+�G� -    G�Name$ Password��$��5q�$	 2��
 �����$��15(� G� 	MaxLength$ 80��$ Пароль�� �� *
ForeGround+���� *
ForeGround+� $��3��$	 3��.+��� -   $
 Surname��$��5q�$	 3��
 �����$��15(�$ 80��$ 	Collapsed=�$ Фамилия������ *
surname_+$ PropertyChanged=�$ TwoWay=� �� *
ForeGround+���� *
ForeGround+.��� $��4��$	 4��.+��� -   $

 Name��$��5q�$	 4��
 �����$��15(�$ 80��$ 	Collapsed=�$ Имя�� �� *
ForeGround+���� *
ForeGround+.��� $��5��$	 5��.+��� -	   $
 
Middlename��$��5q�$	 5��
 �����$��15(�$ 80��$ 	Collapsed=�$ Отчество������ *middlename_+$ PropertyChanged=�$ TwoWay=� �� *
ForeGround+���� *
ForeGround+.��� $��6��$	 6��.+��� -
   $
 PhoneNumber��$��5q�$	 6��
 �����$��15(�$ 11��$ 	Collapsed=�$! Номер телефона������ *phonenumber_+$ PropertyChanged=�$ TwoWay=� �� *
ForeGround+���� *
ForeGround+.��� $��7��$	 7��.+�� $��10q� � ColumnDefinitions �� $��50 ��� $��* �.+�.   (WPFUserControls.UserControls.ImagePicker  -     Name$ 	UserImage��$��0��$	 7��$ 50��$��50��$��50��$
��Left=��� -    ��Name$ PictureText��$��1��$��Center=�$��Center=�$
��Wrap=� �� TextAlignment$ Justify=�$��Arial)�$��20(����� *
ForeGround+1/Изображение пользователя� $��8��.+��� -    ��Name$ FunctionalButton��$��	10 0 10 0q�
�������
����������� *
ForeGround+� $��9��.+��� -   $ ActionButton��$��	10 0 10 0q�
�������
����������� *
ForeGround+