using Windows.UI.Xaml.Controls;
using MoneySplitter.Win10.ViewModels;
using MoneySplitter.Models;

namespace MoneySplitter.Win10.Views
{
    public sealed partial class IncomingAndOutcomingView : Page
    {
        IncomingAndOutcomingViewModel ViewModel { get; set; }
        public IncomingAndOutcomingView()
        {
            InitializeComponent();
            DataContextChanged += (s, e) => { ViewModel = DataContext as IncomingAndOutcomingViewModel; };
        }

        private void OnRemindCollaboratorButtonClick(object sender, CollaboratorModel e)
        {

        }

        private async void OnGiveCollaboratorButtonClick(object sender, CollaboratorModel e)
        {
            await ViewModel.MoveUserToInProgress(e.TransactionId);
        }

        private async void OnApproveCollaboratorButtonClick(object sender, CollaboratorModel e)
        {
            await ViewModel.MoveUserToFinished(e.TransactionId, e.FriendId);
        }
    }
}
