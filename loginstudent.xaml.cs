using App2.dataModel;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class loginstudent : Page
    {
        private IMobileServiceTable<TodoItem> todoTable = App.MobileService.GetTable<TodoItem>();

        public loginstudent()
        {
            this.InitializeComponent();

        }
        string newkey = "";
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            var pstudent = await todoTable
                       .Where(t => t.username == e.Parameter.ToString()).ToCollectionAsync();
            newkey = pstudent[0].username;
            textBlock.Text = "Welcome, " + pstudent[0].Name;

            base.OnNavigatedTo(e);
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;

            SystemNavigationManager.GetForCurrentView().BackRequested += loginstudent_BackRequested;
        }

        private void loginstudent_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
                Frame.GoBack();
        }

        public void studentcourses(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(studentcourses), newkey);
        }
        public void academicp(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(academicp), newkey);
        }
        public void attend(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(attend), newkey);
        }
    }
}
