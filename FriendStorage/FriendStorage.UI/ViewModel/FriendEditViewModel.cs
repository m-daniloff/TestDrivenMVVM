using System;
using FriendStorage.Model;
using FriendStorage.UI.DataProvider;

namespace FriendStorage.UI.ViewModel
{
    public class FriendEditViewModel : ViewModelBase, IFriendEditViewModel
    {
        private IFriendDataProvider _dataProvider;
        private Friend _friend;

        public FriendEditViewModel(IFriendDataProvider dataProvider)
        {
            this._dataProvider = dataProvider;
        }

        public Friend Friend
        {
            get
            {
                return _friend;
            }

            private set
            {
                _friend = value;
                OnPropertyChanged();
            }
        }

        public void Load(int friendId)
        {
            _friend = _dataProvider.GetFriendById(friendId);
            Friend = _friend;
        }
    }
}
