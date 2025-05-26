using System;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Targ_Auto;
using System.Windows.Forms;
using Proiect_PIU;
using System.IO;
namespace Targ_Auto_UI
{

    public partial class Form1 : Form
    {
        RegistruFisier registru;




        ArrayList optiuniSelectate = new ArrayList();
        public Form1()
        {

            InitializeComponent();
            //  string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            // string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            // setare locatie fisier in directorul corespunzator solutiei
            // astfel incat datele din fisier sa poata fi utilizate si de alte proiecte
            //  string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;

            registru = new RegistruFisier("registru.txt");







            AfiseazaRegistru();

        }
       
        private void BackBtn_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }
        
        private void Stergere_Click(object sender, EventArgs e)
        {
            registru.StergeTotDinFisier();
            AfiseazaRegistru();
        }
        private void CheckFormsAndExit(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Count == 0)
            {
                Application.Exit();
            }
        }
        private void btnCautare_Click(object sender, EventArgs e)
        {
            
        
            if (txtCautare == null || string.IsNullOrWhiteSpace(txtCautare.Text))
            {
                MessageBox.Show("Introduceti un ID valid!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetControls(this);
                return;
            }

            if (!int.TryParse(txtCautare.Text, out int id))
            {
                MessageBox.Show("ID-ul trebuie sa fie un numar!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetControls(this);
                return;
            }

         
            Masina masinaGasita = CautaMasinaDupaID(id);

            if (masinaGasita == null)
            {
                MessageBox.Show($"Nu s-a gasit nicio masina cu ID-ul {id}.", "Rezultat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
               
                MessageBox.Show(
                    $"ID: {masinaGasita.GetID()}\n" +
                    $"Marca: {masinaGasita.GetMarca()}\n" +
                    $"Model: {masinaGasita.GetModel()}\n" +
                    $"Culoare: {masinaGasita.GetCuloare()}\n" +
                    $"An Fabricatie: {masinaGasita.GetAnFabricatie()}\n" +
                    $"Pret: {masinaGasita.GetPret()}\n" +
                    $"Optiuni: {string.Join(", ", masinaGasita.GetOptiuni().Cast<string>())}",
                    "Masina Gasita",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                ResetControls(this);
            }
        }
        private Masina CautaMasinaDupaID(int value)
        {
            List<Masina> masini = registru.GetMasini();
            foreach (var masina in masini)
            {
                if (masina.GetID() == value)
                {
                    return masina;
                }
            }
            return null;
        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            if(txtMarca.Text == "" || txtModel.Text == "" || txtAnFabricatie.Text == "" || txtID.Text == "" || txtPret.Text == "")
            {
                lblEroare.Text = "Completati toate campurile!!!";
                return;
            }
            if (txtMarca.Text.Length>15)
            {
                lblEroare.Text = "Maxim 15 caractere sunt permise!!!";
                return;
            }
            if(txtModel.Text.Length > 15)
            {
                lblEroare.Text = "Maxim 15 caractere sunt permise!!!";
                return;
            }
            
            lblEroare.Text = "";
            string marca = txtMarca.Text;
            string model = txtModel.Text;
            int anFabricatie = int.Parse(txtAnFabricatie.Text);
            int ID = int.Parse(txtID.Text);
            float pret = float.Parse(txtPret.Text);
            Culoare culoareSelectata = GetCuloareSelectata();
          
               
         
            Masina masina = new Masina(ID, "none", "none", marca, model, anFabricatie, culoareSelectata, optiuniSelectate, pret);
            
            registru.AdaugaMasina(masina);
            AfiseazaRegistru();
            ResetControls(this);
            optiuniSelectate.Clear();
            foreach (Control control in groupBoxOptiuni.Controls)
            {
                if (control is CheckBox checkBox)
                {
                    checkBox.Checked = false;
                }
            }


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
        private void ckbOptiuni_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBoxControl = sender as CheckBox;
            string optiuneSelectata = checkBoxControl.Text;
         
            if (checkBoxControl.Checked == true)
                optiuniSelectate.Add(optiuneSelectata);
            else
                optiuniSelectate.Remove(optiuneSelectata);
        }
        private Culoare GetCuloareSelectata()
        {
            if(rdbtnAlb.Checked) return Culoare.Alb;
            if(rdbtnRosu.Checked) return Culoare.Rosu;
            if(rdbtnAlbastru.Checked) return Culoare.Albastru;
            if(rdbtnGalben.Checked) return Culoare.Galben;
            if(rdbtnGri.Checked) return Culoare.Gri;
            if(rdbtnMaro.Checked) return Culoare.Maro;
            if(rdbtnMov.Checked) return Culoare.Mov;
            if(rdbtnNegru.Checked) return Culoare.Negru;
            if(rdbtnRoz.Checked) return Culoare.Roz;
            if(rdbtnVerde.Checked) return Culoare.Verde;
            return Culoare.Alb;
        }
       
        public void Form1_Load(object sender, EventArgs e)
        {
            AfiseazaRegistru();
        }
        public void AfiseazaRegistru()
        {
            List<Masina> masini=registru.GetMasini();
            lstBxMasini.Items.Clear();
            lstBxMasini.Items.Add("");

            foreach(Masina ma in masini)
            {
                string[] masinaText = ma.Serialize().Split('|');
                lstBxMasini.Items.Add("ID: "+masinaText[0]);
                lstBxMasini.Items.Add("Marca: " + masinaText[3]);
                lstBxMasini.Items.Add("Model: " + masinaText[4]);
                lstBxMasini.Items.Add("An fabricatie: " + masinaText[5]);
                lstBxMasini.Items.Add("Culoare: " + masinaText[6]);
                lstBxMasini.Items.Add("Optiuni: " + masinaText[7]);
                lstBxMasini.Items.Add("Pret: " + masinaText[8]);
                lstBxMasini.Items.Add("");
                lstBxMasini.Items.Add("");

            }
            
        }

        private void Title_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void lblOptiuni2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void txtModel_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
