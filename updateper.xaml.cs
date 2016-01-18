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
    public sealed partial class updateper : Page
    {
        private IMobileServiceTable<TodoItem> todoTable = App.MobileService.GetTable<TodoItem>();
        public updateper()
        {
            this.InitializeComponent();
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                textBox1.Text = "";
                var pass = await todoTable
                        .Where(t => t.SchoolID == textBox.Text).ToCollectionAsync();
                String s = pass[0].password;
                this.Frame.Navigate(typeof(updaterec), pass[0].username);
            }
            catch (Exception)
            {
                textBox1.Text = "No such student exists!!";
                textBox.Text = "";
            }

        }
    }
    }

