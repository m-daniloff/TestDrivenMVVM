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
using Prism.Events;

namespace FriendStorage.UI.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<EventAggregator>()
                .As<IEventAggregator>().SingleInstance();

            builder.RegisterType<MainWindow>().AsSelf();

            builder.RegisterType<MainViewModel>().AsSelf();

            builder.RegisterType<FriendEditViewModel>()
                .As<IFriendEditViewModel>();

            builder.RegisterType<FriendDataProvider>()
                .As<IFriendDataProvider>();

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
