using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

namespace DatingApp.API.Models
{
    public class Seed
    {
        public  static void  UserSeeder(ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                var userData = File.ReadAllText("MoqData/generated.json");
                var users = JsonConvert.DeserializeObject<List<MoqUsers>>(userData);

                foreach (var item in users)
                {
                  
                    AppUser user = new AppUser();
                    user.City = item.City;
                    user.Country = item.Country;
                    user.Created = DateTime.Parse(item.Created);
                    user.DateOfBirth = DateTime.Parse(item.DateOfBirth);
                    user.Email = item.Email;
                    user.Gender = (Gender)item.Gender;
                    user.Introduction = item.Introduction;
                    user.IsDeleted = false;
                    user.LastTimeActive = DateTime.Parse(item.LastTimeActive);
                    user.Phone = item.Phone;
                    user.UserName = item.UserName;
                    CreatePasswordHash(ref user, item.Password);
                    foreach (var photo in item.Photos)
                    {
                        user.Photos.Add(new Photo()
                        {
                            Url = photo.Url,
                            AddedTime = DateTime.Now,
                            Description = photo.Description,
                            IsMain = true
                        });


                    }
                    context.Users.Add(user);





                }
                context.SaveChanges();
            }
        }

        private static void CreatePasswordHash(ref AppUser user, string password)
        {
            using (var hMACSHA = new HMACSHA512())
            {
                user.PasswordHash = hMACSHA.ComputeHash(UTF8Encoding.Unicode.GetBytes(password));
                user.PasswordSalt = hMACSHA.Key;


            }



        }

        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        private class MoqPhoto
        {
            [JsonProperty("url")]
            public string Url { get; set; }

            [JsonProperty("isMain")]
            public bool IsMain { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }
        }

        private class MoqUsers
        {
            public MoqUsers()
            {
                this.Photos = new List<MoqPhoto>();
            }
            [JsonProperty("userName")]
            public string UserName { get; set; }

            [JsonProperty("password")]
            public string Password { get; set; }

            [JsonProperty("phone")]
            public string Phone { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("isDeleted")]
            public bool IsDeleted { get; set; }

            [JsonProperty("gender")]
            public int Gender { get; set; }

            [JsonProperty("created")]
            public string Created { get; set; }

            [JsonProperty("lastTimeActive")]
            public string LastTimeActive { get; set; }

            [JsonProperty("dateOfBirth")]
            public string DateOfBirth { get; set; }

            [JsonProperty("introduction")]
            public string Introduction { get; set; }

            [JsonProperty("city")]
            public string City { get; set; }

            [JsonProperty("country")]
            public string Country { get; set; }

            [JsonProperty("photos")]
            public List<MoqPhoto> Photos { get; set; }

            [JsonProperty("knownAs")]
            public string KnownAs { get; set; }
        }


    }
}
