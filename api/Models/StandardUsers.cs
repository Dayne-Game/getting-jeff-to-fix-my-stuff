using System;
using System.Collections.Generic;

namespace api.Models {
    public class StandardUsers : IStandardUsers {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Passwrd { get; set; }
        public string Email { get; set; }
        public string Uname { get; set; }
    }
}