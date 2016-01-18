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
    /// 

    public sealed partial class regfaculty : Page
    {
        private MobileServiceCollection<TodoItem3, TodoItem3> items;
        private IMobileServiceTable<TodoItem3> registerstudent = App.MobileService.GetTable<TodoItem3>();
        private MobileServiceCollection<TodoItem4, TodoItem4> itemsn;
        private IMobileServiceTable<TodoItem4> registerstudent2 = App.MobileService.GetTable<TodoItem4>();

        public regfaculty()
        {
            this.InitializeComponent();
        }
        private async Task InsertTodoItem(TodoItem3 todoitem)
        {
            await registerstudent.InsertAsync(todoitem);
            items.Add(todoitem);
        }
        private async Task InsertTodoItem(TodoItem4 todoitem)
        {
            await registerstudent2.InsertAsync(todoitem);
            itemsn.Add(todoitem);
        }
        private void register(object sender, RoutedEventArgs e)
        {
            var todoItem = new TodoItem3
            {
                Name = textBox.Text,
                Course = comboBox.Items[comboBox.SelectedIndex].ToString(),
                username = textBox2.Text,
                password = passwordBox.Password,
                email = textBox3.Text,
                phoneno = textBox4.Text
            };
            var todoItem2 = new TodoItem4
            {
                username = textBox2.Text,
                password = passwordBox.Password,
                value = "Faculty"
            };
            string pw1 = passwordBox.Password;
            string pw2 = passwordBox2.Password;
            if (pw1.Equals(pw2))
            {
                InsertTodoItem(todoItem);
                InsertTodoItem(todoItem2);
                this.Frame.Navigate(typeof(MainPage), null);
            }
            else
            {

            }
        }
    }
}
