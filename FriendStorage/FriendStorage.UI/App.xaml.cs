using Autofac;
using FriendStorage.DataAccess;
using FriendStorage.UI.DataProvider;
using FriendStorage.UI.Startup;
using FriendStorage.UI.View;
using FriendStorage.UI.ViewModel;
using System.Windows;

namespace FriendStorage.UI
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var bootstrapper = new Bootstrapper();
            var container = bootstrapper.Bootstrap();

            var window = container.Resolve<MainWindow>();

            //MainWindow window = new MainWindow(new MainViewModel(new NavigationViewModel(
            //                                                     new NavigationDataProvider(
            //                                                         () => new FileDataService()))));
            window.Show();
        }
    }
}
