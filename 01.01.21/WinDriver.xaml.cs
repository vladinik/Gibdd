using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для WinDriver.xaml
    /// </summary>
    public partial class WinDriver : Window
    {
        List<Drivers> drivers = new List<Drivers>();
        string path;
        public WinDriver()
        {

            InitializeComponent();
            FillTable();
        }
        private void FillTable()
        {
            drivers.Clear();
            using (GIBDDContainer1 db = new GIBDDContainer1())
            {
                foreach (Drivers u in db.Drivers)
                    drivers.Add(u);
                DataGridVoditeli.ItemsSource = drivers;

            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            WinNewDriver dannie = new WinNewDriver();
            dannie.Show();
            this.Hide();
        }

        private void ButtonIz_Click(object sender, RoutedEventArgs e)
        {
            WinIz dobDriver = new WinIz();
            if (DataGridVoditeli.Items.Count > 0)
            {
                var index = DataGridVoditeli.SelectedItem;
                if (index != null)
                {
                    int id = int.Parse((DataGridVoditeli.SelectedCells[0].Column.GetCellContent(index) as TextBlock).Text);
                    using (GIBDDContainer1 db = new GIBDDContainer1())
                    {

                        Drivers driver = db.Drivers.Find(id);
                        dobDriver.TextBoxIden.Text = driver.Id.ToString();
                        dobDriver.TextBoxFam.Text = driver.Lastname;
                        dobDriver.TextBoxName.Text = driver.Name;
                        dobDriver.TextBoxMid.Text = driver.Middlename;
                        dobDriver.TextBoxSer.Text = driver.PassportSerial.ToString();
                        dobDriver.TextBoxNum.Text = driver.PassportNumber.ToString();
                        dobDriver.TextBoxReg.Text = driver.Address;
                        dobDriver.TextBoxPro.Text = driver.Address;
                        dobDriver.TextBoxRab.Text = driver.Company;
                        dobDriver.TextBoxDol.Text = driver.Jobname;
                        dobDriver.TextBoxPhone.Text = driver.Phone;
                        dobDriver.TextBoxEmail.Text = driver.Email;
                        string photo = "C:\\Users\\3курс\\Desktop\\мдк 01.01\\01.02\\GIBDD\\bin\\Debug\\photo\\" + driver.Photo;
                        dobDriver.TextBoxZam.Text = driver.Description;

                        if (dobDriver.ShowDialog().HasValue) return;

                        driver.Lastname = dobDriver.TextBoxFam.Text;
                        driver.Name = dobDriver.TextBoxName.Text;
                        driver.Middlename = dobDriver.TextBoxMid.Text;
                        driver.PassportSerial = int.Parse(dobDriver.TextBoxSer.Text);
                        driver.PassportNumber = int.Parse(dobDriver.TextBoxNum.Text);
                        driver.Address = dobDriver.TextBoxReg.Text;
                        driver.Address = dobDriver.TextBoxPro.Text;
                        driver.Company = dobDriver.TextBoxRab.Text;
                        driver.Jobname = dobDriver.TextBoxDol.Text;
                        driver.Phone = dobDriver.TextBoxPhone.Text;
                        driver.Email = dobDriver.TextBoxEmail.Text;
                        driver.Description = dobDriver.TextBoxZam.Text;
                        db.SaveChanges();
                    }
                }
                FillTable();

            }
        }
        int id;
        private void ButtonVY_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridVoditeli.Items.Count > 0)
            {
                var index = DataGridVoditeli.SelectedItem;
                if (index != null)
                    id = int.Parse((DataGridVoditeli.SelectedCells[0].Column.GetCellContent(index) as TextBlock).Text);
                WinVY winVY = new WinVY();
                using (GIBDDContainer1 db = new GIBDDContainer1())
                {
                    var licenses = db.Licences.First(p => p.idDriver == id);
                    winVY.TextBoxLic.Text = licenses.LicenceSeries;
                    winVY.TextBoxNumber.Text = licenses.LicenceNumber.ToString();
                    winVY.TextBoxExpire.Text = licenses.ExpireDate.ToString();
                    winVY.TextBoxVidan.Text = licenses.Issued;
                    winVY.TextBoxDate.Text = licenses.LicenceDate.ToString();
                    winVY.TextBoxVidan.Text = licenses.Issued;
                    winVY.TextBoxCity.Text = licenses.City;
                    if (!winVY.ShowDialog().HasValue) return;
                }
            }
        }

        private void ButtonDTP_Click(object sender, RoutedEventArgs e)
        {
            WinDTP dannie = new WinDTP();
            dannie.Show();
            this.Hide();
        }
    }
}

