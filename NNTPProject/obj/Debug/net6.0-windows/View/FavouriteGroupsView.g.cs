﻿#pragma checksum "..\..\..\..\View\FavouriteGroupsView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "87AB7D82F98C2F83073C8AA9B782394B1A2674AB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using NNTPProject.View;
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


namespace NNTPProject.View {
    
    
    /// <summary>
    /// FavouriteGroupsView
    /// </summary>
    public partial class FavouriteGroupsView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\..\View\FavouriteGroupsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox GroupSearchField;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\View\FavouriteGroupsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SearchGroupsButton;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\View\FavouriteGroupsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView AllGroupsListView;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\View\FavouriteGroupsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView FavouriteGroupsListView;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\View\FavouriteGroupsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RefreshAllGroupsButton;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\View\FavouriteGroupsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteFavouriteGroupButton;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\View\FavouriteGroupsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SelectGroup;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\View\FavouriteGroupsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ViewArticlesButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.9.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/NNTPProject;component/view/favouritegroupsview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\FavouriteGroupsView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.9.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.GroupSearchField = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.SearchGroupsButton = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\..\View\FavouriteGroupsView.xaml"
            this.SearchGroupsButton.Click += new System.Windows.RoutedEventHandler(this.SearchGroupsButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.AllGroupsListView = ((System.Windows.Controls.ListView)(target));
            
            #line 23 "..\..\..\..\View\FavouriteGroupsView.xaml"
            this.AllGroupsListView.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.AllGroupsListView_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.FavouriteGroupsListView = ((System.Windows.Controls.ListView)(target));
            
            #line 30 "..\..\..\..\View\FavouriteGroupsView.xaml"
            this.FavouriteGroupsListView.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.FavouriteGroupsListView_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.RefreshAllGroupsButton = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\..\View\FavouriteGroupsView.xaml"
            this.RefreshAllGroupsButton.Click += new System.Windows.RoutedEventHandler(this.RefreshAllGroupsButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.DeleteFavouriteGroupButton = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\..\View\FavouriteGroupsView.xaml"
            this.DeleteFavouriteGroupButton.Click += new System.Windows.RoutedEventHandler(this.DeleteFavouriteGroupButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.SelectGroup = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.ViewArticlesButton = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

