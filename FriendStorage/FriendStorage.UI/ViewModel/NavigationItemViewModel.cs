
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
    public class NavigationItemViewModel
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

        public string DisplayMember { get; private set; }
        public int Id { get; private set; }

        public ICommand OpenFriendEditViewCommand { get; private set; }
    }
}
