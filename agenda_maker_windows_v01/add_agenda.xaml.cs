using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace agenda_maker_windows_v01
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class add_agenda : Page
    {
        public add_agenda()
        {
            this.InitializeComponent();
        }

        private async void add_Click(object sender, RoutedEventArgs e)
        {
            if(title.Text!="")
            {

                string content = title.Text +"\n"+description.Text+"\n";
                StorageFile tempfile;
                try
                {
                    tempfile = await ApplicationData.Current.LocalFolder.CreateFileAsync("keys.ini", CreationCollisionOption.FailIfExists);
                    await Windows.Storage.FileIO.WriteTextAsync(tempfile, content);
                }
                catch
                {
                    tempfile = await ApplicationData.Current.LocalFolder.GetFileAsync("keys.ini");
                    await Windows.Storage.FileIO.AppendTextAsync(tempfile, content);
                }
                Frame.Navigate(typeof(MainPage));
            }
            else
            {
                Popup("Error", "Enter title ...");
            }
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private async void Popup(string title,string message)
        {
            var messageDialog = new MessageDialog(message);
            messageDialog.Title = title;
            // Add commands and set their callbacks; both buttons use the same callback function instead of inline event handlers
            messageDialog.Commands.Add(new UICommand(
                "Close",
                new UICommandInvokedHandler(this.CommandInvokedHandler)));

            // Set the command that will be invoked by default
            messageDialog.DefaultCommandIndex = 0;

            // Set the command to be invoked when escape is pressed
            messageDialog.CancelCommandIndex = 1;

            // Show the message dialog
            await messageDialog.ShowAsync();
        }
        private void CommandInvokedHandler(IUICommand command)
        {

        }
    }
}
