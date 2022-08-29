using System;
using Newtonsoft.Json;

namespace Spectrum.Mobile.Models.Response
{
    public class User
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }
}

