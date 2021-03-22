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
using System.Windows.Shapes;

namespace Gibdd
{
    /// <summary>
    /// Логика взаимодействия для WinVY.xaml
    /// </summary>
    public partial class WinVY : Window
    {
        public WinVY()
        {
            InitializeComponent();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            WinDriver winVoditeli = new WinDriver();
            this.Hide();
            winVoditeli.Show();
        }
    }
}
