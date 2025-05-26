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

namespace Targ_Auto_UI
{
    public partial class Form2 : Form
    {
        VanzatoriFisier vanzatori;
        CumparatoriFisier cumparatori;
        public Form2()
        {
            InitializeComponent();
            vanzatori = new VanzatoriFisier("vanzatori.txt"); // presupunem un fișier
            cumparatori = new CumparatoriFisier("cumparatori.txt");
            
            AfiseazaPersoane();
        }
        private void AfiseazaPersoane()
        {
            listBox1.Items.Clear(); // golim listbox-ul

            List<Vanzator> listaVanzatori = vanzatori.GetVanzatori();
            List<Cumparator> listaCumparatori= cumparatori.GetCumparatori();

            listBox1.Items.Add("---------------Vanzatori---------------");
            listBox1.Items.Add("");
            foreach (Vanzator v in listaVanzatori)
            {
                string linie = v.Serialize();
                string[] serializedLinie = linie.Split('|');

                listBox1.Items.Add("Cod vanzator: "+serializedLinie[5]);
                listBox1.Items.Add("Nume si Prenume: " + serializedLinie[0] + " " + serializedLinie[1]);
                listBox1.Items.Add("Adresa:" + serializedLinie[2]);
                listBox1.Items.Add("Telefon:" + serializedLinie[3]);
                listBox1.Items.Add("E-mail:" + serializedLinie[4]);
                listBox1.Items.Add("");
                listBox1.Items.Add("");

            }

            listBox1.Items.Add("---------------Cumparatori---------------");
            listBox1.Items.Add("");

            foreach (Cumparator c in listaCumparatori)
            {
                string linie = c.Serialize();
                string[] serializedLinie = linie.Split('|');
         
                listBox1.Items.Add("Cod cumparator: " + serializedLinie[5]);
                listBox1.Items.Add("Nume si Prenume: " + serializedLinie[0] + " " + serializedLinie[1]);
                listBox1.Items.Add("Adresa:" + serializedLinie[2]);
                listBox1.Items.Add("Telefon:" + serializedLinie[3]);
                listBox1.Items.Add("E-mail:" + serializedLinie[4]);
                listBox1.Items.Add("");
                listBox1.Items.Add("");
            }
        }
        private void BackBtn_Click(object sender, EventArgs e)
        {
            Form3 form3= new Form3();
            form3.Show();
            this.Hide();
        }
        private void Stergere_Click(object sender, EventArgs e)
        {
            vanzatori.StergeTotDinFisier();
            cumparatori.StergeTotDinFisier();
            AfiseazaPersoane();
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
            Cumparator cumparator = CautaCumparatorDupaCod(id);
            Vanzator vanzator = CautaVanzatorDupaCod(id);
            if(cumparator == null&&vanzator==null)
            {
                MessageBox.Show("Nu a fost gasita persoana cu acest cod!!");
                ResetControls(this);
                return;
            }
            if(cumparator!=null&&vanzator==null)
            {
                MessageBox.Show(
                 
                   "Cumparator:\n"+
                   $"Cod Cumparator: {cumparator.getCodCumparator()}\n" +
                   $"Nume si Prenume: {cumparator.get_nume()} + {cumparator.get_prenume()}\n" +
                   $"Adresa: {cumparator.get_adresa()}\n" +
                   $"Nr. telefon: {cumparator.get_telefon().ToString()}\n" +
                   $"E-mail: {cumparator.get_email()}\n",
                   "Persoana Gasita",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information
               );
                ResetControls(this);
                return;
            }
            if (cumparator == null && vanzator != null)
            {
                MessageBox.Show(

                   "Vanzator:\n" +
                   $"Cod Vanzator: {vanzator.getCodVanzator()}\n" +
                   $"Nume si Prenume: {vanzator.get_nume()} + {vanzator.get_prenume()}\n" +
                   $"Adresa: {vanzator.get_adresa()}\n" +
                   $"Nr. telefon: {vanzator.get_telefon().ToString()}\n" +
                   $"E-mail: {vanzator.get_email()}\n",
                   "Persoana Gasita",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information
               );
                ResetControls(this);
                return;
            }

        }
        private void CheckFormsAndExit(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Count == 0)
            {
                Application.Exit();
            }
        }
        private Cumparator CautaCumparatorDupaCod(int value)
        {
            List<Cumparator> _cumparatori = cumparatori.GetCumparatori();
            foreach (var cumparator in _cumparatori)
            {
                if (cumparator.getCodCumparator() == value)
                {
                    return cumparator;
                }
            }
            return null;
        }
        private Vanzator CautaVanzatorDupaCod(int value)
        {
            List<Vanzator> _vanzatori = vanzatori.GetVanzatori();
            foreach (var vanzator in _vanzatori)
            {
                if (vanzator.getCodVanzator() == value)
                {
                    return vanzator;
                }
            }
            return null;
        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            // Cod pentru adăugarea unei persoane (opțional)
            if (cmboxTipPersoana.SelectedIndex == -1) return;
            if (txtNume.Text == "") return;
            if (txtPrenume.Text == "") return;
            if (txtAdresa.Text == "") return;
            if (txtTelefon.Text == "") return;
            if (txtEmail.Text == "") return;
            if (txtCod.Text == "") return;
            string tipClient = cmboxTipPersoana.Text;
            string nume = txtNume.Text;
            string prenume = txtPrenume.Text;
            string adresa = txtAdresa.Text;
            int telefon = Int32.Parse(txtTelefon.Text);
            string email = txtEmail.Text;
            int cod = Int32.Parse(txtCod.Text);
            if (tipClient == "Vanzator")
            {
                Vanzator v = new Vanzator(nume, prenume, adresa, telefon, email, cod);
                vanzatori.AdaugaVanzator(v);
            }
            if (tipClient == "Cumparator")
            {
                Cumparator c = new Cumparator(nume, prenume, adresa, telefon, email, cod);
                cumparatori.AdaugaCumparator(c);
            }
            
            AfiseazaPersoane(); // reîmprospătăm afișarea
            ResetControls(this);
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
        private void Titlu_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
