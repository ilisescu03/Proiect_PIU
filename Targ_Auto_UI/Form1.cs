using System;
using System.Configuration;
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

        private Label lblMarca;
        private Label lblModel;
        private Label lblCuloare;
        private Label lblAnFabricatie;
        private Label lblPret;
        private Label lblOptiuni;

        private Label[] lblsMarca;
        private Label[] lblsModel;
        private Label[] lblsCuloare;
        private Label[] lblsAnFabricatie;
        private Label[] lblsPret;
        private Label[] lblsOptiuni;

        private const int LATIME_CONTROL = 100;
        private const int DIMENSIUNE_PAS_Y = 25;
        private const int DIMENSIUNE_PAS_X = 105;

        private Label lblMarca2;
        private Label lblModel2;
        private Label lblCuloare2;
        private Label lblAnFabricatie2;
        private Label lblPret2;
        private Label lblOptiuni2;

        private TextBox txtMarca;
        private TextBox txtModel;
        private TextBox txtPret;
        private TextBox txtAnFabricatie;

        private Button AddBtn;
        private Button RefreshBtn;
        private Label lblEroare;
        public Form1()
        {
            InitializeComponent();
          //  string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
           // string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            // setare locatie fisier in directorul corespunzator solutiei
            // astfel incat datele din fisier sa poata fi utilizate si de alte proiecte
          //  string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;

            registru = new RegistruFisier("registru.txt");


            this.Size = new Size(500, 200);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(100, 100);
            this.Font = new Font("Arial", 9, FontStyle.Bold);
            this.ForeColor = Color.Black;
            this.Text = "Registru";

            lblMarca = new Label();
            lblMarca.Width = LATIME_CONTROL;
            lblMarca.Text = "Marca";
            lblMarca.Location = new Point(10, 10);
            lblMarca.Size = new Size(LATIME_CONTROL, 20);
            lblMarca.ForeColor = Color.Black;
            lblMarca.BackColor = Color.Green;
            this.Controls.Add(lblMarca);

            lblModel = new Label();
            lblModel.Width = LATIME_CONTROL;
            lblModel.Text = "Model";
            lblModel.Location = new Point(10 + DIMENSIUNE_PAS_X, 10);
            lblModel.Size = new Size(LATIME_CONTROL, 20);
            lblModel.ForeColor = Color.Black;
            lblModel.BackColor = Color.Green;
            this.Controls.Add(lblModel);

            lblCuloare = new Label();
            lblCuloare.Width = LATIME_CONTROL;
            lblCuloare.Text = "Culoare";
            lblCuloare.Location = new Point(10 + 2 * DIMENSIUNE_PAS_X, 10);
            lblCuloare.Size = new Size(LATIME_CONTROL, 20);
            lblCuloare.ForeColor = Color.Black;
            lblCuloare.BackColor = Color.Green;
            this.Controls.Add(lblCuloare);

            lblAnFabricatie = new Label();
            lblAnFabricatie.Width = LATIME_CONTROL;
            lblAnFabricatie.Text = "An Fabricatie";
            lblAnFabricatie.Location = new Point(10 + 3 * DIMENSIUNE_PAS_X, 10);
            lblAnFabricatie.Size = new Size(LATIME_CONTROL, 20);
            lblAnFabricatie.ForeColor = Color.Black;
            lblAnFabricatie.BackColor = Color.Green;
            this.Controls.Add(lblAnFabricatie);
            lblCuloare = new Label();

            lblPret = new Label();
            lblPret.Width = LATIME_CONTROL;
            lblPret.Text = "Pret";
            lblPret.Location = new Point(10 + 4 * DIMENSIUNE_PAS_X, 10);
            lblPret.Size = new Size(LATIME_CONTROL, 20);
            lblPret.ForeColor = Color.Black;
            lblPret.BackColor = Color.Green;
            this.Controls.Add(lblPret);

            lblOptiuni = new Label();
            lblOptiuni.Width = LATIME_CONTROL;
            lblOptiuni.Text = "Optiuni";
            lblOptiuni.Location = new Point(10 + 5 * DIMENSIUNE_PAS_X, 10);
            lblOptiuni.Size = new Size(LATIME_CONTROL, 20);
            lblOptiuni.ForeColor = Color.Black;
            lblOptiuni.BackColor = Color.Green;
            this.Controls.Add(lblOptiuni);

            lblMarca2 = new Label();
            lblMarca2.Width = LATIME_CONTROL;
            lblMarca2.Text = "Marca:";
            lblMarca2.Location = new Point(10 + 6 * DIMENSIUNE_PAS_X, 10);
            lblMarca2.Size = new Size(LATIME_CONTROL, 20);
            lblMarca2.ForeColor = Color.Black;
            this.Controls.Add(lblMarca2);

            lblModel2 = new Label();
            lblModel2.Width = LATIME_CONTROL;
            lblModel2.Text = "Model:";
            lblModel2.Location = new Point(10 + 6 * DIMENSIUNE_PAS_X, 10 + 1 * DIMENSIUNE_PAS_Y);
            lblModel2.Size = new Size(LATIME_CONTROL, 20);
            lblModel2.ForeColor = Color.Black;
            this.Controls.Add(lblModel2);

            lblPret2 = new Label();
            lblPret2.Width = LATIME_CONTROL;
            lblPret2.Text = "Pret:";
            lblPret2.Location = new Point(10 + 6 * DIMENSIUNE_PAS_X, 10 + 2 * DIMENSIUNE_PAS_Y);
            lblPret2.Size = new Size(LATIME_CONTROL, 20);
            lblPret2.ForeColor = Color.Black;
            this.Controls.Add(lblPret2);

            lblAnFabricatie2 = new Label();
            lblAnFabricatie2.Width = LATIME_CONTROL;
            lblAnFabricatie2.Text = "An Fabricatie:";
            lblAnFabricatie2.Location = new Point(10 + 6 * DIMENSIUNE_PAS_X, 10 + 3 * DIMENSIUNE_PAS_Y); 
            lblAnFabricatie2.Size = new Size(LATIME_CONTROL, 20);
            lblAnFabricatie2.ForeColor = Color.Black;
            this.Controls.Add(lblAnFabricatie2);

            txtMarca = new TextBox();
            txtMarca.Width = LATIME_CONTROL;
            txtMarca.Location = new Point(10 + 7 * DIMENSIUNE_PAS_X, 10);
            txtMarca.Size = new Size(LATIME_CONTROL, 20);
            this.Controls.Add(txtMarca);

            txtModel = new TextBox();
            txtModel.Width = LATIME_CONTROL;
            txtModel.Location = new Point(10 + 7 * DIMENSIUNE_PAS_X, 10 + 1 * DIMENSIUNE_PAS_Y);
            txtModel.Size = new Size(LATIME_CONTROL, 20);
            this.Controls.Add(txtModel);

            txtPret = new TextBox();
            txtPret.Width = LATIME_CONTROL;
            txtPret.Location = new Point(10 + 7 * DIMENSIUNE_PAS_X, 10 + 2 * DIMENSIUNE_PAS_Y);
            txtPret.Size = new Size(LATIME_CONTROL, 20);
            this.Controls.Add(txtPret);

            txtAnFabricatie = new TextBox();
            txtAnFabricatie.Width = LATIME_CONTROL;
            txtAnFabricatie.Location = new Point(10 + 7 * DIMENSIUNE_PAS_X, 10 + 3 * DIMENSIUNE_PAS_Y);
            txtAnFabricatie.Size = new Size(LATIME_CONTROL, 20);
            this.Controls.Add(txtAnFabricatie);

            AddBtn = new Button();
            AddBtn.Text = "Adauga masina";
            AddBtn.Location = new Point(10 + 7 * DIMENSIUNE_PAS_X, 10 + 4 * DIMENSIUNE_PAS_Y);
            AddBtn.Size = new Size(LATIME_CONTROL, 20);
            AddBtn.BackColor = Color.LightBlue;
            AddBtn.ForeColor = Color.Black;
            AddBtn.Click += new EventHandler(AddBtn_Click);
            this.Controls.Add(AddBtn);

            RefreshBtn = new Button();
            RefreshBtn.Text = "Refresh";
            RefreshBtn.Location = new Point(10 + 7 * DIMENSIUNE_PAS_X, 10 + 5 * DIMENSIUNE_PAS_Y);
            RefreshBtn.Size = new Size(LATIME_CONTROL, 20);
            RefreshBtn.BackColor = Color.LightGreen;
            RefreshBtn.ForeColor = Color.Black;
            RefreshBtn.Click += new EventHandler(Refresh_Click);
            this.Controls.Add(RefreshBtn);


            lblEroare = new Label();
            lblEroare.Width = LATIME_CONTROL;
            lblEroare.Text = "Eroare!!!";
            lblEroare.Location = new Point(10 + 8 * DIMENSIUNE_PAS_X, 10 + 6 * DIMENSIUNE_PAS_Y);
            lblEroare.Size = new Size(LATIME_CONTROL, 20);
            lblEroare.ForeColor = Color.Red;
            lblEroare.Visible = false;
            this.Controls.Add(lblEroare);
            AfiseazaRegistru();

        }
        private void Refresh_Click(object sender, EventArgs e)
        {
            
            AfiseazaRegistru();



        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            if(txtMarca.Text.Length>15)
            {
                lblEroare.Location= new Point(10 + 8 * DIMENSIUNE_PAS_X, 10);
                lblEroare.Visible = true;
                return;
            }
            if(txtModel.Text.Length > 15)
            {
                lblEroare.Location = new Point(10 + 8 * DIMENSIUNE_PAS_X, 10 + 1 * DIMENSIUNE_PAS_Y);
                lblEroare.Visible = true;
                return;
            }
            lblEroare.Visible = false;
            string marca = txtMarca.Text;
            string model = txtModel.Text;
            int anFabricatie = int.Parse(txtAnFabricatie.Text);
            float pret = float.Parse(txtPret.Text);

            Masina masina = new Masina("nd", "nd", marca, model, anFabricatie, 0, 0, pret);
            registru.AdaugaMasina(masina);
  

           
            
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
            lblsModel = new Label[NrMasini];
            lblsCuloare = new Label[NrMasini];
            lblsAnFabricatie = new Label[NrMasini];
            lblsPret = new Label[NrMasini];
            lblsOptiuni = new Label[NrMasini];
            int i = 0;
            foreach(var masina in masini)
            {
                lblsMarca[i] = new Label();
                lblsMarca[i].Width = LATIME_CONTROL;
                lblsMarca[i].Text = masina.GetMarca();
                lblsMarca[i].Location = new Point(10, 10 + (i + 1) * DIMENSIUNE_PAS_Y);
                lblsMarca[i].Size = new Size(LATIME_CONTROL, 20);
                lblsMarca[i].ForeColor = Color.Black;
                lblsMarca[i].BackColor = Color.LightGreen;
                this.Controls.Add(lblsMarca[i]);
                lblsModel[i] = new Label();
                lblsModel[i].Width = LATIME_CONTROL;
                lblsModel[i].Text = masina.GetModel();
                lblsModel[i].Location = new Point(10 + DIMENSIUNE_PAS_X, 10 + (i + 1) * DIMENSIUNE_PAS_Y);
                lblsModel[i].Size = new Size(LATIME_CONTROL, 20);
                lblsModel[i].ForeColor = Color.Black;
                lblsModel[i].BackColor = Color.LightGreen;
                this.Controls.Add(lblsModel[i]);
                lblsCuloare[i] = new Label();
                lblsCuloare[i].Width = LATIME_CONTROL;
                lblsCuloare[i].Text = masina.GetCuloare().ToString();
                lblsCuloare[i].Location = new Point(10 + 2 * DIMENSIUNE_PAS_X, 10 + (i + 1) * DIMENSIUNE_PAS_Y);
                lblsCuloare[i].Size = new Size(LATIME_CONTROL, 20);
                lblsCuloare[i].ForeColor = Color.Black;
                lblsCuloare[i].BackColor = Color.LightGreen;
                this.Controls.Add(lblsCuloare[i]);
                lblsAnFabricatie[i] = new Label();
                lblsAnFabricatie[i].Width = LATIME_CONTROL;
                lblsAnFabricatie[i].Text = masina.GetAnFabricatie().ToString();
                lblsAnFabricatie[i].Location = new Point(10 + 3 * DIMENSIUNE_PAS_X, 10 + (i + 1) * DIMENSIUNE_PAS_Y);
                lblsAnFabricatie[i].Size = new Size(LATIME_CONTROL, 20);
                lblsAnFabricatie[i].ForeColor = Color.Black;
                lblsAnFabricatie[i].BackColor = Color.LightGreen;
                this.Controls.Add(lblsAnFabricatie[i]);
                lblsPret[i] = new Label();
                lblsPret[i].Width = LATIME_CONTROL;
                lblsPret[i].Text = masina.GetPret().ToString();
                lblsPret[i].Location = new Point(10 + 4 * DIMENSIUNE_PAS_X, 10 + (i + 1) * DIMENSIUNE_PAS_Y);
                lblsPret[i].Size = new Size(LATIME_CONTROL, 20);
                lblsPret[i].ForeColor = Color.Black;
                lblsPret[i].BackColor = Color.LightGreen;
                this.Controls.Add(lblsPret[i]);

                lblsOptiuni[i] = new Label();
                lblsOptiuni[i].Width = LATIME_CONTROL;
                lblsOptiuni[i].Text = masina.GetOptiuni().ToString();
                lblsOptiuni[i].Location = new Point(10 + 5 * DIMENSIUNE_PAS_X, 10 + (i + 1) * DIMENSIUNE_PAS_Y);
                lblsOptiuni[i].Size = new Size(LATIME_CONTROL, 20);
                lblsOptiuni[i].ForeColor = Color.Black;
                lblsOptiuni[i].BackColor = Color.LightGreen;
                this.Controls.Add(lblsOptiuni[i]);
                i++;

            }
        }
    }
}
