﻿namespace MoneySplitter.Services.Api
{
    public static class Defines
    {
        public static class Api
        {
            public const string WEB_API_URL = "http://moneytransfer.azurewebsites.net";
            public static class Session
            {
                public const string SESSION = "/session";
                public const string SIGN_IN = "/signin";
                public const string REGISTER = "/register";
            }
            public static class Users
            {
                public const string USERS = "/users";
                public const string SEARCH = "/search";
                public const string SEARCH_PARAMETR = "?query=";
            }
        }
    }
}
