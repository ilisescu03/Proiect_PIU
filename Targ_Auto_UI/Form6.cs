using Proiect_PIU;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Targ_Auto;

namespace Targ_Auto_UI
{
    public partial class Form6 : Form
    {
        TranzactiiFisier tranzactii;
        RegistruFisier registru;

        public Form6()
        {
            InitializeComponent();

            tranzactii = new TranzactiiFisier("tranzactii.txt");
            registru = new RegistruFisier("registru.txt");

            chartTranzactii.Series.Clear();
            chartTranzactii.ChartAreas[0].AxisX.Title = "Model mașină";
            chartTranzactii.ChartAreas[0].AxisY.Title = "Număr tranzacții";
        }

        private void btnAfiseazaGrafic_Click(object sender, EventArgs e)
        {
            string dataStart = dtStart.Text;
            string dataEnd = dtEnd.Text;

            List<Tranzactie> tranzactiiLista = tranzactii.GetTranzactii();
            List<Masina> masini = registru.GetMasini();

            Dictionary<string, int> frecventaModele = new Dictionary<string, int>();

            foreach (Tranzactie t in tranzactiiLista)
            {
                string dataTranzactie = t.get_dataTranzactie();

                if (String.Compare(dataTranzactie, dataStart) >= 0 && String.Compare(dataTranzactie, dataEnd) <= 0)
                {
                    string idMasina = t.get_Masina();

                    foreach (Masina m in masini)
                    {
                        if (idMasina.Contains(m.GetID().ToString()))
                        {
                            string model = m.GetModel();
                            if (frecventaModele.ContainsKey(model))
                                frecventaModele[model]++;
                            else
                                frecventaModele[model] = 1;

                            break;
                        }
                    }
                }
            }

            // Reset chart
            chartTranzactii.Series.Clear();

            Series serie = new Series("Tranzacții")
            {
                ChartType = SeriesChartType.Column
            };

            foreach (var pereche in frecventaModele)
            {
                serie.Points.AddXY(pereche.Key, pereche.Value);
            }

            chartTranzactii.Series.Add(serie);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }
    }
}
