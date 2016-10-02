using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                StorageFile file = await ApplicationData.Current.LocalFolder.GetFileAsync("keys.ini");
                List<storage> items = new List<storage>();
                string temp = await Windows.Storage.FileIO.ReadTextAsync(file);
                string[] arr = temp.Split('\n');

                foreach (string s in arr)
                {
                    string[] substring = s.Split('\n');
                    
                   
                    storage item = new storage(substring[0],substring[1]);
                    items.Add(item);
                }
                list.ItemsSource = items;
            }
            catch
            {

            }
        }

        private void add_agenda_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(add_agenda));
        }
    }
}
