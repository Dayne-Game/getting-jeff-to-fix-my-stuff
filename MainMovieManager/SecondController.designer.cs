// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace MainMovieManager
{
    [Register ("SecondController")]
    partial class SecondController
    {
        [Outlet]
        AppKit.NSTextField PasswordLabel { get; set; }

        [Outlet]
        AppKit.NSSecureTextField PasswordTextField { get; set; }

        [Outlet]
        AppKit.NSButton SigninButton { get; set; }

        [Outlet]
        AppKit.NSTextField UsernameLabel { get; set; }

        [Outlet]
        AppKit.NSTextField UsernameTextField { get; set; }

        [Action ("GoBack:")]
        partial void GoBack (Foundation.NSObject sender);

        [Action ("loginclick:")]
        partial void loginclick (Foundation.NSObject sender);
        
        void ReleaseDesignerOutlets ()
        {
            if (UsernameLabel != null) {
                UsernameLabel.Dispose ();
                UsernameLabel = null;
            }

            if (UsernameTextField != null) {
                UsernameTextField.Dispose ();
                UsernameTextField = null;
            }

            if (PasswordLabel != null) {
                PasswordLabel.Dispose ();
                PasswordLabel = null;
            }

            if (PasswordTextField != null) {
                PasswordTextField.Dispose ();
                PasswordTextField = null;
            }

            if (SigninButton != null) {
                SigninButton.Dispose ();
                SigninButton = null;
            }
        }
    }
}
