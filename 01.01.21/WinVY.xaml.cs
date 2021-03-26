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
using System.IO;
using System.Reflection;
using Microsoft.Win32;
namespace Gibdd
{
    /// <summary>
    /// Логика взаимодействия для WinVY.xaml
    /// </summary>
    public partial class WinVY : Window
    {
        List<Drivers> drivers = new List<Drivers>();
        string path = "";
        public WinVY()
        {
            InitializeComponent();
            FillTable();
        }
        //public int id;
        private void FillTable()
        {
            drivers.Clear();
            using (GIBDDContainer db = new GIBDDContainer())
            {
                foreach (Drivers u in db.Drivers)
                    drivers.Add(u);
                DataGridLic1.ItemsSource = db.Drivers.Local.ToBindingList();
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            WinNewDriver dannie = new WinNewDriver();
            dannie.Show();
            this.Hide();
        }


        private void ButtonChange_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridLic1.Items.Count > 0)
            {
                var index = DataGridLic1.SelectedItem;
                if (index != null) ;
                int id = int.Parse((DataGridLic1.SelectedCells[0].Column.GetCellContent(index) as TextBlock).Text);
                WinNewDriver winDobav = new WinNewDriver();
                using (GIBDDContainer db = new GIBDDContainer())
                {
                    Drivers drivers = db.Drivers.Find(id);
                    winDobav.TextBoxFam.Text = drivers.Lastname;
                    winDobav.TextBoxName.Text = drivers.Name;
                    winDobav.TextBoxMid.Text = drivers.Middlename;
                    winDobav.TextBoxDol.Text = drivers.Jobname;
                    winDobav.TextBoxSer.Text = drivers.PassportSerial.ToString();
                    winDobav.TextBoxPhone.Text = drivers.Phone;
                    winDobav.TextBoxNum.Text = drivers.PassportNumber.ToString();
                    winDobav.TextBoxReg.Text = drivers.Address;
                    winDobav.TextBoxPro.Text = drivers.AddressLife;
                    winDobav.TextBoxRab.Text = drivers.Company;
                    winDobav.TextBoxDol.Text = drivers.Jobname;
                    winDobav.TextBoxEmail.Text = drivers.Email;
                    winDobav.TextBoxZam.Text = drivers.Description;
                    //winDobav.TextBoxIden.Text = drivers.;
                    string path = Assembly.GetExecutingAssembly().Location.ToString();
                    string photo = path.Substring(0, path.LastIndexOf("\\")) + "\\photo\\" + drivers.Photo;
                    //winDobav.IImagePfoto.Source = new BitmapImage(new Uri(photo));
                    //drivers.Photo = winDobav.Path.Substring(winDobav.Path.LastIndexOf("\\") + 1);
                    if (!winDobav.ShowDialog().HasValue) return;
                    drivers.Lastname = winDobav.TextBoxFam.Text;
                    drivers.Name = winDobav.TextBoxName.Text;
                    drivers.Middlename = winDobav.TextBoxMid.Text;
                    drivers.Jobname = winDobav.TextBoxDol.Text;
                    drivers.PassportSerial = int.Parse(winDobav.TextBoxSer.Text);
                    drivers.Phone = winDobav.TextBoxPhone.Text;
                    drivers.PassportNumber = int.Parse(winDobav.TextBoxNum.Text);
                    drivers.Address = winDobav.TextBoxReg.Text;
                    drivers.AddressLife = winDobav.TextBoxPro.Text;
                    drivers.Company = winDobav.TextBoxRab.Text;
                    drivers.Jobname = winDobav.TextBoxDol.Text;
                    drivers.Email = winDobav.TextBoxEmail.Text;
                    drivers.Description = winDobav.TextBoxZam.Text;
                    drivers.Postcode = int.Parse(winDobav.TextBoxIden.Text);




                    db.SaveChanges();
                }
                FillTable();

            }
        }

        private void ButtonVY_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridLic1.Items.Count > 0)
            {
                var index = DataGridLic1.SelectedItem;
                if (index != null) ;
                int id = int.Parse((DataGridLic1.SelectedCells[0].Column.GetCellContent(index) as TextBlock).Text);
                WinVY winVY = new WinVY();
                using (GIBDDContainer db = new GIBDDContainer())
                {

                    Drivers drivers = db.Drivers.Find(id);
                    var licenses = db.Licences.First(p => p.idDriver == id);

                    winVY.TextBoxLic.Text = licenses.LicenseSeries;
                    winVY.TextBoxNumber.Text = licenses.licenceNumber.ToString();
                    winVY.TextBoxExpire.Text = licenses.expireDate.ToString();
                    winVY.TextBoxVidan.Text =
                    winVY.TextBoxDate.Text = licenses.licenceDate.ToString();
                    winVY.TextBoxDriver.Text = licenses.IdDriver.ToString(); ;
                    winVY.TextBoxCity.Text = licenses.City;
                    winVY.TextBoxSurname.Text = drivers.Lastname;
                    winVY.TextBoxZapis.Text = licenses.IdZapis.ToString();
                    winVY.TextBoxCat.Text = licenses.categories;
                    winVY.TextBoxName.Text = drivers.Name;
                    if (!winVY.ShowDialog().HasValue) return;

                    licenses.City = winVY.TextBoxCity.Text;
                    licenses.licenceNumber = winVY.TextBoxNumber.Text;
                    licenses.LicenseSeries = winVY.TextBoxLic.Text;
                    licenses.Vidano = winVY.TextBoxVidan.Text;
                    licenses.expireDate = DateTime.Parse(winVY.TextBoxExpire.Text);
                    licenses.categories = winVY.TextBoxCat.Text;
                    licenses.licenceDate = DateTime.Parse(winVY.TextBoxDate.Text);
                    drivers.Lastname = winVY.TextBoxSurname.Text;
                    licenses.licenceNumber = int.Parse(winVY.TextBoxNumber.Text);
                    drivers.Name = winVY.TextBoxName.Text;
                    licenses.categories = winVY.TextBoxCat.Text;
                    winVY.Id =int.Parse (TextBoxDriver.Text);
                    var lic = db.Licences.Find(id);

                    db.SaveChanges();

                }
                FillTable();
            }
        }

        private void ButtonDTP_Click(object sender, RoutedEventArgs e)
        {
            WinDTP winDTP = new WinDTP();
            winDTP.Show();
            this.Close();
        }
    }
}
