﻿#pragma checksum "C:\Users\ocgrb\OneDrive\New Backup\SocketIO\SocketIO\Layouts\TestLayout\BloomTest.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0F3AC1F54925104B6D30A5C776AFCA95"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SocketIO.Layouts
{
    partial class BloomTest : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Layouts\TestLayout\BloomTest.xaml line 12
                {
                    this.UICanvas = (global::Windows.UI.Xaml.Controls.Grid)(target);
                    ((global::Windows.UI.Xaml.Controls.Grid)this.UICanvas).SizeChanged += this.UICanvas_SizeChanged;
                }
                break;
            case 3: // Layouts\TestLayout\BloomTest.xaml line 14
                {
                    this.hostForVisual = (global::Windows.UI.Xaml.Shapes.Rectangle)(target);
                }
                break;
            case 4: // Layouts\TestLayout\BloomTest.xaml line 21
                {
                    this.rootPivot = (global::Windows.UI.Xaml.Controls.Pivot)(target);
                }
                break;
            case 5: // Layouts\TestLayout\BloomTest.xaml line 53
                {
                    this.Comment = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.Comment).Click += this.Header_Click;
                }
                break;
            case 6: // Layouts\TestLayout\BloomTest.xaml line 47
                {
                    this.Download = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.Download).Click += this.Header_Click;
                }
                break;
            case 7: // Layouts\TestLayout\BloomTest.xaml line 41
                {
                    this.ContactInfo = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.ContactInfo).Click += this.Header_Click;
                }
                break;
            case 8: // Layouts\TestLayout\BloomTest.xaml line 33
                {
                    this.Pictures = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.Pictures).Click += this.Header_Click;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}
