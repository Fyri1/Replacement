﻿#pragma checksum "..\..\..\..\Views\CreateReplacementModifierView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E88064C1FFB1C80CCA7097613E606BB2831A1269"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using DataEditor.Views;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace DataEditor.Views {
    
    
    /// <summary>
    /// CreateReplacementModifierView
    /// </summary>
    public partial class CreateReplacementModifierView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\..\Views\CreateReplacementModifierView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlockDescription;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\Views\CreateReplacementModifierView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextboxFirstElement;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Views\CreateReplacementModifierView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextboxFirstElementСhange;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\Views\CreateReplacementModifierView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListViewReplacements;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\Views\CreateReplacementModifierView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddReplacementButton;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\Views\CreateReplacementModifierView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CreateButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.7.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/DataEditor;component/views/createreplacementmodifierview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\CreateReplacementModifierView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.7.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.TextBlockDescription = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.TextboxFirstElement = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.TextboxFirstElementСhange = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.ListViewReplacements = ((System.Windows.Controls.ListBox)(target));
            return;
            case 5:
            this.AddReplacementButton = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\..\Views\CreateReplacementModifierView.xaml"
            this.AddReplacementButton.Click += new System.Windows.RoutedEventHandler(this.AddReplacementButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.CreateButton = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\..\Views\CreateReplacementModifierView.xaml"
            this.CreateButton.Click += new System.Windows.RoutedEventHandler(this.CreateButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

