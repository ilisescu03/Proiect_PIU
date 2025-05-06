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
    
    public partial class Form1: Form
    {
        RegistruFisier registru;

        private Label lblID;
        private Label lblMarca;
        private Label lblModel;
        private Label lblCuloare;
        private Label lblAnFabricatie;
        private Label lblPret;
        private Label lblOptiuni;

        private Label[] lblsID;
        private Label[] lblsMarca;
        private Label[] lblsModel;
        private Label[] lblsCuloare;
        private Label[] lblsAnFabricatie;
        private Label[] lblsPret;
        private ComboBox[] comboBoxOptiuni; 


        private const int LATIME_CONTROL = 100;
        private const int DIMENSIUNE_PAS_Y = 25;
        private const int DIMENSIUNE_PAS_X = 105;





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


            this.Size = new Size(1000, 800);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(100, 100);
            this.Font = new Font("Arial", 9, FontStyle.Bold);
            this.ForeColor = Color.Black;
            this.Text = "Registru";

            lblID = new Label();
            lblID.Width = LATIME_CONTROL;
            lblID.Text = "ID";
            lblID.Location = new Point(75, 100);
            lblID.Size = new Size(LATIME_CONTROL, 20);
            lblID.ForeColor = Color.Black;
            lblID.BackColor = Color.Green;
            this.Controls.Add(lblID);

            lblMarca = new Label();
            lblMarca.Width = LATIME_CONTROL;
            lblMarca.Text = "Marca";
            lblMarca.Location = new Point(75 + DIMENSIUNE_PAS_X, 100);
            lblMarca.Size = new Size(LATIME_CONTROL, 20);
            lblMarca.ForeColor = Color.Black;
            lblMarca.BackColor = Color.Green;
            this.Controls.Add(lblMarca);

            lblModel = new Label();
            lblModel.Width = LATIME_CONTROL;
            lblModel.Text = "Model";
            lblModel.Location = new Point(75 + 2*DIMENSIUNE_PAS_X, 100);
            lblModel.Size = new Size(LATIME_CONTROL, 20);
            lblModel.ForeColor = Color.Black;
            lblModel.BackColor = Color.Green;
            this.Controls.Add(lblModel);

            lblCuloare = new Label();
            lblCuloare.Width = LATIME_CONTROL;
            lblCuloare.Text = "Culoare";
            lblCuloare.Location = new Point(75 + 3 * DIMENSIUNE_PAS_X, 100);
            lblCuloare.Size = new Size(LATIME_CONTROL, 20);
            lblCuloare.ForeColor = Color.Black;
            lblCuloare.BackColor = Color.Green;
            this.Controls.Add(lblCuloare);

            lblAnFabricatie = new Label();
            lblAnFabricatie.Width = LATIME_CONTROL;
            lblAnFabricatie.Text = "An Fabricatie";
            lblAnFabricatie.Location = new Point(75 + 4 * DIMENSIUNE_PAS_X, 100);
            lblAnFabricatie.Size = new Size(LATIME_CONTROL, 20);
            lblAnFabricatie.ForeColor = Color.Black;
            lblAnFabricatie.BackColor = Color.Green;
            this.Controls.Add(lblAnFabricatie);
            lblCuloare = new Label();

            lblPret = new Label();
            lblPret.Width = LATIME_CONTROL;
            lblPret.Text = "Pret";
            lblPret.Location = new Point(75 + 5 * DIMENSIUNE_PAS_X, 100);
            lblPret.Size = new Size(LATIME_CONTROL, 20);
            lblPret.ForeColor = Color.Black;
            lblPret.BackColor = Color.Green;
            this.Controls.Add(lblPret);

            lblOptiuni = new Label();
            lblOptiuni.Width = LATIME_CONTROL;
            lblOptiuni.Text = "Optiuni";
            lblOptiuni.Location = new Point(75 + 6 * DIMENSIUNE_PAS_X, 100);
            lblOptiuni.Size = new Size(LATIME_CONTROL, 20);
            lblOptiuni.ForeColor = Color.Black;
            lblOptiuni.BackColor = Color.Green;
            this.Controls.Add(lblOptiuni);

          

           



            
            AfiseazaRegistru();

        }
        private void Refresh_Click(object sender, EventArgs e)
        {
            
            AfiseazaRegistru();



        }
        private void btnCautare_Click(object sender, EventArgs e)
        {
            // Get the search ID from the TextBox
        
            if (txtCautare == null || string.IsNullOrWhiteSpace(txtCautare.Text))
            {
                MessageBox.Show("Introduceti un ID valid!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtCautare.Text, out int id))
            {
                MessageBox.Show("ID-ul trebuie sa fie un numar!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Search for the car by ID
            Masina masinaGasita = CautaMasinaDupaID(id);

            if (masinaGasita == null)
            {
                MessageBox.Show($"Nu s-a gasit nicio masina cu ID-ul {id}.", "Rezultat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Display the car details
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
            if(txtMarca.Text.Length>15)
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
           
            Masina masina = new Masina(ID, "nd", "nd", marca, model, anFabricatie, culoareSelectata, optiuniSelectate, pret);
            masina.GetOptiuni().AddRange(optiuniSelectate);
            registru.AdaugaMasina(masina);
  

           
            
        }
        private void ckbOptiuni_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBoxControl = sender as CheckBox; //operator 'as'
                                                           //sau
                                                           //CheckBox checkBoxControl = (CheckBox)sender; //operator cast
            string optiuneSelectata = checkBoxControl.Text;
            //verificare daca checkbox-ul asupra caruia s-a actionat este selectat
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
            List<Masina> masini = registru.GetMasini();
            int NrMasini= masini.Count;
            lblsMarca = new Label[NrMasini];
            lblsID = new Label[NrMasini];
            lblsModel = new Label[NrMasini];
            lblsCuloare = new Label[NrMasini];
            lblsAnFabricatie = new Label[NrMasini];
            lblsPret = new Label[NrMasini];
            comboBoxOptiuni = new ComboBox[NrMasini]; // Initialize comboBoxOptiuni[]

            int i = 0;
            foreach(var masina in masini)
            {
                lblsID[i] = new Label();
                lblsID[i].Width = LATIME_CONTROL;
                lblsID[i].Text = masina.GetID().ToString();
                lblsID[i].Location = new Point(75, 100 + (i + 1) * DIMENSIUNE_PAS_Y);
                lblsID[i].Size = new Size(LATIME_CONTROL, 20);
                lblsID[i].ForeColor = Color.Black;
                lblsID[i].BackColor = Color.LightGreen;
                this.Controls.Add(lblsID[i]);

                lblsMarca[i] = new Label();
                lblsMarca[i].Width = LATIME_CONTROL;
                lblsMarca[i].Text = masina.GetMarca();
                lblsMarca[i].Location = new Point(75 + DIMENSIUNE_PAS_X, 100 + (i + 1) * DIMENSIUNE_PAS_Y);
                lblsMarca[i].Size = new Size(LATIME_CONTROL, 20);
                lblsMarca[i].ForeColor = Color.Black;
                lblsMarca[i].BackColor = Color.LightGreen;
                this.Controls.Add(lblsMarca[i]);
                lblsModel[i] = new Label();
                lblsModel[i].Width = LATIME_CONTROL;
                lblsModel[i].Text = masina.GetModel();
                lblsModel[i].Location = new Point(75 + 2 * DIMENSIUNE_PAS_X, 100 + (i + 1) * DIMENSIUNE_PAS_Y);
                lblsModel[i].Size = new Size(LATIME_CONTROL, 20);
                lblsModel[i].ForeColor = Color.Black;
                lblsModel[i].BackColor = Color.LightGreen;
                this.Controls.Add(lblsModel[i]);
                lblsCuloare[i] = new Label();
                lblsCuloare[i].Width = LATIME_CONTROL;
                lblsCuloare[i].Text = masina.GetCuloare().ToString();
                lblsCuloare[i].Location = new Point(75 + 3 * DIMENSIUNE_PAS_X, 100 + (i + 1) * DIMENSIUNE_PAS_Y);
                lblsCuloare[i].Size = new Size(LATIME_CONTROL, 20);
                lblsCuloare[i].ForeColor = Color.Black;
                lblsCuloare[i].BackColor = Color.LightGreen;
                this.Controls.Add(lblsCuloare[i]);
                lblsAnFabricatie[i] = new Label();
                lblsAnFabricatie[i].Width = LATIME_CONTROL;
                lblsAnFabricatie[i].Text = masina.GetAnFabricatie().ToString();
                lblsAnFabricatie[i].Location = new Point(75 + 4 * DIMENSIUNE_PAS_X, 100 + (i + 1) * DIMENSIUNE_PAS_Y);
                lblsAnFabricatie[i].Size = new Size(LATIME_CONTROL, 20);
                lblsAnFabricatie[i].ForeColor = Color.Black;
                lblsAnFabricatie[i].BackColor = Color.LightGreen;
                this.Controls.Add(lblsAnFabricatie[i]);
                lblsPret[i] = new Label();
                lblsPret[i].Width = LATIME_CONTROL;
                lblsPret[i].Text = masina.GetPret().ToString();
                lblsPret[i].Location = new Point(75 + 5 * DIMENSIUNE_PAS_X, 100 + (i + 1) * DIMENSIUNE_PAS_Y);
                lblsPret[i].Size = new Size(LATIME_CONTROL, 20);
                lblsPret[i].ForeColor = Color.Black;
                lblsPret[i].BackColor = Color.LightGreen;
                this.Controls.Add(lblsPret[i]);

                comboBoxOptiuni[i] = new ComboBox();
                comboBoxOptiuni[i].Width = LATIME_CONTROL;
                comboBoxOptiuni[i].Location = new Point(75 + 6 * DIMENSIUNE_PAS_X, 100 + (i + 1) * DIMENSIUNE_PAS_Y);
                comboBoxOptiuni[i].Size = new Size(LATIME_CONTROL, 20);
                comboBoxOptiuni[i].ForeColor = Color.Black;
                comboBoxOptiuni[i].BackColor = Color.White;
                comboBoxOptiuni[i].DropDownStyle = ComboBoxStyle.DropDownList;
                foreach (string optiune in masina.GetOptiuni().Cast<string>())
                {
                    comboBoxOptiuni[i].Items.Add(optiune);
                }
                this.Controls.Add(comboBoxOptiuni[i]);

                i++;

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
