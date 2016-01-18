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
    public sealed partial class uploadcourse : Page
    {
        private IMobileServiceTable<TodoItem3> todoTable = App.MobileService.GetTable<TodoItem3>();
        private IMobileServiceTable<TodoItem> todoTable2 = App.MobileService.GetTable<TodoItem>();
        public uploadcourse()
        {
            this.InitializeComponent();
        }
        string newkey = "";
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            var pstudent = await todoTable
                       .Where(t => t.username == e.Parameter.ToString()).ToCollectionAsync();
            newkey = pstudent[0].Course;
        }
        public async void upload(object sender, RoutedEventArgs e)
        {
            if(newkey.Equals("English"))
            {
                DateTime thisDay = DateTime.Now;
                var pstudent2 = await todoTable2
                           .Where(t => t.eng==true).ToCollectionAsync();
                pstudent2[0].engc = thisDay.ToString() + " ,"+textBox.Text + "\n" + pstudent2[0].engc + " \n\n";
                pstudent2[0].scic = "";
                pstudent2[0].hinc = "";
                pstudent2[0].mathc = "";
                pstudent2[0].ssc = "";
                pstudent2[0].csc = "";
                await todoTable2.UpdateAsync(pstudent2[0]);
                this.Frame.Navigate(typeof(MainPage), null);
            }
            else if(newkey.Equals("Hindi"))
            {
                DateTime thisDay = DateTime.Now;
                var pstudent2 = await todoTable2
                           .Where(t => t.hin == true).ToCollectionAsync();
                pstudent2[0].hinc = thisDay.ToString() + " ," + textBox.Text + "\n" + pstudent2[0].hinc + " \n\n";
                pstudent2[0].engc = "";
                pstudent2[0].scic = "";
                pstudent2[0].mathc = "";
                pstudent2[0].ssc = "";
                pstudent2[0].csc = "";
                await todoTable2.UpdateAsync(pstudent2[0]);
                this.Frame.Navigate(typeof(MainPage), null);
            }
            else if (newkey.Equals("Maths"))
            {
                DateTime thisDay = DateTime.Now;
                var pstudent2 = await todoTable2
                           .Where(t => t.math == true).ToCollectionAsync();
                pstudent2[0].mathc = thisDay.ToString() + " ," + textBox.Text + "\n" + pstudent2[0].mathc + " \n\n";
                pstudent2[0].engc = "";
                pstudent2[0].hinc = "";
                pstudent2[0].scic = "";
                pstudent2[0].ssc = "";
                pstudent2[0].csc = "";
                await todoTable2.UpdateAsync(pstudent2[0]);
                this.Frame.Navigate(typeof(MainPage), null);
            }
            else if (newkey.Equals("Science"))
            {
                DateTime thisDay = DateTime.Now;
                var pstudent2 = await todoTable2
                           .Where(t => t.sci == true).ToCollectionAsync();
                pstudent2[0].scic= thisDay.ToString() + " ," + textBox.Text + "\n" + " \n\n";
                pstudent2[0].engc = "";
                    pstudent2[0].hinc = "";
                    pstudent2[0].mathc = "";
                    pstudent2[0].ssc = "";
                    pstudent2[0].csc = "";
                await todoTable2.UpdateAsync(pstudent2[0]);
                this.Frame.Navigate(typeof(MainPage), null);
            }
            else if (newkey.Equals("Social Science"))
            {
                DateTime thisDay = DateTime.Now;
                var pstudent2 = await todoTable2
                           .Where(t => t.ss == true).ToCollectionAsync();
                pstudent2[0].ssc = thisDay.ToString() + " ," + textBox.Text + "\n" + pstudent2[0].ssc + " \n\n";
                pstudent2[0].engc = "";
                pstudent2[0].hinc = "";
                pstudent2[0].mathc = "";
                pstudent2[0].scic = "";
                pstudent2[0].csc = "";
                await todoTable2.UpdateAsync(pstudent2[0]);
                this.Frame.Navigate(typeof(MainPage), null);
            }
            else
            {
                DateTime thisDay = DateTime.Now;
                var pstudent2 = await todoTable2
                           .Where(t => t.cs == true).ToCollectionAsync();
                pstudent2[0].csc = thisDay.ToString() + " ," + textBox.Text + "\n" + pstudent2[0].csc + " \n\n";
                pstudent2[0].engc = "";
                pstudent2[0].hinc = "";
                pstudent2[0].mathc = "";
                pstudent2[0].ssc = "";
                pstudent2[0].scic = "";
                await todoTable2.UpdateAsync(pstudent2[0]);
                this.Frame.Navigate(typeof(MainPage), null);
            }

        }
    }
}
