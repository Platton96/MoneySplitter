using MoneySplitter.Models;
using MoneySplitter.Win10.CustomControls.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MoneySplitter.Win10.CustomControls
{
    public sealed partial class CollabaratorControl : UserControl
    {
        public event EventHandler<CollabaratorModel> OnItemClick;

        private IDictionary<StatusesModel, string> _collabaratorButtonContentTexts;

        public CollabaratorModel ViewModel
        {
            get { return (CollabaratorModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }


        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(
            "ViewModel",
            typeof(CollabaratorModel),
            typeof(CollabaratorControl),
            new PropertyMetadata(default(CollabaratorModel), new PropertyChangedCallback(OnViewModelChanged)));

        public CollabaratorControl()
        {
            InitializeComponent();
            ItializeCollabaratorButtonContentTexts();
        }

        public static void OnViewModelChanged(DependencyObject sender, DependencyPropertyChangedEventArgs eventArgs)
        {
            var control = (CollabaratorControl)sender;
            control.UpdateCollabaratorButton();
        }

        public void UpdateCollabaratorButton()
        {
            if(
                   ViewModel.CollabaratorStatus == CollabaratorStatus.MANY_DEBT ||
                   ViewModel.CollabaratorStatus == CollabaratorStatus.MANY_LEND ||
                   (
                        ViewModel.CollabaratorStatus == CollabaratorStatus.ONE_LEND &&
                        ViewModel.TransactionStatus == TransactionStatus.IN_PROGRESS
                   )
              )
            {
                CollaboratorButton.Visibility = Visibility.Collapsed;
                return;
            }

            CollaboratorButton.Content=_collabaratorButtonContentTexts.FirstOrDefault(x => x.Key.Equals(new StatusesModel
            {
                CollabaratorStatus = ViewModel.CollabaratorStatus,
                TransactionStatus = ViewModel.TransactionStatus
            })
                                                           )
                                                           .Value;

            //if (_collabaratorButtonContentTexts.TryGetValue(new StatusesModel
            //{
            //    CollabaratorStatus = ViewModel.CollabaratorStatus,
            //    TransactionStatus = ViewModel.TransactionStatus
            //},
            //                                                out string buttonContent
            //                                                )
            //   )
            //{
            //    CollaboratorButton.Content = buttonContent;
            //}
            //else
            //{
            //    CollaboratorButton.Visibility = Visibility.Collapsed;
            //}

        }

        private void ItializeCollabaratorButtonContentTexts()
        {
            _collabaratorButtonContentTexts = new Dictionary<StatusesModel, string>()
            {
                {
                    new StatusesModel
                    {
                        CollabaratorStatus = CollabaratorStatus.ONE_LEND,
                        TransactionStatus = TransactionStatus.IN_BEGIN

                    },
                    Defines.Collabarator.ButtonContent.GIVE
                },

                {
                    new StatusesModel
                    {
                        CollabaratorStatus = CollabaratorStatus.ONE_DEBT,
                        TransactionStatus = TransactionStatus.IN_BEGIN

                    },
                    Defines.Collabarator.ButtonContent.REMIND
                },

                {
                    new StatusesModel
                    {
                        CollabaratorStatus = CollabaratorStatus.ONE_LEND,
                        TransactionStatus = TransactionStatus.IN_PROGRESS

                    },
                    Defines.Collabarator.ButtonContent.APPROVE
                }

            };
        }
 

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            OnItemClick?.Invoke(this, ViewModel);
        }

        
    }
}
