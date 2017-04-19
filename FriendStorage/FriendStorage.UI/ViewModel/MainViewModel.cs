using FriendStorage.UI.Events;
using Prism.Events;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace FriendStorage.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private IFriendEditViewModel _selectedFriendEditViewModel;
        private Func<IFriendEditViewModel> _friendEditViewModelCreator;
        public MainViewModel(INavigationViewModel navigationViewModel, Func<IFriendEditViewModel> friendEditViewModelCreator,
            IEventAggregator eventAggregator)
        {
            NavigationViewModel = navigationViewModel;
            _friendEditViewModelCreator = friendEditViewModelCreator;
            FriendEditViewModels = new ObservableCollection<IFriendEditViewModel>();
            eventAggregator.GetEvent<OpenFriendEditViewEvent>().Subscribe(OnOpenFriendEditView);
            //new NavigationViewModel(
            //new NavigationDataProvider(
            //    ()=> new FileDataService()));
        }

        private void OnOpenFriendEditView(int friendId)
        {
            var friendEditVm = FriendEditViewModels.SingleOrDefault(vm => vm.Friend.Id == friendId);
            if (friendEditVm == null)
            {
                friendEditVm = _friendEditViewModelCreator();
                FriendEditViewModels.Add(friendEditVm);
                friendEditVm.Load(friendId);
            }   
            SelectedFriendEditViewModel = friendEditVm;
        }

        public ObservableCollection<IFriendEditViewModel> FriendEditViewModels { get; private set; }      

        public IFriendEditViewModel SelectedFriendEditViewModel
        {
            get { return _selectedFriendEditViewModel; }
            set
            {
                _selectedFriendEditViewModel = value;
                OnPropertyChanged();
            }
        }
        public INavigationViewModel NavigationViewModel { get; private set; }

        public void Load()
        {
            NavigationViewModel.Load();
        }
    }
}
