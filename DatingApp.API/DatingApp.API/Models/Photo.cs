using System;

namespace DatingApp.API.Models
{
    public class Photo
    {
        public int ID { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime AddedTime { get; set; }
        public bool IsMain { get; set; }
        public AppUser ApplicationUser { get; set; }
    }

}

