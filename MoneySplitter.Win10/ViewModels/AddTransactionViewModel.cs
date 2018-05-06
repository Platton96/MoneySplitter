using Caliburn.Micro;
using MoneySplitter.Infrastructure;
using MoneySplitter.Models;
using MoneySplitter.Models.App;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySplitter.Win10.ViewModels
{
    public class AddTransactionViewModel :Screen
    {
        #region Fields
        private ObservableCollection<UserModel> _friends;
        private ObservableCollection<UserModel> _collabarators;
        private AddTransactionModel _addTransactionModel;

        private IFriendsManager _friendsManager;
        private ITransactionsManager _transactionsManager;
        private readonly IFilePickerService _filePickerService;

        private string _laberlForTransactionImage = Defines.Register.BrowseImage.AVATAR;
        private bool _isNoCollaboratorsTextVisibility;
        private bool _isLoading;
        private bool _isErrorVisible;
        private ErrorDetailsModel _errorDetailsModel;
        #endregion

        public AddTransactionViewModel(ITransactionsManager transactionsManager, IFriendsManager friendsManager, IFilePickerService filePickerService)
        {
            _friendsManager = friendsManager;
            _transactionsManager = transactionsManager;
            _filePickerService = filePickerService;
        }

        #region Properties
        public ObservableCollection<UserModel> Friends
        {
            get { return _friends; }
            set
            {
                _friends = value;
                NotifyOfPropertyChange(nameof(Friends));
            }
        }

        public ObservableCollection<UserModel> Collabarators
        {
            get { return _collabarators; }
            set
            {
                _collabarators = value;
                NotifyOfPropertyChange(nameof(Collabarators));
            }
        }

        public AddTransactionModel AddTransactionModel
        {
            get { return _addTransactionModel; }
            set
            {
                _addTransactionModel = value;
                NotifyOfPropertyChange(nameof(AddTransactionModel));
            }
        }

        public string LabelForTransactionImage
        {
            get { return _laberlForTransactionImage; }
            set
            {
                _laberlForTransactionImage = value;
                NotifyOfPropertyChange(nameof(LabelForTransactionImage));
            }
        }
        public bool IsNotCollaboratorsTextVisibility
        {
            get { return _isNoCollaboratorsTextVisibility; }
            set
            {
                _isNoCollaboratorsTextVisibility = value;
                NotifyOfPropertyChange(nameof(IsNotCollaboratorsTextVisibility));
            }
        }

        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                NotifyOfPropertyChange(nameof(IsLoading));
            }
        }

        public bool IsErrorVisible
        {
            get { return _isErrorVisible; }
            set
            {
                _isErrorVisible = value;
                NotifyOfPropertyChange(nameof(IsErrorVisible));
            }
        }

        public ErrorDetailsModel ErrorDetailsModel
        {
            get { return _errorDetailsModel; }
            set
            {
                _errorDetailsModel = value;
                NotifyOfPropertyChange(nameof(ErrorDetailsModel));
            }
        }
        #endregion

        protected override void OnActivate()
        {
            base.OnActivate();
            if(_friendsManager.UserFriends.Count()==0)
            {
                _friendsManager.LoadUserFriendsAsync();
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
            var friend = Friends.FirstOrDefault(x => x.Id == friendId);
            Collabarators.Remove(friend);

            if (Collabarators.Count==0)
            {
                IsNotCollaboratorsTextVisibility = true;
            }

            Friends.Add(friend);
        }

        //public Task AddTransaction()
        //{
            
        //}

        public async Task BrowseTransactionImageAsync()
        {
            IsLoading = true;
            var imageResult = await _filePickerService.BrowseImageAsync();
            IsLoading = false;

            AddTransactionModel.ImageBase64String = imageResult.Base64StringImage;
            LabelForTransactionImage = imageResult.ImageName;
        }
    }
}
