
using FriendStorage.UI.Command;
using FriendStorage.UI.Events;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FriendStorage.UI.ViewModel
{
    public class NavigationItemViewModel : ViewModelBase
    {
        private IEventAggregator _eventAggregator;

        public NavigationItemViewModel(int id, string displayMember, IEventAggregator eventAggregator)
        {
            Id = id;
            DisplayMember = displayMember;
            _eventAggregator = eventAggregator;
            OpenFriendEditViewCommand = new DelegateCommand(OnFriendEditViewExecute);
        }

        private void OnFriendEditViewExecute(object ob)
        {
            _eventAggregator.GetEvent<OpenFriendEditViewEvent>().
                Publish(Id);
        }

        private string _displayMember;
        public string DisplayMember
        {
            get
            {
                return _displayMember;
            }
            set
            {
                _displayMember = value;
                OnPropertyChanged("DisplayMember");
            }
        }
        public int Id { get; private set; }

        public ICommand OpenFriendEditViewCommand { get; private set; }
    }
}
