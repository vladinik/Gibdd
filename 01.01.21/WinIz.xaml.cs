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
    /// Логика взаимодействия для WinIz.xaml
    /// </summary>
    public partial class WinIz : Window
    {
        string path = "";
        public WinIz()
        {
            InitializeComponent();
        }
        private bool CheckEmail(string email)
        {
            if (email.IndexOf("@") > 0 && email.IndexOf(".") > 0)
            {
                if (email.Split('@')[1].Split('.').Length == 2)
                {
                    return true;
                }
            }
            return false;
        }
        private void ButtonIz_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;

            this.Close();
        }

        private void ButtonLoad_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }

        private void ButtonNaz_Click(object sender, RoutedEventArgs e)
        {
            WinDriver winVoditeli = new WinDriver();
            this.Hide();
            winVoditeli.Show();
        }
    }
}
