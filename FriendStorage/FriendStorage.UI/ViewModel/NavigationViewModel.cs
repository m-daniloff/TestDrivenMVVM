using FriendStorage.Model;
using FriendStorage.UI.DataProvider;
using System.Collections.ObjectModel;

namespace FriendStorage.UI.ViewModel
{
    public class NavigationViewModel : ViewModelBase, INavigationViewModel
    {
        INavigationDataProvider _dataProvider;
        public NavigationViewModel(INavigationDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
            Friends = new ObservableCollection<LookupItem>();
        }
        public void Load()
        {
            Friends.Clear();
            foreach (var friend in _dataProvider.GetAllFriends())
            {
                Friends.Add(friend);
            }
        }

        public ObservableCollection<LookupItem> Friends { get; private set; }
    }
}
