﻿namespace HR_management.Application.Models.Auth
{
    public class AuthenticatedResponse
    {
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
    }
}
