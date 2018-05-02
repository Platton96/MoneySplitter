namespace MoneySplitter.Services
{
    public static class Defines
    {
        public static class Executor
        {
            public const int EXECUTION_ATTEMPTS_COUNT = 3;
        }
        public static class ServerMassage
        {
            public const string BAD_RESPONCE = "Bad server's response";
        }
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

            public static class Friends
            {
                public const string FRIENDS = "/friends";
                public const string ADD_FRIEND = "/add";
                public const string ALL_FRIENDS= "/all";
                public const string REMOVE_FRIEND = "/remove";
            }
        }
    }
}
