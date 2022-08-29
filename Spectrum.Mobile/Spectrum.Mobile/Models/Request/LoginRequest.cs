﻿using System;
using Newtonsoft.Json;

namespace Spectrum.Mobile.Models.Request
{
    public class LoginRequest
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}

