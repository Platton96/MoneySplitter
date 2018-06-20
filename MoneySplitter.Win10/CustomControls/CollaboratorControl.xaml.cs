using MoneySplitter.Models;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MoneySplitter.Win10.CustomControls
{
    public sealed partial class CollaboratorControl : UserControl
    {
        public event EventHandler<CollaboratorModel> OnGiveCollaboratorButtonClick;
        public event EventHandler<CollaboratorModel> OnRemindCollaboratorButtonClick;
        public event EventHandler<CollaboratorModel> OnApproveCollaboratorButtonClick;

        public CollaboratorModel ViewModel
        {
            get { return (CollaboratorModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }


        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(
            "ViewModel",
            typeof(CollaboratorModel),
            typeof(CollaboratorControl),
            null);

        public CollaboratorControl()
        {
            InitializeComponent();
        }

        private void OnGiveButtonClick(object sender, RoutedEventArgs e)
        {
            OnGiveCollaboratorButtonClick?.Invoke(this, ViewModel);
        }

        private void OnRemindButtonClick(object sender, RoutedEventArgs e)
        {
            OnRemindCollaboratorButtonClick?.Invoke(this, ViewModel);
        }

        private void OnApproveButtonClick(object sender, RoutedEventArgs e)
        {
            OnApproveCollaboratorButtonClick?.Invoke(this, ViewModel);
        }
    }
}
