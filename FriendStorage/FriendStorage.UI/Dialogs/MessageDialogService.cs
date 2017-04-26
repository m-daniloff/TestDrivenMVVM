using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FriendStorage.UI.Dialogs
{
  public class MessageDialogService : IMessageDialogService
  {
    public MessageDialogResult ShowYesNoDialog(string title, string message)
    {
            //return MessageBox.Show(title, message, MessageBoxButton.YesNo) ==
            //    MessageBoxResult.Yes
            //    ? MessageDialogResult.Yes
            //    : MessageDialogResult.No;

            return new YesNoDialog(title, message)
            {
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Owner = App.Current.MainWindow
            }.ShowDialog().GetValueOrDefault()
              ? MessageDialogResult.Yes
              : MessageDialogResult.No;
        }
  }
}
