using GUI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI.Views
{
    /// <summary>
    /// Interaction logic for WorkerView.xaml
    /// </summary>
    public partial class WorkerView : UserControl
    {
        public WorkerView()
        {
           
            InitializeComponent();
            if (StateManager.Current_user.Position.ToUpper() == "CASHIER")
            {
                Content = new CashierView();
            }
            else
            {
                Content = new ManagerView();
            }
        }
    }
}
