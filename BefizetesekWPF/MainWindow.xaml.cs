using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace BefizetesekWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Befizetes> befizetesek = new List<Befizetes>();

        public MainWindow()
        {
            InitializeComponent();
            BeolvasAllmanybol("Befizetesek.txt");
            befizetesek.Add(new Befizetes()
            {
                Nev = "Gonzó",
                Osszeg = 4000
            });
            MegjelenitBefizetes(0);
            for (int i = 0; i < befizetesek.Count; i++)
            {
                tbkBefizetesek.Text += befizetesek[i] + "\n";
            }
            for (int i = 0; i < befizetesek.Count; i++)
            {
                cbxSorszam.Items.Add(i.ToString());
                cbxNev.Items.Add(befizetesek[i].Nev);
            }
            //cbxNev.Items.Clear();
            //cbxNev.Items.Add("Béla");
            //cbxNev.Items.Add("Irénke");
            cbxNev.Items.Add("Pimpike");

        }

        private void MegjelenitBefizetes(int sorszam)
        {
            lblNev.Content = befizetesek[sorszam].Nev;
            tbxOsszeg.Text = befizetesek[sorszam].Osszeg.ToString();
        }

        public void BeolvasAllmanybol(string allomanyNev)
        {
            string[] sorok = File.ReadAllLines(allomanyNev).Skip(1).ToArray();
            foreach (string sor in sorok)
            {
                befizetesek.Add(new Befizetes(sor));
            }
        }

        private void SorszamValasztva(object sender, SelectionChangedEventArgs e)
        {
            int valsztottSorszam = int.Parse(cbxSorszam.SelectedItem.ToString());
            MegjelenitBefizetes(valsztottSorszam);
        }

        private void cbxNev_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbxNev.SelectedIndex != -1)
            {
                Befizetes valasztott = befizetesek.FirstOrDefault(bf => bf.Nev == cbxNev.SelectedItem.ToString());
                if (valasztott != null)
                    MegjelenitBefizetes(befizetesek.IndexOf(valasztott));
                else
                    MessageBox.Show("Nincs ilyen nevű befizető!");
            }
            else
                MessageBox.Show("Nincs kiválasztott elem!");
        }

        //private void KeresesAlap(object sender, SelectionChangedEventArgs e)
        //{
        //    string valasztottNev = cbxNev.SelectedItem.ToString();

        //    int index = 0;
        //    while (index < befizetesek.Count && befizetesek[index].Nev != valasztottNev)
        //    {
        //        index++;
        //    }
        //    if(index < befizetesek.Count)
        //    {
        //        MegjelenitBefizetes(index);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Nincs megfelelő befizető!");
        //    }
        //}
    }
}