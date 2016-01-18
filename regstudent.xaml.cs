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
    //
    public sealed partial class regstudent : Page
    {
        private MobileServiceCollection<TodoItem, TodoItem> items;
        private IMobileServiceTable<TodoItem> registerstudent = App.MobileService.GetTable<TodoItem>();
        private MobileServiceCollection<TodoItem4, TodoItem4> itemsn;
        private IMobileServiceTable<TodoItem4> registerstudent2 = App.MobileService.GetTable<TodoItem4>();

        public regstudent()
        {
            this.InitializeComponent();
        }
        private async Task InsertTodoItem(TodoItem todoitem)
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
            var todoItem = new TodoItem
            {
                Name = textBox.Text,
                SchoolID = textBox1.Text,
                gender = comboBox.Items[comboBox.SelectedIndex].ToString(),
                dateofbirth = comboBox2.Items[comboBox2.SelectedIndex].ToString() + "/" + comboBox3.Items[comboBox3.SelectedIndex].ToString() + "/" + comboBox4.Items[comboBox4.SelectedIndex].ToString(),
                username = textBox2.Text,
                password = passwordBox.Password,
                email = textBox3.Text,
                phoneno = textBox4.Text,
                eng = checkBox.IsChecked.Value,
                hin = checkBox1.IsChecked.Value,
                math = checkBox2.IsChecked.Value,
                sci = checkBox3.IsChecked.Value,
                ss = checkBox4.IsChecked.Value,
                cs = checkBox5.IsChecked.Value
            };
            var todoItem2 = new TodoItem4
            {
                username = textBox2.Text,
                password = passwordBox.Password,
                value = "Student"
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
