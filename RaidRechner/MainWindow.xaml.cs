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

namespace RaidRechner
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] raids = new string[] { "Raid 0", "Raid 1", " Raid 5", " Raid 6" };
        public MainWindow()
        {
            InitializeComponent();
            cb_Raid.ItemsSource = raids;
            cb_Raid.SelectedIndex = 2;

        }
       public void Btn_Main_Click(object sender, EventArgs e)
        {
            try
            {
                int anzahl = int.Parse(tb_anzahlFestplatten.Text);
                int größe = int.Parse(tb_festplattenGröße.Text);
                tb_Brutto.Text = (anzahl * größe).ToString();
                if(cb_Raid.SelectedIndex == 0)
                {
                    tb_Netto.Text = tb_Brutto.Text;
                }
                if(cb_Raid.SelectedIndex == 1)
                {
                    tb_Netto.Text = größe.ToString();
                }
                if (cb_Raid.SelectedIndex == 2 && anzahl >= 3)
                {
                    tb_Netto.Text = ((anzahl - 1) * größe).ToString();
                }
                else
                {
                    MessageBox.Show("Raid 5 braucht mindestens 3 Platten");
                }
                if (cb_Raid.SelectedIndex == 3 && anzahl >= 4)
                {
                    tb_Netto.Text = ((anzahl - 2) * größe).ToString();
                }
                else
                {
                    MessageBox.Show("Raid 6 braucht mindestens 4 Platten");
                }
            }
            catch (OverflowException)
            {
                MessageBox.Show("Ihr Ergebnis muss kleiner als 4 Milliarden sein");
            }
            catch (FormatException)
            {
                MessageBox.Show("Bitte geben Sie nur Zahlen ein und füllen Sie alle Felder");
            }
            catch (Exception)
            {
                MessageBox.Show("Unbekannter Fehler");
            }
        }
    }
}
