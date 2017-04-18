using FriendStorage.UI.ViewModel;
using Moq;
using Xunit;

namespace FriendStorage.UITests.ViewModel
{
    public class MainViewModelTests
    {
        private Mock<INavigationViewModel> _navigationViewModelMock;
        private MainViewModel _viewModel;

        public MainViewModelTests()
        {
            _navigationViewModelMock = new Mock<INavigationViewModel>();
            _viewModel = new MainViewModel(_navigationViewModelMock.Object);
        }
        [Fact]
        public void ShouldCallLoadMethodOfNavigationViewModel()
        {
            _viewModel.Load();
            _navigationViewModelMock.Verify(vm => vm.Load(), Times.Once);
        }
    }
}
