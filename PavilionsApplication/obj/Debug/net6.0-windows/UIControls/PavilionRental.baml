   M S B A M L   `   `   `  ����  PavilionsApplication4    .PavilionsApplication.UIControls.PavilionRental   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      
������ $	��350��5	      $	��170��6     � 	Resources  5
       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $e _pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml?�5      �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml?�5      �� 5      $z tpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.DeepPurple.xaml?�5      �� 5      $s mpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Lime.xaml?�5      %    5      .��5      �� -   5         ��Name$
 brdr��5       �� CornerRadius$ 15��6   
�������
������$��1q�6Y   ._�5   
   �� $��10q�6   .+�5      �� .+�5      �� -   5         ��Name$ PavilionsList��5      
���   �$��1q�6F   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Номер��5      $��0 0 0 1q�6B   6S   �� 5      -   5        $ StatusesList��5      
���   �$��1q�6E   $ Статус��5       $��0 0 0 1q�6C   �� 5!      -   5        $ TenantsList��5!      
���   �$��1q�6D   $ Арендатор��5#      $y�	Collapsed=�6F   �� 5$      -   5         ��Name$ KindOfActivity��5$      $% Вид деятельности��62   $y�	Collapsed=�6d   �� 5%      -   5         ��Name$ ServicePanel��5%      $y�	Collapsed=�63   .+�5&      �� -   5        $ ServiceNameTextBox��5&      $��28��6:   6I   �� 5'      -   5        	 ��Name$	 ServiceAddButton��5'      .��6V   Добавить услугу6g   �� 5(      -	   5        $ ServiceList��5(      $ Список услуг��64   
 �� 
IsEditable$
 False��6b   5)      �� 5*      -
   5        $ Licence��5*      $! ~Выручка за мес��6+   $y�	Collapsed=�6]   �� 5+      -   5        $ Organization��5+      $* $~Количество клиетов��60   $y�	Collapsed=�6f   (  "System.Windows.Controls.DatePicker  5,      -   5          Name$ StartDatePicker��5,      
���   �$��1q�6J   $ Дата начала��5-      $y�	Collapsed=�6K     5.      -   5        $ EndDatePicker��5.      
���   �$��1q�6H   $ Дата оконч.��5/      $y�	Collapsed=�6J   50      �� 51      -   5        $	��150��51      $��
 0 10 0 10q�6!   .��6P   Изменить статус6a   52      53      54      