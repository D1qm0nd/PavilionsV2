﻿#pragma checksum "..\..\..\..\UIControls\ShoppingCentersList.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "167353DE668F00098B5366B1D286A67FB7439DA0"
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
using WPFUserControls.UserControls;


namespace PavilionsApplication.UIControls {
    
    
    /// <summary>
    /// ShoppingCentersList
    /// </summary>
    public partial class ShoppingCentersList : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 29 "..\..\..\..\UIControls\ShoppingCentersList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CitiesComboBox;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\UIControls\ShoppingCentersList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox StatusesComboBox;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\UIControls\ShoppingCentersList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ShopCentersList;
        
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
            System.Uri resourceLocater = new System.Uri("/PavilionsApplication;component/uicontrols/shoppingcenterslist.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UIControls\ShoppingCentersList.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.CitiesComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 29 "..\..\..\..\UIControls\ShoppingCentersList.xaml"
            this.CitiesComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CitiesComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.StatusesComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 30 "..\..\..\..\UIControls\ShoppingCentersList.xaml"
            this.StatusesComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.StatusesComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ShopCentersList = ((System.Windows.Controls.ListView)(target));
            
            #line 34 "..\..\..\..\UIControls\ShoppingCentersList.xaml"
            this.ShopCentersList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ShopCentersList_OnSelectionChanged);
            
            #line default
            #line hidden
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
            case 4:
            
            #line 39 "..\..\..\..\UIControls\ShoppingCentersList.xaml"
            ((WPFUserControls.UserControls.ImagePicker)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Picture_OnLoaded);
            
            #line default
            #line hidden
            break;
            case 5:
            
            #line 44 "..\..\..\..\UIControls\ShoppingCentersList.xaml"
            ((System.Windows.Controls.Label)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Status_OnLoaded);
            
            #line default
            #line hidden
            break;
            case 6:
            
            #line 49 "..\..\..\..\UIControls\ShoppingCentersList.xaml"
            ((System.Windows.Controls.Label)(target)).Loaded += new System.Windows.RoutedEventHandler(this.PavilionsCount_OnLoaded);
            
            #line default
            #line hidden
            break;
            case 7:
            
            #line 53 "..\..\..\..\UIControls\ShoppingCentersList.xaml"
            ((System.Windows.Controls.Label)(target)).Loaded += new System.Windows.RoutedEventHandler(this.City_OnLoaded);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

