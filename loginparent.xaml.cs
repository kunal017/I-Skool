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
    public sealed partial class loginparent : Page
    {
        private IMobileServiceTable<TodoItem2> todoTable = App.MobileService.GetTable<TodoItem2>();
        string newkey = "";
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            var pstudent = await todoTable
                       .Where(t => t.username == e.Parameter.ToString()).ToCollectionAsync();
            newkey = pstudent[0].SchoolID;
            textBlock.Text = "Welcome, " + pstudent[0].Name;

            base.OnNavigatedTo(e);
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;

            SystemNavigationManager.GetForCurrentView().BackRequested += loginparent_BackRequested;
        }

        private void loginparent_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
                Frame.GoBack();
        }
        public loginparent()
        {
            this.InitializeComponent();
        }
        private void academicp(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(academicpP), newkey);
        }
        private void attend(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(attendP), newkey);
        }
        private void teachersnotice(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(teachersnotice), newkey);
        }
    }
}
