﻿#pragma checksum "C:\Users\ocgrb\OneDrive\New Backup\SocketIO\SocketIO\Layouts\TestLayout\Test.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "731B9D7F0D1A85C12F1AACCC6A1A1D49"
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
    partial class Test : 
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
            case 2: // Layouts\TestLayout\Test.xaml line 17
                {
                    this.MainPanel = (global::Windows.UI.Xaml.Controls.Grid)(target);
                    ((global::Windows.UI.Xaml.Controls.Grid)this.MainPanel).SizeChanged += this.MainPanel_SizeChanged;
                    ((global::Windows.UI.Xaml.Controls.Grid)this.MainPanel).Tapped += this.MainPanel_Tapped;
                }
                break;
            case 3: // Layouts\TestLayout\Test.xaml line 35
                {
                    global::Windows.UI.Xaml.Controls.Button element3 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element3).PointerEntered += this.Button_PointerEntered;
                    ((global::Windows.UI.Xaml.Controls.Button)element3).PointerExited += this.Button_PointerExited;
                }
                break;
            case 4: // Layouts\TestLayout\Test.xaml line 36
                {
                    this.EntranceStackPanel = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 5: // Layouts\TestLayout\Test.xaml line 58
                {
                    this.ChoiceA = (global::Windows.UI.Xaml.Controls.CheckBox)(target);
                }
                break;
            case 6: // Layouts\TestLayout\Test.xaml line 20
                {
                    this.ImageTile = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 7: // Layouts\TestLayout\Test.xaml line 22
                {
                    this.CaptionTile = (global::Windows.UI.Xaml.Controls.Border)(target);
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
