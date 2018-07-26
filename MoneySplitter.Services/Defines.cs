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
            public const string APPLICATION_JASON = "application/json";
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
                public const string SEARCH_PARAMETR = "query";
            }

            public static class Friends
            {
                public const string FRIENDS = "/friends";
                public const string ADD_FRIEND = "/add";
                public const string ALL_FRIENDS = "/all";
                public const string REMOVE_FRIEND = "/remove";
                public const string FRIEND_ID = "friendId";
            }

            public static class Transactions
            {
                public const string TRANSACTIONS = "/transactions";
                public const string ALL = "/all";
                public const string ADD = "/add";
                public const string MY = "/my";
                public const string COLLABORATE = "/collaborate";
                public const string APPROVEALL = "/approveall";
                public const string APPROVE = "/approve";
                public const string BY_USER_ID = "byUserId";
                public const string FRIEND_ID = "friendId";

                public static class Parameters
                {
                    public const string ID = "id";
                    public const string TRANSACTION_ID = "transactionId";
                    public const string USER_ID = "userId";
                }

            }

            public static class HeaderNames
            {
                public const string USER_NAME = "X-USERNAME";
                public const string TOKEN = "X-TOKEN";
            }
        }
    }
}
