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
    /// Логика взаимодействия для WinDTP.xaml
    /// </summary>
    public partial class WinDTP : Window
    {
        List<Drivers> drivers = new List<Drivers>();
        string path;
        public WinDTP()
        {
            InitializeComponent();
            FillTable();
        }
        private void FillTable()
        {
            drivers.Clear();
            using (GIBDDContainer1 db = new GIBDDContainer1())
            {
                foreach (Transport t in db.Transport )
                    drivers.Add(t);
                DataGridDTP.ItemsSource = drivers;

            }
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            var index = DataGridDTP.SelectedItem;
            WinDTP winTransports = new WinDTP();
            if (index != null)
            {

                this.Hide();
                int id = int.Parse((DataGridDTP.SelectedCells[0].Column.GetCellContent(index) as TextBlock).Text);
                using (GIBDDContainer1 db = new GIBDDContainer1())
                {
                    var transport = db.Transport.Join(db.Manufacture, p => p.Manufacturer, c => c.Id, (p, c) => new { Vin = p.VIN, IdDriver = p.IdDriver, Manufacture = c.Name, Model = p.Model, Year = p.Year, Weight = p.Weight }).ToList();
                    winTransports.DataGridDTP.ItemsSource = transport;
                    Transport driver = db.Transport.Find(id);
                    winTransports.Show();
                }
            }
        }

        private void Button_Click_Naz(object sender, RoutedEventArgs e)
        {
            WinDriver winVoditeli = new WinDriver();
            this.Hide();
            winVoditeli.Show();
        }
    }
}
