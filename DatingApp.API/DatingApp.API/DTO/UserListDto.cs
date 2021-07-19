using DatingApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.DTO
{
    public class UserListDto
    {

       
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; }
        public Gender Gender { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastTimeActive { get; set; }

        public int Age { get; set; }
        public string Introduction { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhotoUrl { get; set; }

        public string KnownAs { get; set; }
        public ICollection<PhotoDetailsDto> Photos { get; set; }
    }
}
