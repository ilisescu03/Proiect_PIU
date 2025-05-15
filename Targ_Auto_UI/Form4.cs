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

        }
        private void btnCautare_Click(object sender, EventArgs e)
        {
            if (txtCautare == null || string.IsNullOrWhiteSpace(txtCautare.Text))
            {
                MessageBox.Show("Introduceti un cod valid!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetControls(this);
                return;
            }

            if (!int.TryParse(txtCautare.Text, out int id))
            {
                MessageBox.Show("codul trebuie sa fie un numar!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetControls(this);
                return;
            }
            Tranzactie tranzactie = CautaTranzactieDupaCod(id);
            
            if (tranzactie == null)
            {
                MessageBox.Show("Nu a fost gasita persoana cu acest cod!!");
                ResetControls(this);
                return;
            }
            else { 
                MessageBox.Show(

                   "Tranzactie:\n" +
                   $"Cod tranzactie: {tranzactie.getCod()}\n" +
                   $"Suma: {tranzactie.get_suma()}\n" +
                   $"Cumparator: {tranzactie.get_Cumparator()}\n" +
                   $"Vanzator: {tranzactie.get_Vanzator()}\n" +
                   $"Data: {tranzactie.get_dataTranzactie()}\n"+
                   $"Masina: {tranzactie.get_Masina()}\n",
                   "Tranzactie Gasita",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information
               );
                ResetControls(this);
                return;
            }
            
        }
        private Tranzactie CautaTranzactieDupaCod(int value)
        {
            List<Tranzactie> tranzactiiLista = tranzactii.GetTranzactii();
            foreach (Tranzactie tranzactie in tranzactiiLista)
            {
                if (tranzactie.getCod() == value)
                {
                    return tranzactie;
                }
            }
            return null;
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

            }

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
