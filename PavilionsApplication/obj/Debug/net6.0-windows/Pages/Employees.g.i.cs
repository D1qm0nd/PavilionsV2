﻿#pragma checksum "..\..\..\..\Pages\Employees.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "08F52D00143D7640C121FF0FFE93A5B8B3DC275B"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using PavilionsApplication.Pages;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using WPFUserControls.UserControls;


namespace PavilionsApplication.Pages {
    
    
    /// <summary>
    /// Employees
    /// </summary>
    public partial class Employees : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 38 "..\..\..\..\Pages\Employees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchTextBox;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\Pages\Employees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox IdTextBox;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\Pages\Employees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ChangePasswordButton;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\Pages\Employees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ChangePasswordTextBox;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\Pages\Employees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ChangeRoleButton;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\Pages\Employees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ChangeRoleComboBox;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\Pages\Employees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid EmployeesDataGrid;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\..\Pages\Employees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn ID;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\..\Pages\Employees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn Login;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\..\Pages\Employees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn Password;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\..\Pages\Employees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn Surname;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\..\Pages\Employees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn Name;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\..\Pages\Employees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn Middlename;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\..\Pages\Employees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTemplateColumn Role;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\..\Pages\Employees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn Gender;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\..\..\Pages\Employees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTemplateColumn Photo;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/PavilionsApplication;V1.0.0.0;component/pages/employees.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\Employees.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.SearchTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 38 "..\..\..\..\Pages\Employees.xaml"
            this.SearchTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SearchTextBox_OnTextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.IdTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.ChangePasswordButton = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\..\..\Pages\Employees.xaml"
            this.ChangePasswordButton.Click += new System.Windows.RoutedEventHandler(this.ChangePasswordTextBox_OnClick);
            
            #line default
            #line hidden
            
            #line 46 "..\..\..\..\Pages\Employees.xaml"
            this.ChangePasswordButton.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.ChangePasswordButton_OnMouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ChangePasswordTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.ChangeRoleButton = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\..\..\Pages\Employees.xaml"
            this.ChangeRoleButton.Click += new System.Windows.RoutedEventHandler(this.ChangeRole_OnClick);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ChangeRoleComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 61 "..\..\..\..\Pages\Employees.xaml"
            this.ChangeRoleComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ChangeRoleComboBox_OnSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.EmployeesDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 71 "..\..\..\..\Pages\Employees.xaml"
            this.EmployeesDataGrid.CurrentCellChanged += new System.EventHandler<System.EventArgs>(this.EmployeesDataGrid_OnCurrentCellChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.ID = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 9:
            this.Login = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 10:
            this.Password = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 11:
            this.Surname = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 12:
            this.Name = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 13:
            this.Middlename = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 14:
            this.Role = ((System.Windows.Controls.DataGridTemplateColumn)(target));
            return;
            case 16:
            this.Gender = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 17:
            this.Photo = ((System.Windows.Controls.DataGridTemplateColumn)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 15:
            
            #line 91 "..\..\..\..\Pages\Employees.xaml"
            ((System.Windows.Controls.Border)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Border_Loaded);
            
            #line default
            #line hidden
            break;
            case 18:
            
            #line 107 "..\..\..\..\Pages\Employees.xaml"
            ((WPFUserControls.UserControls.ImagePicker)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserImage_OnLoaded);
            
            #line default
            #line hidden
            
            #line 108 "..\..\..\..\Pages\Employees.xaml"
            ((WPFUserControls.UserControls.ImagePicker)(target)).PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.UserImage_OnPropertyChanged);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

