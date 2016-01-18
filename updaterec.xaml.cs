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
    public sealed partial class updaterec : Page
    {
        private IMobileServiceTable<TodoItem> todoTable = App.MobileService.GetTable<TodoItem>();
        public updaterec()
        {
            this.InitializeComponent();
        }
        String s = "";
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            s = e.Parameter.ToString();
            //pstudent[0].attendance = Int32.Parse(textBox1.Text); 
        }
        private async void update(object sender, RoutedEventArgs e)
        {
            var pstudent = await todoTable
                       .Where(t => t.username == s).ToCollectionAsync();
            pstudent[0].attendance = int.Parse(textBox1.Text);
            String tt = comboBox.Items[comboBox.SelectedIndex].ToString();
            if (tt.Equals("English"))
                pstudent[0].engp = int.Parse(textBox.Text);
            else if (tt.Equals("Hindi"))
                pstudent[0].hinp = int.Parse(textBox.Text);
            else if (tt.Equals("Maths"))
                pstudent[0].mathp = int.Parse(textBox.Text);
            else if (tt.Equals("Science"))
                pstudent[0].scip = int.Parse(textBox.Text);
            else if (tt.Equals("Social Science"))
                pstudent[0].ssp = int.Parse(textBox.Text);
            else
                pstudent[0].csp = int.Parse(textBox.Text);

            await todoTable.UpdateAsync(pstudent[0]);
            this.Frame.Navigate(typeof(MainPage), null);
        }
    }
}
