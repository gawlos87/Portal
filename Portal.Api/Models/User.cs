using System;
using System.Collections.Generic;

namespace Portal.Api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username {get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        //Podstawowe informacje
        public string Gender {get; set;}
        public DateTime DateOfBirth { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        //Zakładka info
        public string Growth { get; set; }  
        public string EyeColor { get; set; }
        public string HairColor { get; set; }
        public string MartialStatus { get; set; }
        public string Education { get; set; }   
        public string Profession { get; set; }
        public string Children  { get; set; }
        public string Languages { get; set; }

        //Zakładka o mnie

        public string Motto { get; set; }
        public string Description { get; set; }
        public string Personality { get; set; }
        public string LookinFor { get; set; }

        //Zakładka, pasje, zainteresowania
        public string Interests { get; set; }
        public string FreeTime { get; set; }
        public string  Sport { get; set; }
        public string Movies { get; set; }
        public string Music { get; set; }

        //Prefenecje
        public string ILike { get; set; }
        public string IDoNotLike { get; set; }
        public string MakesMeLaugh { get; set; }
        public string ItFeelsBestIn { get; set; }
        public string FriendWouldDectiptionMe { get; set;}

        //Zdjecia
        public ICollection<Photo> Photos { get; set; }

    }
}