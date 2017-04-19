using FriendStorage.Model;
using FriendStorage.UI.DataProvider;
using Prism.Events;
using System.Collections.ObjectModel;

namespace FriendStorage.UI.ViewModel
{
    public class NavigationViewModel : ViewModelBase, INavigationViewModel
    {
        INavigationDataProvider _dataProvider;
        private IEventAggregator _eventAggregator;

        public NavigationViewModel(INavigationDataProvider dataProvider, IEventAggregator eventAggregator)
        {
            _dataProvider = dataProvider;
            _eventAggregator = eventAggregator;
            Friends = new ObservableCollection<NavigationItemViewModel>();
        }
        public void Load()
        {
            Friends.Clear();
            foreach (var friend in _dataProvider.GetAllFriends())
            {
                Friends.Add(new NavigationItemViewModel(friend.Id, friend.DisplayMember, _eventAggregator));
            }
        }

        public ObservableCollection<NavigationItemViewModel> Friends { get; private set; }
    }
}
