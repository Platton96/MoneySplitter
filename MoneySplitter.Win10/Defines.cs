namespace MoneySplitter.Win10
{
    public static class Defines
    {
        public static class Collaborator
        {
            public static class ButtonContent
            {
                public const string GIVE = "Give!";
                public const string APPROVE = "Approve";
                public const string REMIND = "Remind";
                public const string GLYPH_RINGER = "&#xEA8F;";
            }

            public const int COUNT_NUMBER_AFTER_POINT = 2;
        }

        public static class Arrow
        {
            public static class Glyph
            {
                public const string UP = "&#xF0AD;";
                public const string DOWN = "&#xF0AE;";
            }

        }
        public static class MenuItem
        {
            public static class Title
            {
                public const string HOME = "Home";
                public const string FRIENDS = "Friends";
                public const string SEARCH = "Search";
                public const string TRANSACTIONS = "Transactions";
                public const string INCOMING_AND_OUTCOMING = "Incoming and Outcoming";

            }

            public static class IconButton
            {
                public const string HOME = "&#xE80F;";
                public const string FRIENDS = "&#xE716;";
                public const string SEARCH = "&#xE721;";
                public const string TRANSACTIONS = "&#xE8A5;";
                public const string INCOMING_AND_OUTCOMING = "&#xE8CB;";
            }
        }

        public static class ImageExtension
        {
            public const string JPEG = ".jpeg";
            public const string JPG = ".jpg";
            public const string PNG = ".png";
        }

        public static class Register
        {
            public static class BrowseImage
            {
                public const string BACKGROUND = "Browse background image";
                public const string AVATAR = "Browse avatar image";
            }
        }

        public static class ErrorDetails
        {
            public const string PROBLEM_SERVER = "Sory, problems with server!";
            public const string DEFAULT_ERROR_TITLE = "Wrong";

            public static class Login
            {
                public const string ERROR_TITLE = "Unable to log in.";
                public const string ERROR_DESCRIPTION = "Please check that you have entered your login and password";
            }
            public static class Register
            {
                public const string ERROR_TITLE = "Unable to Register";
                public const string ERROR_DESCRIPTION = "You have problem whith register";
                public const string ERROR_PASSWORD = "Confirmpassword isn't some password";
            }
        }

        public static class Search
        {
            public const string TEXTBOX_EMPTY = "Enter, please query for search!";
            public const string NOT_RESULTS = "Not results!";
        }
        public static class AddTransaction
        {
            public const string NOT_COLLABARATORS = "Select friend!";
        }
    }
}
