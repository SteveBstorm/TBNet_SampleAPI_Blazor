﻿namespace SampleAPI_Blazor.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public string UserName { get; set; }
    }
}
