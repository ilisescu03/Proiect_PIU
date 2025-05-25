using Proiect_PIU;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Targ_Auto;

namespace Targ_Auto_UI
{
    public partial class Form5: Form
    {
        TranzactiiFisier tranzactii;
        RegistruFisier registru;
        
        public Form5()
        {
            tranzactii = new TranzactiiFisier("tranzactii.txt");
            registru = new RegistruFisier("registru.txt");
            InitializeComponent();
            
        }
        private void BackBtn_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }
        public void DisplayBtn_Click(object sender, EventArgs e)
        {
            lstBox.Items.Clear();
            List<Tranzactie> tranzactiiLista = tranzactii.GetTranzactii();
            List<Masina> masini = registru.GetMasini();
            foreach (Tranzactie tranzactie in tranzactiiLista)
            {
                foreach (Masina masina in masini) {
                    if (tranzactie.get_Masina().Contains(masina.GetID().ToString()))
                    {
                        lstBox.Items.Add("ID: " + masina.GetID());
                        lstBox.Items.Add("Marca: " + masina.GetMarca());
                        lstBox.Items.Add("Model: " + masina.GetModel());
                        lstBox.Items.Add("Culoare: " + masina.GetCuloare());
                        lstBox.Items.Add("An Fabricatie: " + masina.GetAnFabricatie());
                        lstBox.Items.Add("Optiuni: " + string.Join(", ", masina.GetOptiuni().Cast<string>()));
                        lstBox.Items.Add("Pret: " + masina.GetPret());
                        lstBox.Items.Add("Vanzator: "+ masina.GetVanzator());
                        lstBox.Items.Add("Cumparator: " + masina.GetCumparator());
                        lstBox.Items.Add("Data tranzactie: "+tranzactie.get_dataTranzactie());

                        lstBox.Items.Add(" ");

                    }
                }
            }
        }
        private void btnCauta_Click(object sender, EventArgs e)
        {
            lstBox.Items.Clear();

            string dataStart = dtStart1.Text;
            string dataEnd = dtEnd1.Text;

            List<Tranzactie> tranzactiiLista = tranzactii.GetTranzactii();
            List<Masina> masini = registru.GetMasini();

            Dictionary<string, int> numarariModele = new Dictionary<string, int>();

            foreach (Tranzactie t in tranzactiiLista)
            {
                string dataTranzactie = t.get_dataTranzactie();

                // Comparam ca string-uri: formatul trebuie să fie uniform (de ex. "dd.MM.yyyy")
                if (String.Compare(dataTranzactie, dataStart) >= 0 && String.Compare(dataTranzactie, dataEnd) <= 0)
                {
                    string idTranzactie = t.get_Masina();

                    foreach (Masina m in masini)
                    {
                        if (idTranzactie.Contains(m.GetID().ToString()))
                        {
                            string model = m.GetModel();

                            if (numarariModele.ContainsKey(model))
                                numarariModele[model]++;
                            else
                                numarariModele[model] = 1;

                            break; // am găsit mașina, nu mai căutăm
                        }
                    }
                }
            }

            if (numarariModele.Count == 0)
            {
                lstBox.Items.Add("Nu există tranzacții în perioada selectată.");
                return;
            }

            string modelCautat = null;
            int maxAparitii = 0;

            foreach (var pereche in numarariModele)
            {
                if (pereche.Value > maxAparitii)
                {
                    maxAparitii = pereche.Value;
                    modelCautat = pereche.Key;
                }
            }

            lstBox.Items.Add($"Cel mai vândut model între {dataStart} și {dataEnd}:");
            lstBox.Items.Add(modelCautat);
            lstBox.Items.Add($"Număr tranzacții: {maxAparitii}");
        }

        private void dtEnd_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dtStart_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblNume_Click(object sender, EventArgs e)
        {

        }
    }
}
