#pragma checksum "..\..\..\View\PlayPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "60784056DD13E764073BD8660625353D942291DA07F7C9F1DDF2E49AAD5A2D54"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Blackjack.View;
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


namespace Blackjack.View {
    
    
    /// <summary>
    /// PlayPage
    /// </summary>
    public partial class PlayPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\View\PlayPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid DealerGrid;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\View\PlayPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView LvDealerHiddenCards;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\View\PlayPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ActionsGrid;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\View\PlayPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnHit;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\View\PlayPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnStand;
        
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
            System.Uri resourceLocater = new System.Uri("/Blackjack;component/view/playpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\PlayPage.xaml"
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
            this.DealerGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.LvDealerHiddenCards = ((System.Windows.Controls.ListView)(target));
            return;
            case 3:
            this.ActionsGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.BtnHit = ((System.Windows.Controls.Button)(target));
            
            #line 87 "..\..\..\View\PlayPage.xaml"
            this.BtnHit.Click += new System.Windows.RoutedEventHandler(this.BtnHit_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.BtnStand = ((System.Windows.Controls.Button)(target));
            
            #line 90 "..\..\..\View\PlayPage.xaml"
            this.BtnStand.Click += new System.Windows.RoutedEventHandler(this.BtnStand_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

