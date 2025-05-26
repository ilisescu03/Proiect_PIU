using Proiect_PIU;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Targ_Auto;

namespace Targ_Auto_UI
{
    public partial class Form4 : Form
    {
        TranzactiiFisier tranzactii;
        RegistruFisier registru;
        CumparatoriFisier cumparatori;
        VanzatoriFisier vanzatori;
        public Form4()
        {
            InitializeComponent();

            tranzactii = new TranzactiiFisier("tranzactii.txt");

            cumparatori = new CumparatoriFisier("cumparatori.txt");
            vanzatori = new VanzatoriFisier("vanzatori.txt");
            registru = new RegistruFisier("registru.txt");

            InitializeComboBoxes();
            AfiseazaTranzactii();

        }
        private void btnAdauga_Click(object sender, EventArgs e)
        {
            if (txtCodTranzactie.Text == "") return;
            if (txtSuma.Text == "") return;
            if (cmbxCumparatori.Text == "") return;
            if (cmbxVanzatori.Text == "") return;
            if (cmbxRegistru.Text == "") return;   
            int codTranz=Int32.Parse(txtCodTranzactie.Text);
            float suma = float.Parse(txtSuma.Text);
            string cumparator=cmbxCumparatori.Text;
            string vanzator=cmbxVanzatori.Text;
            string data = dataPick.Text;
            string masina=cmbxRegistru.Text;
            Tranzactie tranz = new Tranzactie(codTranz, suma, cumparator, vanzator, data, masina);
            tranzactii.AdaugaTranzactie(tranz);
            AfiseazaTranzactii();
            ResetControls(this);
            List<Masina> masini = registru.GetMasini();
            foreach (Masina m in masini)
            {
                if (masina.Contains(m.GetID().ToString()))
                {
                    m.SetCumparator(cumparator);
                    m.SetVanzator(vanzator);

                }
            }
            registru.StergeTotDinFisier();
            foreach (Masina m in masini)
            {
                registru.AdaugaMasina(m);
            }

            lblWarning.Text = ""; // Golește mesajele anterioare

            var tranzactiiLista = tranzactii.GetTranzactii();

            // Verificare pentru vânzători
            var grupuriVanzatori = tranzactiiLista
                .GroupBy(t => new { Vanzator = t.get_Vanzator(), Data = t.get_dataTranzactie() })
                .Where(g => g.Count() > 1);

            foreach (var grup in grupuriVanzatori)
            {
                lblWarning.Text += $"Vanzatorul {grup.Key.Vanzator} are {grup.Count()} tranzactii in aceeasi zi ({grup.Key.Data})!\n";
            }

            // Verificare pentru cumpărători
            var grupuriCumparatori = tranzactiiLista
                .GroupBy(t => new { Cumparator = t.get_Cumparator(), Data = t.get_dataTranzactie() })
                .Where(g => g.Count() > 1);

            foreach (var grup in grupuriCumparatori)
            {
                lblWarning.Text += $"Cumparatorul {grup.Key.Cumparator} are {grup.Count()} tranzactii in aceeasi zi ({grup.Key.Data})!\n";
            }


        }
        private void btnCautare_Click(object sender, EventArgs e)
        {
            lstbxTranzactii.Items.Clear();
            List<Tranzactie> tranzactiiLista = tranzactii.GetTranzactii();
            RegistruFisier registru = new RegistruFisier("registru.txt");
            List<Masina> masini = registru.GetMasini();
            foreach (Tranzactie tranzactie in tranzactiiLista)
            {
                if(dataCauta.Text == tranzactie.get_dataTranzactie())
                {
                    string[] tranzactieText = tranzactie.Serialize().Split('|');

                    lstbxTranzactii.Items.Add("Cod tranzactie:" + tranzactieText[0]);
                    lstbxTranzactii.Items.Add("Suma:" + tranzactieText[1]);
                    lstbxTranzactii.Items.Add("Cumparator:" + tranzactieText[2]);
                    lstbxTranzactii.Items.Add("Vanzator:" + tranzactieText[3]);
                    lstbxTranzactii.Items.Add("Data:" + tranzactieText[4]);
                    lstbxTranzactii.Items.Add("Masina:" + tranzactieText[5]);
                    float profit = 0;
                    foreach (Masina m in masini)
                    {
                        if (tranzactieText[5].Contains(m.GetID().ToString()))
                        {
                            profit = float.Parse(tranzactieText[1]) - m.GetPret();
                            lstbxTranzactii.Items.Add("Pretul masinii:" + m.GetPret().ToString());
                        }
                    }
                    lstbxTranzactii.Items.Add("Profit:" + profit.ToString());
                    lstbxTranzactii.Items.Add(" ");
                    lstbxTranzactii.Items.Add(" ");
                }
            }
            
        }
        
        private void Stergere_Click(object sender, EventArgs e)
        {
            tranzactii.StergeTotDinFisier();
            AfiseazaTranzactii();
        }
        private void BackBtn_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }
        private void ResetControls(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Clear();
                }
                else if (control is ComboBox)
                {
                    ((ComboBox)control).SelectedIndex = -1; // nimic selectat
                }
                else if (control is CheckBox)
                {
                    ((CheckBox)control).Checked = false;
                }
                else if (control is RadioButton)
                {
                    ((RadioButton)control).Checked = false;
                }
                else if (control.HasChildren)
                {
                    // Recursiv, dacă controlul conține alte controale (ex: GroupBox, Panel etc.)
                    ResetControls(control);
                }
            }
        }
        private void InitializeComboBoxes()
        {

            foreach (Cumparator cumparator in cumparatori.GetCumparatori())
            {
                string codText = cumparator.getCodCumparator().ToString();
                string cumparatorText = cumparator.get_nume() + " " + cumparator.get_prenume() + " (" + codText + ")";
                if (!cmbxCumparatori.Items.Contains(cumparatorText))
                {
                    cmbxCumparatori.Items.Add(cumparatorText);
                }
            }
            foreach (Vanzator vanzator in vanzatori.GetVanzatori())
            {
                string codText = vanzator.getCodVanzator().ToString();
                string vanzatorText = vanzator.get_nume() + " " + vanzator.get_prenume() + " (" + codText + ")";
                if (!cmbxVanzatori.Items.Contains(vanzator.Serialize()))
                {
                    cmbxVanzatori.Items.Add(vanzatorText);
                }
            }
            foreach (Masina masina in registru.GetMasini())
            {
                string codText = masina.GetID().ToString();
                string masinaText= masina.GetMarca()+" "+masina.GetModel()+" ("+codText+")";
                if(!cmbxRegistru.Items.Contains(masina.Serialize()))
                {
                    cmbxRegistru.Items.Add(masinaText);
                }
            }

        }
        public void AfiseazaTranzactii()
        {
            List<Tranzactie> tranzactieList = tranzactii.GetTranzactii();
            lstbxTranzactii.Items.Clear();
            lstbxTranzactii.Items.Add("");
            RegistruFisier registru = new RegistruFisier("registru.txt");
            List<Masina> masini= registru.GetMasini();
            foreach (Tranzactie tr in tranzactieList)
            {
                string[] tranzactieText = tr.Serialize().Split('|');

                lstbxTranzactii.Items.Add("Cod tranzactie:" + tranzactieText[0]);
                lstbxTranzactii.Items.Add("Suma:" + tranzactieText[1]);
                lstbxTranzactii.Items.Add("Cumparator:" + tranzactieText[2]);
                lstbxTranzactii.Items.Add("Vanzator:" + tranzactieText[3]);
                lstbxTranzactii.Items.Add("Data:" + tranzactieText[4]);
                lstbxTranzactii.Items.Add("Masina:" + tranzactieText[5]);
                float profit = 0;
                foreach(Masina m in masini) 
                {
                    if (tranzactieText[5].Contains(m.GetID().ToString()))
                    {
                        profit = float.Parse(tranzactieText[1]) - m.GetPret();
                        lstbxTranzactii.Items.Add("Pretul masinii:" + m.GetPret().ToString());
                    }
                }
                lstbxTranzactii.Items.Add("Profit:" + profit.ToString());
                lstbxTranzactii.Items.Add(" ");
                lstbxTranzactii.Items.Add(" ");
                foreach (Masina m in masini)
                {
                    if (tranzactieText[5].Contains(m.GetID().ToString()))
                    {
                        m.SetCumparator(tranzactieText[2]);
                        m.SetVanzator(tranzactieText[3]);

                    }
                }
                registru.StergeTotDinFisier();
                foreach (Masina m in masini)
                {
                    registru.AdaugaMasina(m);
                }

            }

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
