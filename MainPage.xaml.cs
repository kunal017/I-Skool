using App2.dataModel;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App2
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
        private void register_new(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BasicPage), null);
        }
       // private MobileServiceTableQuery<TodoItem4 ,TodoItem4> pass;
        private IMobileServiceTable<TodoItem4> todoTable = App.MobileService.GetTable<TodoItem4>();

        
        private async void login(object sender, RoutedEventArgs e)
        {
            try {
                var pass = await todoTable
                        .Where(t => t.username == textBox.Text).ToCollectionAsync();
                String s = pass[0].password;
                if (passwordBox.Password.Equals(s))
                {
                    if (pass[0].value.Equals("Student"))
                        this.Frame.Navigate(typeof(loginstudent), pass[0].username);
                    else if (pass[0].value.Equals("Parent"))
                        this.Frame.Navigate(typeof(loginparent), pass[0].username);
                    else this.Frame.Navigate(typeof(loginfaculty), pass[0].username);
                }
                else
                {
                    textBox4.Text = "Invalid Username or Password";
                    passwordBox.Password = "";
                }
            }
            catch(Exception)
            {
                textBox4.Text = "User doesn't exists";
                passwordBox.Password = "";
            }
            
        }
        private void forget_password(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            b.Foreground = new SolidColorBrush(Windows.UI.Colors.DarkRed);
            //this.Frame.Navigate(typeof(BasicPage), null);
        }
    }
}
