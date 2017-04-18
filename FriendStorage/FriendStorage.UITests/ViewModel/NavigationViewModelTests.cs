using FriendStorage.Model;
using FriendStorage.UI.DataProvider;
using FriendStorage.UI.ViewModel;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FriendStorage.UITests.ViewModel
{
    public class NavigationViewModelTests
    {
        private NavigationViewModel _viewModel;

        public NavigationViewModelTests()
        {
            var navigationDataProviderMock = new Mock<INavigationDataProvider>();
            navigationDataProviderMock.Setup(dp => dp.GetAllFriends())
                .Returns(new List<LookupItem>
                {
                    new LookupItem() { DisplayMember = "Julia", Id = 1 },
                    new LookupItem() { Id = 2, DisplayMember = "Thomas" }
                });

            _viewModel = new NavigationViewModel(navigationDataProviderMock.Object);
        }
        [Fact]
        public void ShouldLoadFriends()
        {
            _viewModel.Load();

            Assert.Equal(2, _viewModel.Friends.Count);
            var friend = _viewModel.Friends.SingleOrDefault(f => f.Id == 1);
            Assert.NotNull(friend);
            Assert.Equal(friend.DisplayMember, "Julia");

            friend = _viewModel.Friends.SingleOrDefault(f => f.Id == 2);
            Assert.NotNull(friend);
            Assert.Equal(friend.DisplayMember, "Thomas");
        }

        [Fact]
        public void ShouldLoadFriendsOnlyOnce()
        {


            _viewModel.Load();
            _viewModel.Load();

            Assert.Equal(2, _viewModel.Friends.Count);
        }
    }
}
