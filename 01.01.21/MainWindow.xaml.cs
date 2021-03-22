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

namespace Gibdd
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxLog.Text.Length == 0)
            {
                MessageBox.Show("Введите логин");
            }
            if (PasswordBoxPas.Password.Length == 0)
            {
                MessageBox.Show("Введите пароль");
            }

            if (TextBoxLog.Text != "inspector" || PasswordBoxPas.Password != "inspector")
            {
                MessageBox.Show("Вы ввели неверный пароль или логин. Попробуйте занова.");

            }
            else
            {
                WinDriver newGIBDD = new WinDriver();
                this.Hide();
                newGIBDD.ShowDialog();
            }
        }
    }
}
