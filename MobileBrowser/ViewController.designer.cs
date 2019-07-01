// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace MobileBrowser
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIWebView Browser { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ButtonAddURL { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ButtonClose { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ButtonCreateFolder { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ButtonInsets { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ButtonLoad { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ButtonMenu { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ButtonReturnOnStart { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView TableView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView TableViewOpenPage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField TextBoxURL { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (Browser != null) {
                Browser.Dispose ();
                Browser = null;
            }

            if (ButtonAddURL != null) {
                ButtonAddURL.Dispose ();
                ButtonAddURL = null;
            }

            if (ButtonClose != null) {
                ButtonClose.Dispose ();
                ButtonClose = null;
            }

            if (ButtonCreateFolder != null) {
                ButtonCreateFolder.Dispose ();
                ButtonCreateFolder = null;
            }

            if (ButtonInsets != null) {
                ButtonInsets.Dispose ();
                ButtonInsets = null;
            }

            if (ButtonLoad != null) {
                ButtonLoad.Dispose ();
                ButtonLoad = null;
            }

            if (ButtonMenu != null) {
                ButtonMenu.Dispose ();
                ButtonMenu = null;
            }

            if (ButtonReturnOnStart != null) {
                ButtonReturnOnStart.Dispose ();
                ButtonReturnOnStart = null;
            }

            if (TableView != null) {
                TableView.Dispose ();
                TableView = null;
            }

            if (TableViewOpenPage != null) {
                TableViewOpenPage.Dispose ();
                TableViewOpenPage = null;
            }

            if (TextBoxURL != null) {
                TextBoxURL.Dispose ();
                TextBoxURL = null;
            }
        }
    }
}