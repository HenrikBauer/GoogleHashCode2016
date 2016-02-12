using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hash2016
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Simulation.Run("../../Data/busy_day.in");
        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Simulation.Run("../../Data/mother_of_all_warehouses.in");
        }
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Simulation.Run("../../Data/redundancy.in");
        }
    }
}
