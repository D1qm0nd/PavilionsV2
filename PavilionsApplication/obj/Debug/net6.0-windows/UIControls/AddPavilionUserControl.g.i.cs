﻿#pragma checksum "..\..\..\..\UIControls\AddPavilionUserControl.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2990EE27D771FC11B229297CFC917B689B651509"
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
using PavilionsApplication.UIControls;
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


namespace PavilionsApplication.UIControls {
    
    
    /// <summary>
    /// AddPavilionUserControl
    /// </summary>
    public partial class AddPavilionUserControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\..\UIControls\AddPavilionUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel Panel;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\UIControls\AddPavilionUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Number;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\UIControls\AddPavilionUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Floor;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\UIControls\AddPavilionUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Area;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\UIControls\AddPavilionUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Price;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\UIControls\AddPavilionUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AVC;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\UIControls\AddPavilionUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddButton;
        
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
            System.Uri resourceLocater = new System.Uri("/PavilionsApplication;component/uicontrols/addpavilionusercontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UIControls\AddPavilionUserControl.xaml"
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
            this.Panel = ((System.Windows.Controls.WrapPanel)(target));
            return;
            case 2:
            this.Number = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.Floor = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Area = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.Price = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.AVC = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.AddButton = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\..\UIControls\AddPavilionUserControl.xaml"
            this.AddButton.Click += new System.Windows.RoutedEventHandler(this.AddButton_OnClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

