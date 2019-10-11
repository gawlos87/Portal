using System;

namespace Portal.Api.Dtos
{
    public class UserFotListDto
    {
        public int Id { get; set; }
        public string Username { get; set; }

        //Info
        public string Gender { get; set; }
        public int Age { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhotoUrl { get; set; }
    }
}