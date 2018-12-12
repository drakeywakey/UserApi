using System;
using System.Collections.Generic;

namespace UserApi.Models
{
    public class User
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Interests { get; set; }
        public int Age { get; set; }
        public string ImageSrc { get; set; }
    }
}
