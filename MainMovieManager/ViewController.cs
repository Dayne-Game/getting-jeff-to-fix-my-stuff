using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public partial class ViewController : NSViewController
    {
        static Movies m1 = new Movies();
        static Person p1 = new Person();
        static Wishlist w1 = new Wishlist();

        public ViewController(IntPtr handle) : base(handle)
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
        partial void GetMovie(Foundation.NSObject sender)
        {
            using (WebClient wc = new WebClient())
            {
                string url = "http://localhost:5000/api/movies/";
                string json = wc.DownloadString(url);
                List<Movie_Model> data = JsonConvert.DeserializeObject<List<Movie_Model>>(json);
                MovieTitle.StringValue = m1.SearchMovies(SearchBar.StringValue, data);
                AssignMovieImageToButton(MovieImageButton, m1);
                CheckDescription(MovieDescription);

            }
        }
        public void AssignMovieImageToButton(NSButton imagebtn, Movies m1)
        {
            if (m1.CheckMovieImage())
            {
                imagebtn.Hidden = false;
                NSString imageURL = new NSString(m1.MovieImageUrl);
                NSUrl NSURLImageURL = new NSUrl(imageURL);
                NSImage image = new NSImage(NSURLImageURL);
                imagebtn.Image = image;
            }
            else
                imagebtn.Hidden = true;
        }


        partial void DisplayMovieDescription(Foundation.NSObject sender)
        {
            MovieDescription.StringValue = m1.DisplayMovieDescription();
        }


        partial void UpdateUser(Foundation.NSObject sender)
        {
            Validate v1 = new Validate();
            string fname = FirstnameTextField.StringValue;
            string lname = LastnameTextField.StringValue;
            string password1 = PasswordTextField.StringValue;
            string password2 = Password2TextField.StringValue;
            string email = EmailTextField.StringValue;

            p1.PersonIndex = SecondController.sign.GetPerson; // Assign PersonIndex with index of Person from Signin form
            UpdateLabel.StringValue = p1.GetPerson();

            FirstnameLabel.StringValue = v1.CheckField(fname);
            LastnameLabel.StringValue = v1.CheckField(lname);
            EmailLabel.StringValue = v1.CheckField(email);
            PasswordLabel.StringValue = v1.CheckPasswords(password1, password2);

            if (v1.Counter == 4 && p1.GotPerson == true)
                UpdateLabel.StringValue = p1.UpdatePerson(fname, lname, password2, email);

            WishlistLabel.StringValue = w1.DisplayWishlist();
        }

        partial void MovieToWishlist(Foundation.NSObject sender)
        {
            WishlistLabel.StringValue = " ";
            w1.PID = SecondController.sign.GetPerson;
            w1.MID = m1.GetMovieID;
            w1.DeserilizeWishlistData();
            WishlistLabel.StringValue = w1.Check_MID_isnot_in_List(w1);
        }

        partial void SearchWishList(Foundation.NSObject sender)
        {
            WishlistLabel.StringValue = "";
            w1.PID = SecondController.sign.GetPerson;
            WishlistLabel.StringValue = w1.DisplayWishlist();
        }

        partial void DeleteMovie(Foundation.NSObject sender)
        {
            NotifiDeleteLabel.StringValue = w1.Remove_Movie_From_Wishlist(MovieInputTextField.StringValue);
            WishlistLabel.StringValue = w1.DisplayWishlist();
        }


        public void CheckDescription(NSTextField input)
        {
            if (m1.isDescription == true)
                input.Hidden = false;
            else
            {
                input.StringValue = "Click on the Movie to read the Description, Genre and Rating!";
                input.Hidden = true;
            }

        }
    }
}
