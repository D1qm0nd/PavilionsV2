﻿#pragma checksum "..\..\..\..\Windows\Pavilions.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "EB0283B66644D8BCC6A088F8CC96FE97A9E38687"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using PavilionsApplication;
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


namespace PavilionsApplication {
    
    
    /// <summary>
    /// Pavilions
    /// </summary>
    public partial class Pavilions : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\..\Windows\Pavilions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal PavilionsApplication.UIControls.ShopCenterPavilionsList PavilionsList;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Windows\Pavilions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal PavilionsApplication.UIControls.AddPavilionUserControl AddPavilionUC;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\Windows\Pavilions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal PavilionsApplication.UIControls.PavilionRental RentalUC;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Windows\Pavilions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal PavilionsApplication.UIControls.ChangeShoppingCenterPhotoUserControl PhotoChanger;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Windows\Pavilions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal PavilionsApplication.UIControls.ChangeShoppingCenterStatusUserControl StatusChanger;
        
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
            System.Uri resourceLocater = new System.Uri("/PavilionsApplication;component/windows/pavilions.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\Pavilions.xaml"
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
            this.PavilionsList = ((PavilionsApplication.UIControls.ShopCenterPavilionsList)(target));
            return;
            case 2:
            this.AddPavilionUC = ((PavilionsApplication.UIControls.AddPavilionUserControl)(target));
            return;
            case 3:
            this.RentalUC = ((PavilionsApplication.UIControls.PavilionRental)(target));
            return;
            case 4:
            this.PhotoChanger = ((PavilionsApplication.UIControls.ChangeShoppingCenterPhotoUserControl)(target));
            return;
            case 5:
            this.StatusChanger = ((PavilionsApplication.UIControls.ChangeShoppingCenterStatusUserControl)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

