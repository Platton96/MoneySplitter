using Caliburn.Micro;
using MoneySplitter.Infrastructure;
using MoneySplitter.Models;
using MoneySplitter.Models.App;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace MoneySplitter.Win10.ViewModels
{
    public class AddTransactionViewModel : Screen
    {
        #region Fields
        private ObservableCollection<UserModel> _friends;
        private ObservableCollection<UserModel> _collabarators;
        private AddTransactionModel _addTransactionModel;

        private readonly IFriendsManager _friendsManager;
        private readonly ITransactionsManager _transactionsManager;
        private readonly IFilePickerService _filePickerService;
        private readonly INavigationManager _navigationManager;
        private readonly IMembershipService _membershipService;
        private readonly ILocalizationService _localizationService;

        private string _labelForTransactionImage;
        private bool _isNoCollaboratorsTextVisibility;
        private bool _isLoading;
        private bool _isSelfCollabarator;
        private bool _isErrorVisible;
        private ErrorDetailsModel _errorDetailsModel;
        #endregion

        #region Properties
        public ObservableCollection<UserModel> Friends
        {
            get => _friends; 
            set
            {
                _friends = value;
                NotifyOfPropertyChange(nameof(Friends));
            }
        }

        public ObservableCollection<UserModel> Collabarators
        {
            get => _collabarators; 
            set
            {
                _collabarators = value;
                NotifyOfPropertyChange(nameof(Collabarators));
            }
        }

        public AddTransactionModel AddTransactionModel
        {
            get => _addTransactionModel; 
            set
            {
                _addTransactionModel = value;
                NotifyOfPropertyChange(nameof(AddTransactionModel));
            }
        }

        public string LabelForTransactionImage
        {
            get => _labelForTransactionImage; 
            set
            {
                _labelForTransactionImage = value;
                NotifyOfPropertyChange(nameof(LabelForTransactionImage));
            }
        }

        public bool IsNotCollaboratorsTextVisibility
        {
            get => _isNoCollaboratorsTextVisibility; 
            set
            {
                _isNoCollaboratorsTextVisibility = value;
                NotifyOfPropertyChange(nameof(IsNotCollaboratorsTextVisibility));
            }
        }

        public bool IsLoading
        {
            get => _isLoading; 
            set
            {
                _isLoading = value;
                NotifyOfPropertyChange(nameof(IsLoading));
            }
        }

        public bool IsErrorVisible
        {
            get  => _isErrorVisible; 
            set
            {
                _isErrorVisible = value;
                NotifyOfPropertyChange(nameof(IsErrorVisible));
            }
        }

        public bool IsSelfCollabarator
        {
            get => _isSelfCollabarator; 
            set
            {
                _isSelfCollabarator = value;
                NotifyOfPropertyChange(nameof(IsSelfCollabarator));
            }
        }

        public ErrorDetailsModel ErrorDetailsModel
        {
            get => _errorDetailsModel;
            set
            {
                _errorDetailsModel = value;
                NotifyOfPropertyChange(nameof(ErrorDetailsModel));
            }
        }
        #endregion

        public AddTransactionViewModel(
            ITransactionsManager transactionsManager,
            IFriendsManager friendsManager,
            IFilePickerService filePickerService,
            INavigationManager navigationManager,
            IMembershipService membershipService,
            ILocalizationService localizationService)
        {
            _friendsManager = friendsManager;
            _transactionsManager = transactionsManager;
            _filePickerService = filePickerService;
            _navigationManager = navigationManager;
            _membershipService = membershipService;
            _localizationService = localizationService;

            _labelForTransactionImage = _localizationService.GetString(Texts.TRANSACTION_IMAGE_TEXTBLOCK_TEXT);

            AddTransactionModel = new AddTransactionModel
            {
                DeadlineDate = DateTime.Now
            };

            IsSelfCollabarator = true;
        }

        #region Methods
        protected override async void OnActivate()
        {
            base.OnActivate();

            if (_friendsManager.UserFriends == null)
            {
                IsLoading = true;
                await _friendsManager.LoadUserFriendsAsync();
                IsLoading = false;
            }

            Friends = new ObservableCollection<UserModel>(_friendsManager.UserFriends);
            Collabarators = new ObservableCollection<UserModel>();
            IsNotCollaboratorsTextVisibility = true;
        }

        public void AddFriendToCollabarators(int friendId)
        {
            var friend = Friends.FirstOrDefault(x => x.Id == friendId);

            IsNotCollaboratorsTextVisibility = false;
            Friends.Remove(friend);
            Collabarators.Add(friend);
        }

        public void RemoveFriendFromCollabarators(int friendId)
        {
            var friend = Collabarators.FirstOrDefault(x => x.Id == friendId);
            Collabarators.Remove(friend);

            if (!Collabarators.Any())
            {
                IsNotCollaboratorsTextVisibility = true;
            }

            Friends.Add(friend);
        }

        public async Task AddTransactionAsync()
        {
            if (IsSelfCollabarator == true)
            {
                Collabarators.Add(_membershipService.CurrentUser);
            }

            AddTransactionModel.CollaboratorsIds = Collabarators.Select(x => x.Id);

            IsLoading = true;
            var IsSuccessExecution = await _transactionsManager.AddTransactionAsync(AddTransactionModel);
            IsLoading = false;

            if (!IsSuccessExecution)
            {
                IsErrorVisible = true;
                ErrorDetailsModel = new ErrorDetailsModel
                {
                    ErrorTitle = _localizationService.GetString(Texts.DEFAULT_ERROR_TITLE),
                    ErrorDescription = _localizationService.GetString(Texts.PROBLEM_SERVER_ERROR)
                };
                return;
            }

            _navigationManager.NavigateToTransactionsViewModel();
        }

        public async Task BrowseTransactionImageAsync()
        {
            IsLoading = true;
            var imageResult = await _filePickerService.BrowseImageAsync();
            IsLoading = false;

            AddTransactionModel.ImageBase64String = imageResult.Base64StringImage;
            LabelForTransactionImage = imageResult.ImageName;
        }
        #endregion
    }
}
