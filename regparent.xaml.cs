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

    public sealed partial class regparent : Page
    {
        private MobileServiceCollection<TodoItem2, TodoItem2> items2;
        private IMobileServiceTable<TodoItem2> registerparent = App.MobileService.GetTable<TodoItem2>();
        private MobileServiceCollection<TodoItem4, TodoItem4> itemsn;
        private IMobileServiceTable<TodoItem4> registerstudent2 = App.MobileService.GetTable<TodoItem4>();

        public regparent()
        {
            this.InitializeComponent();
        }
        private async Task InsertTodoItem(TodoItem2 todoitem2)
        {
            await registerparent.InsertAsync(todoitem2);
            items2.Add(todoitem2);
        }
        private async Task InsertTodoItem(TodoItem4 todoitem)
        {
            await registerstudent2.InsertAsync(todoitem);
            itemsn.Add(todoitem);
        }
        private void register(object sender, RoutedEventArgs e)
        {
            var todoItem = new TodoItem2
            {
                Name = textBox.Text,
                SchoolID = textBox1.Text,
                username = textBox2.Text,
                password = passwordBox.Password,
                email = textBox3.Text,
                phoneno = textBox4.Text
            };
            var todoItem2 = new TodoItem4
            {
                username = textBox2.Text,
                password = passwordBox.Password,
                value = "Parent"
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
