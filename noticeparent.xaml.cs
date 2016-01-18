using App2.dataModel;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
    public sealed partial class noticeparent : Page
    {
        private IMobileServiceTable<TodoItem2> todoTable = App.MobileService.GetTable<TodoItem2>();
        private IMobileServiceTable<TodoItem3> todoTable2 = App.MobileService.GetTable<TodoItem3>();
        private MobileServiceCollection<TodoItem2, TodoItem2> items;
        public noticeparent()
        {
            this.InitializeComponent();
        }
        
        string newkey = "";
        string course = "";
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            var pstudent = await todoTable2
                       .Where(t => t.username == e.Parameter.ToString()).ToCollectionAsync();
            newkey = pstudent[0].Name;
            course = pstudent[0].Course;
        }
        private async void sendmsg(object sender, RoutedEventArgs e)
        {
            DateTime thisDay = DateTime.Now;
            var pstudent = await todoTable
                       .Where(t => t.SchoolID == textBox.Text).ToCollectionAsync();
            pstudent[0].message = thisDay.ToString()+" ,"+course+" : "+ newkey+ " -"+ textBox2.Text+ "\n" + pstudent[0].message+" \n\n";
             await todoTable.UpdateAsync(pstudent[0]);
            this.Frame.Navigate(typeof(MainPage), null);
        }
        
    }
}
