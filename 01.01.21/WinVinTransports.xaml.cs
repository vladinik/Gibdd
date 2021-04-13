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
            using (GIBDDContainer1 db = new GIBDDContainer1())
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
                                    if (TextBoxVesAvto.Text.Length != 0 || TextBoxTipDvig.Text.Length != 0)
                                    {
                                        if (TextBoxVesAvtoKG.Text.Length != 0 || TextBoxTipPrivod.Text.Length != 0)
                                        {
                                            if (path != null)
                                            {


                                                Transport transport = new Transport();
                                                Licences licences = new Licences();
                                                transport.Vin = TextBoxVinNumAvto.Text;
                                                transport.Manufacturer = int.Parse(TextBoxMarka.Text);
                                                transport.Model = TextBoxModel.Text;
                                                transport.TypeTS = TextBoxTeipTransSred.Text;
                                                licences.Categories = TextBoxCategoriesTransSred.Text;
                                                transport.Year = int.Parse(TextBoxGodV.Text);
                                                transport.EngineNumber = TextBoxNumDvig.Text;
                                                transport.ModelEngine = TextBoxModelDvig.Text;
                                                transport.YearEngine = TextBoxGodDvig.Text;
                                                transport.Color = int.Parse(TextBoxNumColor.Text);
                                                transport.ModelEngineKvt = TextBoxMoDvigKvt.Text;
                                                transport.ModelEngineLoSi = TextBoxMoDvigLoSi.Text;
                                                transport.MacsNag = TextBoxMacsNag.Text;
                                                transport.Weight = int.Parse(TextBoxVesAvto.Text);
                                                transport.EngineType = int.Parse(TextBoxTipDvig.Text);
                                                transport.VesAvtoKG = TextBoxVesAvtoKG.Text;
                                                transport.TypeOfDrive = TextBoxTipPrivod.Text;
                                                transport.Comment = TextBoxComment.Text;
                                                transport.Vlad = TextBoxVlad.Text;
                                                db.Transport.Add(transport);
                                                db.SaveChanges();
                                                db.Licences.Add(licences);
                                                db.SaveChanges();
                                                MessageBox.Show("Заполнено!");

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
