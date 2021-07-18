using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Models
{
    public class AppUser
    {
        public AppUser()
        {
            this.Photos = new HashSet<Photo>();

        }
        public int ID { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; }
        public Gender Gender { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastTimeActive { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string Introduction { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public ICollection<Photo> Photos { get; set; }

        public string KnownAs { get; set; }
    }
    public enum Gender
    {
        Male,
        Female
    }
}
