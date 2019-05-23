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
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        AppKit.NSButton AccountButton { get; set; }

        [Outlet]
        AppKit.NSTextField DetailsLabel { get; set; }

        [Outlet]
        AppKit.NSTextField EmailLabel { get; set; }

        [Outlet]
        AppKit.NSTextField EmailTextField { get; set; }

        [Outlet]
        AppKit.NSTextField FirstnameLabel { get; set; }

        [Outlet]
        AppKit.NSTextField FirstnameTextField { get; set; }

        [Outlet]
        AppKit.NSTextField LastnameLabel { get; set; }

        [Outlet]
        AppKit.NSTextField LastnameTextField { get; set; }

        [Outlet]
        AppKit.NSView MainView { get; set; }

        [Outlet]
        AppKit.NSTextField MovieDescription { get; set; }

        [Outlet]
        AppKit.NSButton MovieImageButton { get; set; }

        [Outlet]
        AppKit.NSTextField MovieTitle { get; set; }

        [Outlet]
        AppKit.NSSecureTextField Password2TextField { get; set; }

        [Outlet]
        AppKit.NSTextField PasswordLabel { get; set; }

        [Outlet]
        AppKit.NSSecureTextField PasswordTextField { get; set; }

        [Outlet]
        AppKit.NSSearchField SearchBar { get; set; }

        [Outlet]
        AppKit.NSTextField SigninLabel { get; set; }

        [Outlet]
        AppKit.NSButton UpdateButton { get; set; }

        [Outlet]
        AppKit.NSTextField UpdateLabel { get; set; }

        [Outlet]
        AppKit.NSButton WishlistButton { get; set; }

        [Outlet]
        AppKit.NSTextField WishlistLabel { get; set; }

        [Action ("DisplayMovieDescription:")]
        partial void DisplayMovieDescription (Foundation.NSObject sender);

        [Action ("FindMovie:")]
        partial void FindMovie (Foundation.NSObject sender);

        [Action ("GetMovie:")]
        partial void GetMovie (Foundation.NSObject sender);

        [Action ("GetMovieImage:")]
        partial void GetMovieImage (Foundation.NSObject sender);

        [Action ("LoadSignin:")]
        partial void LoadSignin (Foundation.NSObject sender);

        [Action ("MovieToWishlist:")]
        partial void MovieToWishlist (Foundation.NSObject sender);

        [Action ("SearchWishList:")]
        partial void SearchWishList (Foundation.NSObject sender);

        [Action ("UpdateUser:")]
        partial void UpdateUser (Foundation.NSObject sender);
        
        void ReleaseDesignerOutlets ()
        {
            if (WishlistLabel != null) {
                WishlistLabel.Dispose ();
                WishlistLabel = null;
            }

            if (AccountButton != null) {
                AccountButton.Dispose ();
                AccountButton = null;
            }

            if (DetailsLabel != null) {
                DetailsLabel.Dispose ();
                DetailsLabel = null;
            }

            if (EmailLabel != null) {
                EmailLabel.Dispose ();
                EmailLabel = null;
            }

            if (EmailTextField != null) {
                EmailTextField.Dispose ();
                EmailTextField = null;
            }

            if (FirstnameLabel != null) {
                FirstnameLabel.Dispose ();
                FirstnameLabel = null;
            }

            if (FirstnameTextField != null) {
                FirstnameTextField.Dispose ();
                FirstnameTextField = null;
            }

            if (LastnameLabel != null) {
                LastnameLabel.Dispose ();
                LastnameLabel = null;
            }

            if (LastnameTextField != null) {
                LastnameTextField.Dispose ();
                LastnameTextField = null;
            }

            if (MainView != null) {
                MainView.Dispose ();
                MainView = null;
            }

            if (MovieDescription != null) {
                MovieDescription.Dispose ();
                MovieDescription = null;
            }

            if (MovieImageButton != null) {
                MovieImageButton.Dispose ();
                MovieImageButton = null;
            }

            if (MovieTitle != null) {
                MovieTitle.Dispose ();
                MovieTitle = null;
            }

            if (Password2TextField != null) {
                Password2TextField.Dispose ();
                Password2TextField = null;
            }

            if (PasswordLabel != null) {
                PasswordLabel.Dispose ();
                PasswordLabel = null;
            }

            if (PasswordTextField != null) {
                PasswordTextField.Dispose ();
                PasswordTextField = null;
            }

            if (SearchBar != null) {
                SearchBar.Dispose ();
                SearchBar = null;
            }

            if (SigninLabel != null) {
                SigninLabel.Dispose ();
                SigninLabel = null;
            }

            if (UpdateButton != null) {
                UpdateButton.Dispose ();
                UpdateButton = null;
            }

            if (UpdateLabel != null) {
                UpdateLabel.Dispose ();
                UpdateLabel = null;
            }

            if (WishlistButton != null) {
                WishlistButton.Dispose ();
                WishlistButton = null;
            }
        }
    }
}
