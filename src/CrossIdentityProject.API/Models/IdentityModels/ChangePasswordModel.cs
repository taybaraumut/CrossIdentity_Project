﻿namespace CrossIdentityProject.API.Models.IdentityModels
{
    public class ChangePasswordModel
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
