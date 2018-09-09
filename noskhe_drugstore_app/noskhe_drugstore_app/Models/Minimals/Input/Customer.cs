using System;

namespace noskhe_drugstore_app.Models.Minimals.Input
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string ProfilePictureUrl { get; set; }
    }
}