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
using System.Data.Entity;
using Microsoft.Win32;
using System.Reflection;
using System.IO;

namespace Gibdd
{
    /// <summary>
    /// Логика взаимодействия для WinNewDriver.xaml
    /// </summary>
    public partial class WinNewDriver : Window
    {
        string path = "";
        List<Drivers> drivers = new List<Drivers>();
        public WinNewDriver()
        {
            InitializeComponent();
            using (GIBDDContainer1 db = new GIBDDContainer1())
            {
                drivers.Clear();
                drivers = db.Drivers.ToList();
            }
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
        private void ButtonZap_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxFam.Text.Length != 0)
            {
                if (TextBoxName.Text.Length != 0)
                {
                    if (TextBoxMid.Text.Length != 0)
                    {
                        if (TextBoxSer.Text.Length != 0 || TextBoxNum.Text.Length != 0)
                        {
                            if (TextBoxReg.Text.Length != 0 || TextBoxPro.Text.Length != 0)
                            {
                                if (TextBoxPhone.Text.Length != 0)
                                {
                                    if (TextBoxEmail.Text.Length != 0 && CheckEmail(TextBoxEmail.Text) == true)
                                    {
                                        if (path != null)
                                        {
                                            using (GIBDDContainer1 db = new GIBDDContainer1())
                                            {
                                                Drivers driver = new Drivers();
                                                driver.Id = int.Parse(TextBoxIden.Text);
                                                driver.Name = TextBoxName.Text;
                                                driver.Lastname = TextBoxFam.Text;
                                                driver.Middlename = TextBoxMid.Text;
                                                driver.PassportSerial = int.Parse(TextBoxSer.Text);
                                                driver.PassportNumber = int.Parse(TextBoxNum.Text);
                                                driver.Postcode = int.Parse(TextBoxIden.Text);
                                                driver.Address = TextBoxReg.Text;
                                                driver.AddressLife = TextBoxPro.Text;
                                                driver.Company = TextBoxRab.Text;
                                                driver.Jobname = TextBoxDol.Text;
                                                driver.Phone = TextBoxPhone.Text;
                                                driver.Email = TextBoxEmail.Text;
                                                driver.Description = TextBoxZam.Text;
                                                driver.Photo = path.Substring(path.LastIndexOf("\\") + 1);
                                                db.Drivers.Add(driver);
                                                db.SaveChanges();
                                                MessageBox.Show("Пользователь зарегестрирован");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private void ButtonNaz_Click(object sender, RoutedEventArgs e)
        {
            WinDriver winVoditeli = new WinDriver();
            this.Hide();
            winVoditeli.Show();
        }
        private void ButtonLoad_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.BMP, *.JPG, *.PNG)|*.bmp;*.jpg;*.png;*";
            if (dialog.ShowDialog() == true)
            {
                path = dialog.FileName;
                ImagePfoto.Stretch = Stretch.Uniform;
                ImagePfoto.Source = new BitmapImage(new Uri(path));
            }
            string path2 = Assembly.GetExecutingAssembly().Location.ToString();
            File.Copy(path, path2.Substring(0, path2.LastIndexOf("\\")) + "\\photo\\" + path.Substring(path.LastIndexOf("\\") + 1), true);
        }
    }
}

