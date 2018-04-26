namespace MoneySplitter.Win10
{
    public static class Defines
    {
        public static class Title
        {
            public const string HOME = "Home";
            public const string FRIENDS = "Friends";
            public const string SEARCH = "Search";
        }

        public static class IconButton
        {
            public const string HOME = "&#xE80F;";
            public const string FRIENDS = "&#xE716;";
            public const string SEARCH = "&#xE721;";
        }

        public static class ImageExtension
        {
            public const string JPEG = ".jpeg";
            public const string JPG = ".jpg";
            public const string PNG = ".png";
        }

        public static class Issue
        {
            public static class Login
            {
                public const string ISSUE_TITLE = "Unable to log in.";
                public const string ISSUE_MESSAGE = "Please check that you have entered your login and password";
            }
            public static class Register
            {
                public const string ISSUE_TITLE = "Unable to Register";
                public const string ISSUE_MESSAGE = "You have problem whith register";
                public const string ISSUE_PASSWORD = "Confirmpassword isn't some password";
            }
        }
        public static class Search
        {
            public const string TEXTBOX_EMPTY = "Enter, please query for search!";
            public const string NOT_RESULTS = "Not results!";
            public const string PROBLEM_SERVER = "Sory, problems with server!";
        }
    }
}
