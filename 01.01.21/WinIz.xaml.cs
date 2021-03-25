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
            //{
            //    if (TextBoxFam.Text.Length != 0)
            //    {
            //        if (TextBoxName.Text.Length != 0)
            //        {
            //            if (TextBoxMid.Text.Length != 0)
            //            {
            //                if (TextBoxSer.Text.Length != 0 || TextBoxNum.Text.Length != 0)
            //                {
            //                    if (TextBoxReg.Text.Length != 0 || TextBoxPro.Text.Length != 0)
            //                    {
            //                        if (TextBoxPhone.Text.Length != 0)
            //                        {
            //                            if (TextBoxEmail.Text.Length != 0 && CheckEmail(TextBoxEmail.Text) == true)
            //                            {
            //                                if (path != null)
            //                                {
            //                                    using (GIBDDContainer db = new GIBDDContainer())
            //                                    {
            //                                        Drivers driver = db.Drivers.Find();
            //                                        driver.Id = int.Parse(TextBoxIden.Text);
            //                                        driver.Name = TextBoxName.Text;
            //                                        driver.Lastname = TextBoxFam.Text;
            //                                        driver.Middlename = TextBoxMid.Text;
            //                                        driver.PassportSerial = int.Parse(TextBoxSer.Text);
            //                                        driver.PassportNumber = int.Parse(TextBoxNum.Text);
            //                                        driver.Postcode = int.Parse(TextBoxIden.Text);
            //                                        driver.Address = TextBoxReg.Text;
            //                                        driver.AddressLife = TextBoxPro.Text;
            //                                        driver.Company = TextBoxRab.Text;
            //                                        driver.Jobname = TextBoxDol.Text;
            //                                        driver.Phone = TextBoxPhone.Text;
            //                                        driver.Email = TextBoxEmail.Text;
            //                                        driver.Description = TextBoxZam.Text;
            //                                        driver.Photo = path.Substring(path.LastIndexOf("\\") + 1);
            //                                        db.SaveChanges();
            //                                        MessageBox.Show("Полььзователь зарегестрирован");
            //                                    }
            //                                }
            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
        }

        private void ButtonLoad_Click(object sender, RoutedEventArgs e)
        {
            //DialogResult = true;
            //this.Close();
        }

        private void ButtonNaz_Click(object sender, RoutedEventArgs e)
        {
            //DialogResult = false;
            //this.Close();
        }
    }
}
