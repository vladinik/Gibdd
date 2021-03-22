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
    /// Логика взаимодействия для WinVinTransports.xaml
    /// </summary>
    public partial class WinVinTransports : Window
    {
        string path = "";
        List<Drivers> drivers = new List<Drivers>();
        public WinVinTransports()
        {
            InitializeComponent();
            using (GIBDDContainer1 db = new GIBDDContainer1())
            {
                drivers.Clear();
                drivers = db.Drivers.ToList();
            }
        }

        private void ButtonZap_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxVinNumAvto.Text.Length != 0)
            {
                if (TextBoxMarka.Text.Length != 0)
                {
                    if (TextBoxModel.Text.Length != 0)
                    {
                        if (TextBoxTeipTransSred.Text.Length != 0 || TextBoxCategoriesTransSred.Text.Length != 0)
                        {
                            if (TextBoxGodV.Text.Length != 0 || TextBoxNumColor.Text.Length != 0)
                            {
                                if (TextBoxVesAvto.Text.Length != 0 || TextBoxTipDvig.Text.Length!=0)
                                {
                                    if (TextBoxVesAvtoKG.Text.Length != 0 || TextBoxTipPrivod.Text.Length !=0)
                                    {
                                        if (path != null)
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
                                                MessageBox.Show("Транспортное средство добавлено!");
                                            
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
    }
}
