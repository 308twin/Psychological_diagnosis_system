﻿#pragma checksum "..\..\..\UserControls\DictrictControl.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "19E40462AB7F48FE8660DA346B63D7A09CC84123B7613D52AF53664D3AA8B914"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
using WpfApplication1.UserControls;


namespace WpfApplication1.UserControls {
    
    
    /// <summary>
    /// DictrictControl
    /// </summary>
    public partial class DictrictControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\UserControls\DictrictControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox com_province;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\UserControls\DictrictControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox com_city;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\UserControls\DictrictControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox com_county;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\UserControls\DictrictControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox address;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfApplication1;component/usercontrols/dictrictcontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControls\DictrictControl.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\..\UserControls\DictrictControl.xaml"
            ((WpfApplication1.UserControls.DictrictControl)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded_1);
            
            #line default
            #line hidden
            return;
            case 2:
            this.com_province = ((System.Windows.Controls.ComboBox)(target));
            
            #line 22 "..\..\..\UserControls\DictrictControl.xaml"
            this.com_province.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.com_province_SelectionChanged_1);
            
            #line default
            #line hidden
            return;
            case 3:
            this.com_city = ((System.Windows.Controls.ComboBox)(target));
            
            #line 29 "..\..\..\UserControls\DictrictControl.xaml"
            this.com_city.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.com_city_SelectionChanged_1);
            
            #line default
            #line hidden
            return;
            case 4:
            this.com_county = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.address = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

