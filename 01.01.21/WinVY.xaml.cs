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
            
        }
        //public int id;
        

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            WinNewDriver dannie = new WinNewDriver();
            dannie.Show();
            this.Hide();
        }


       

        private void ButtonVY_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridVY.Items.Count > 0)
            {
                var index = DataGridVY.SelectedItem;
                if (index != null) ;
                int id = int.Parse((DataGridVY.SelectedCells[0].Column.GetCellContent(index) as TextBlock).Text);

                using (GIBDDContainer db = new GIBDDContainer())
                {

                    Licences drivers = db.Licences.Find(id);
                    var licenses = db.Licences.First(p => p.IdZapis == id);

                    TextBoxLic.Text = licenses.LicenceSeries;
                    TextBoxNumber.Text = licenses.LicenceNumber.ToString();
                    TextBoxExpire.Text = licenses.ExpireDate.ToString();
                    // TextBoxVidan.Text =
                    TextBoxDate.Text = licenses.LicenceDate.ToString();
                    TextBoxDriver.Text = licenses.idDriver.ToString(); ;
                    TextBoxCity.Text = licenses.City;
                    // TextBoxSurname.Text = drivers.Lastname;
                    TextBoxZapis.Text = licenses.IdZapis.ToString();
                    TextBoxCat.Text = licenses.Categories;
                    // TextBoxName.Text = drivers.Name;



                }

            }
        }

                private void ButtonDTP_Click(object sender, RoutedEventArgs e)
        {
            WinDTP winDTP = new WinDTP();
            winDTP.Show();
            this.Close();
        }

        private void ButtonChange_Click(object sender, RoutedEventArgs e)
        {
            //using (GIBDDContainer db = new GIBDDContainer())
            //{
            //    licenses.City = winVY.TextBoxCity.Text;
            //    licenses.LicenceNumber = winVY.TextBoxNumber.Text;
            //    licenses.LicenceSeries = winVY.TextBoxLic.Text;
            //    licenses.Issued = winVY.TextBoxVidan.Text;
            //    licenses.ExpireDate = DateTime.Parse(winVY.TextBoxExpire.Text);
            //    licenses.Categories = winVY.TextBoxCat.Text;
            //    licenses.LicenceDate = DateTime.Parse(winVY.TextBoxDate.Text);
            //    drivers.Lastname = winVY.TextBoxSurname.Text;
            //    licenses.LicenceNumber = winVY.TextBoxNumber.Text;
            //    drivers.Name = winVY.TextBoxName.Text;
            //    licenses.Categories = winVY.TextBoxCat.Text;
            //    winVY. = int.Parse(TextBoxDriver.Text);
            //    var lic = db.Licences.Find(id);

            //    db.SaveChanges();
            //}
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            WinDriver winVoditeli = new WinDriver();
            this.Hide();
            winVoditeli.Show();
        }
    }
}
