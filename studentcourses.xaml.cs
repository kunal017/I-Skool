using App2.dataModel;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class studentcourses : Page
    {

        private IMobileServiceTable<TodoItem> todoTable = App.MobileService.GetTable<TodoItem>();
        public studentcourses()
        {
            this.InitializeComponent();
        }
        bool[] ar = new bool[6];
        String[] ar2 = new String[6];
        string newkey = "";
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            var pstudent1 = await todoTable
                       .Where(t => t.username == e.Parameter.ToString()).ToCollectionAsync();
            //newkey = pstudent1[0].username;
            ar[0] = pstudent1[0].eng; ar[1] = pstudent1[0].hin; ar[2] = pstudent1[0].math;
            ar[3] = pstudent1[0].sci; ar[4] = pstudent1[0].ss; ar[5] = pstudent1[0].cs;
            ar2[0] = "English"; ar2[1] = "Hindi"; ar2[2] = "Maths"; ar2[3] = "Science"; ar2[4] = "Social Science"; ar2[5] = "Computer Science";
            Button[] buttons = new Button[] { button, button1, button2, button3, button4, button5 };
            int j = 0;
            for (int i = 0; i < 6; i = i + 1)
            {
                if (ar[i] == true)
                {
                    buttons[j].Content = ar2[i];
                    buttons[j].Visibility = Visibility.Visible;
                    j++;
                }

            }
            var pstudent2 = await todoTable
                       .Where(t => t.username == e.Parameter.ToString()).ToCollectionAsync();
            newkey = pstudent2[0].username;

        }
        private void english(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(english), newkey);
        }
        private void hindi(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(hindi), newkey);
        }
        private void maths(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(maths), newkey);
        }
        private void socialstudies(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(socialstudies), newkey);
        }
        private void science(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(science), newkey);
        }
        private void computerscience(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(computerscience), newkey);
        }

    }
}
