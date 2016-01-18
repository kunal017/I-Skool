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
    public sealed partial class academicp : Page
    {
        private IMobileServiceTable<TodoItem> todoTable = App.MobileService.GetTable<TodoItem>();
        public academicp()
        {
            this.InitializeComponent();
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            var pstudent = await todoTable
                       .Where(t => t.username == e.Parameter.ToString()).ToCollectionAsync();
            if (pstudent[0].engp== 0 && pstudent[0].eng==false)
            {
                textBlock7.Text = "Not Registered";
            }
            else
            {
                textBlock7.Text = pstudent[0].engp + "";
            }
            if (pstudent[0].hinp == 0 && pstudent[0].hin == false)
            {
                textBlock8.Text = "Not Registered";
            }
            else
            {
                textBlock8.Text = pstudent[0].hinp + "";
            }
            if (pstudent[0].mathp == 0 && pstudent[0].math == false)
            {
                textBlock9.Text = "Not Registered";
            }
           else
            {
                textBlock9.Text = pstudent[0].mathp + "";
            }
            if (pstudent[0].scip == 0 && pstudent[0].sci == false)
            {
                textBlock10.Text = "Not Registered";
            }
           else
            {
                textBlock10.Text = pstudent[0].scip + "";
            }
            if (pstudent[0].ssp == 0 && pstudent[0].ss == false)
            {
                textBlock11.Text = "Not Registered";
            }
            else
            {
                textBlock11.Text = pstudent[0].ssp + "";
            }
            if (pstudent[0].csp == 0 && pstudent[0].cs == false)
            {
                textBlock12.Text = "Not Registered";
            }
            else
            {
                textBlock12.Text = pstudent[0].csp + "";
            }
        }
    }
}
