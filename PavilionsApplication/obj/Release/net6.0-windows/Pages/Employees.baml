   M S B A M L   `   `   `  ���� O  KPavilionsApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:PavilionsApplication.PagesPavilionsApplication.Pages  J FWPFUserControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulldCclr-namespace:WPFUserControls.UserControls;assembly=WPFUserControlsWPFUserControls.UserControls *    $PavilionsApplication.Pages.Employees   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     :local(clr-namespace:PavilionsApplication.Pages     _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  VuserControlsCclr-namespace:WPFUserControls.UserControls;assembly=WPFUserControls    N� Title$  	Employees��$��40�� � 	Resources  �� MergedDictionaries �� Source��  �� $e _pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml?��� $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml?��� $z tpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.DeepPurple.xaml?��� $s mpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Lime.xaml?�%    .���  � RowDefinitions �� $��40 ��� $��* �.+�� $��0��$	��Top=�$
��Left=�.+��  � ColumnDefinitions �� $	��100 ��� $��80 ��� $	��300���� $	��300��.+��� -    ��Name$ SearchTextBox��$��0��$	��100��
�������
���   �)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Поиск��$��1q�$	��Top=�$��0 8 0 0q��� -   $ 	IdTextBox��$��1��
�������
���   �$ Код��$��1q�$	��Top=�$��0 8 0 0q�� $��2��.+��� -    ��Name$ ChangePasswordButton��$	��Top=�$��40��
��� ���$��1 1 0 0q�.��Сменить пароль�� -   $ ChangePasswordTextBox��
�������
���   �$	��140��$ Новый пароль��$��1q�$	��Top=�$��0 8 0 0q�$y�	Collapsed=�� $��3��.+��� -   $ ChangeRoleButton��$	��Top=�$��40��
��� ���$��1 1 0 0q�.��Сменить роль�� -   	 ��Name$	 ChangeRoleComboBox��
�������
���   �$	��140��$ Роли��$��1q�$	��Top=�$��0 8 0 0q�$y�	Collapsed=��� $��1��.���� .+�&   System.Windows.Controls.DataGrid  -   
  Name$
 EmployeesDataGrid��   AutoGenerateColumns$ False��   CanUserAddRows$ False��   CanUserDeleteRows$ False��   CanUserReorderColumns$ False��   Columns 0  *System.Windows.Controls.DataGridTextColumn  -   ID��,  &System.Windows.Controls.DataGridColumn   Header$ ID��   
IsReadOnly$
 True��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Id_Employee+  -	   	Login��$ Login��$
 True�� �� *Login+  -
   Password��$ Password��$
 True��   
Visibility$ 	Collapsed=� �� *
Password+  -   Surname��$ Surname��$
 True�� �� *	Surname+  -   Name��$
 Name��$
 True�� �� *Name+  -   
Middlename��$ 
Middlename��$
 True�� �� *
Middlename+4  .System.Windows.Controls.DataGridTemplateColumn  -   Role��$
 Role��   CellTemplate �� .R��� -   $��28�� �� CornerRadius$ 10��$	��Top=�$��0 -3 0 0q�
 � Tag �� *	Id_Role+._��� $��Center=�$��Medium"�
�������  -   
Gender��$ Gender��$
 True�� �� *Gender+  -   	Photo��$ Photo��   MinWidth$	 100Q� �� .R�� .+�.  (WPFUserControls.UserControls.ImagePicker    Name$ 	UserImage��-   $	��120��$	��100��$ 5��$��Center=� �� *Photo+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�