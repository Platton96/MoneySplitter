using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MoneySplitter.Win10.CustomControls
{
    public sealed partial class IssueControl : UserControl
    {
        public IssueControl()
        {
            InitializeComponent();
        }

        public bool IsIssueVisibility
        {
            get { return (bool)GetValue(IsIssueVisibilityProperty); }
            set { SetValue(IsIssueVisibilityProperty, value); }
        }

        public string IssueTitleText
        {
            get { return (string)GetValue(IssueTitleTextProperty); }
            set { SetValue(IssueTitleTextProperty, value); }
        }

        public string IssueMessageText
        {
            get { return (string)GetValue(IssueMessageTextProperty); }
            set { SetValue(IssueMessageTextProperty, value); }
        }

        public static readonly DependencyProperty IsIssueVisibilityProperty = DependencyProperty.Register(
            "IsIssueVisibility",
            typeof(bool),
            typeof(IssueControl),
            null);

        public static readonly DependencyProperty IssueTitleTextProperty = DependencyProperty.Register(
            "IssueTitleText",
            typeof(string),
            typeof(IssueControl),
            null);

        public static readonly DependencyProperty IssueMessageTextProperty = DependencyProperty.Register(
             "IssueMessageText",
             typeof(string),
             typeof(IssueControl),
             null);
    }
}
