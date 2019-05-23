using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AppKit;
using CoreGraphics;
using CoreImage;
using Foundation;
using MainMovieManager.Classes;
using MainMovieManager.Database_Models;
using Newtonsoft.Json;

namespace MainMovieManager
{
    public partial class SecondController : NSViewController
    {
        public static Signin sign = new Signin();

        public SecondController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();


            // Do any additional setup after loading the view.
        }

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }
        partial void loginclick(Foundation.NSObject sender)
        {
            using (WebClient wc = new WebClient())
            {
                string url = "http://localhost:5000/api/users/";
                string json = wc.DownloadString(url);

                List<User_Model> data = JsonConvert.DeserializeObject<List<User_Model>>(json);
                sign.Check_Username_Password(UsernameTextField.StringValue, PasswordTextField.StringValue, data);
                UsernameLabel.StringValue = sign.check_username(UsernameTextField.StringValue);
                PasswordLabel.StringValue = sign.check_password(PasswordTextField.StringValue);

                if (sign.CheckAll == true)
                {
                   View.Window.Close();
                }
            }
        }
        partial void GoBack(Foundation.NSObject sender)
        {
            View.Window.Close();
        }
    }
}
