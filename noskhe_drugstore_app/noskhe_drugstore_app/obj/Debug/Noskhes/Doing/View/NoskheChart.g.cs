﻿#pragma checksum "..\..\..\..\..\Noskhes\Doing\View\NoskheChart.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "AD82D0FCB2AB3401F3927C554421A3FA6AEC4376"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
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
using noskhe_drugstore_app.Noskhes.Doing.View;


namespace noskhe_drugstore_app.Noskhes.Doing.View {
    
    
    /// <summary>
    /// NoskheChart
    /// </summary>
    public partial class NoskheChart : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\..\..\Noskhes\Doing\View\NoskheChart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel ImageItem;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\..\Noskhes\Doing\View\NoskheChart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock RowNumber;
        
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
            System.Uri resourceLocater = new System.Uri("/noskhe_drugstore_app;component/noskhes/doing/view/noskhechart.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Noskhes\Doing\View\NoskheChart.xaml"
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
            
            #line 17 "..\..\..\..\..\Noskhes\Doing\View\NoskheChart.xaml"
            ((System.Windows.Controls.ListViewItem)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Details_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ImageItem = ((System.Windows.Controls.StackPanel)(target));
            
            #line 21 "..\..\..\..\..\Noskhes\Doing\View\NoskheChart.xaml"
            this.ImageItem.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.ImageItem_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 3:
            this.RowNumber = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

