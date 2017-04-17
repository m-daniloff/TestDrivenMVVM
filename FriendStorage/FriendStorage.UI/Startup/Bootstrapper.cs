using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using FriendStorage.UI.ViewModel;
using FriendStorage.UI.DataProvider;
using FriendStorage.DataAccess;
using FriendStorage.UI.View;

namespace FriendStorage.UI.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();

            builder.RegisterType<NavigationViewModel>()
                .As<INavigationViewModel>();

            builder.RegisterType<NavigationDataProvider>()
               .As<INavigationDataProvider>();

            builder.RegisterType<FileDataService>()
               .As<IDataService>();

            return builder.Build();
        }
    }
}
