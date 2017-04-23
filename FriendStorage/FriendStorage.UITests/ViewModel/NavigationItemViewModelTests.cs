using FriendStorage.UI.Events;
using FriendStorage.UI.ViewModel;
using Moq;
using Prism.Events;
using Xunit;
using FriendStorage.UITests.Extensions;

namespace FriendStorage.UITests.ViewModel
{
    public class NavigationItemViewModelTests
    {
        private NavigationItemViewModel _viewModel;
        const int _friendId = 7;
        private Mock<IEventAggregator> _eventAggregatorMock;

        public NavigationItemViewModelTests()
        {

            _eventAggregatorMock = new Mock<IEventAggregator>();
            _viewModel = new NavigationItemViewModel(_friendId, "Thomas", _eventAggregatorMock.Object);
        }
        [Fact]
        public void ShouldPublishOpenFriendEditViewEvent()
        {
            
            var eventMock = new Mock<OpenFriendEditViewEvent>();
            _eventAggregatorMock
                .Setup(ea => ea.GetEvent<OpenFriendEditViewEvent>())
                .Returns(eventMock.Object);

            _viewModel.OpenFriendEditViewCommand.Execute(null);
            eventMock.Verify(e => e.Publish(_friendId), Times.Once);
        }

        [Fact]

        public void ShouldRaisePropertyChangedEventForDisplayMember()
        {
            var fired = _viewModel.IsPropertyChangedFired(() =>
            {
                _viewModel.DisplayMember = "Changed";
            }, nameof(_viewModel.DisplayMember));

            Assert.True(fired);
        }
    }
}
