﻿#pragma checksum "..\..\..\Windows\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "029A02EB5A9138C7C6D5852CC8E2C4FA70B20D8F"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using TETRIS;


namespace TETRIS {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 44 "..\..\..\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas GameCanvas;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ScoreText;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image HoldImage;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRestart;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image NextImage;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GameOverMenu;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock FinalScoreText;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel MenuPanel;
        
        #line default
        #line hidden
        
        
        #line 123 "..\..\..\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnStartGame;
        
        #line default
        #line hidden
        
        
        #line 129 "..\..\..\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnHighScores;
        
        #line default
        #line hidden
        
        
        #line 135 "..\..\..\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAbout;
        
        #line default
        #line hidden
        
        
        #line 141 "..\..\..\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSound;
        
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
            System.Uri resourceLocater = new System.Uri("/TETRIS;component/windows/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\MainWindow.xaml"
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
            
            #line 12 "..\..\..\Windows\MainWindow.xaml"
            ((TETRIS.MainWindow)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.Window_KeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.GameCanvas = ((System.Windows.Controls.Canvas)(target));
            
            #line 49 "..\..\..\Windows\MainWindow.xaml"
            this.GameCanvas.Loaded += new System.Windows.RoutedEventHandler(this.GameCanvas_Loaded);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ScoreText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.HoldImage = ((System.Windows.Controls.Image)(target));
            return;
            case 5:
            this.btnRestart = ((System.Windows.Controls.Button)(target));
            
            #line 68 "..\..\..\Windows\MainWindow.xaml"
            this.btnRestart.Click += new System.Windows.RoutedEventHandler(this.PlayAgain_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.NextImage = ((System.Windows.Controls.Image)(target));
            return;
            case 7:
            this.GameOverMenu = ((System.Windows.Controls.Grid)(target));
            return;
            case 8:
            this.FinalScoreText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            
            #line 106 "..\..\..\Windows\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PlayAgain_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.MenuPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 11:
            this.btnStartGame = ((System.Windows.Controls.Button)(target));
            
            #line 128 "..\..\..\Windows\MainWindow.xaml"
            this.btnStartGame.Click += new System.Windows.RoutedEventHandler(this.StartGame_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.btnHighScores = ((System.Windows.Controls.Button)(target));
            
            #line 134 "..\..\..\Windows\MainWindow.xaml"
            this.btnHighScores.Click += new System.Windows.RoutedEventHandler(this.HighScores_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.btnAbout = ((System.Windows.Controls.Button)(target));
            
            #line 140 "..\..\..\Windows\MainWindow.xaml"
            this.btnAbout.Click += new System.Windows.RoutedEventHandler(this.About_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.btnSound = ((System.Windows.Controls.Button)(target));
            
            #line 145 "..\..\..\Windows\MainWindow.xaml"
            this.btnSound.Click += new System.Windows.RoutedEventHandler(this.ToggleSound_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

