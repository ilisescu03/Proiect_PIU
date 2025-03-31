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
        Registru registru;

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
        private const int DIMENSIUNE_PAS_Y = 30;
        private const int DIMENSIUNE_PAS_X = 120;
        public Form1()
        {
            InitializeComponent();
            string numeFisier = ConfigurationManager.AppSettings["registru.txt"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            // setare locatie fisier in directorul corespunzator solutiei
            // astfel incat datele din fisier sa poata fi utilizate si de alte proiecte
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;

            registru= new Registru();
            registru.LoadFromFile("registru.txt");

            this.Size = new Size(500, 200);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(100, 100);
            this.Font = new Font("Arial", 9, FontStyle.Bold);
            this.ForeColor = Color.DarkGray;
            this.Text = "Registru";

            lblMarca = new Label();
            lblMarca.Width = LATIME_CONTROL;
            lblMarca.Text = "Marca";
            lblMarca.Location = new Point(10, 10);
            lblMarca.Size = new Size(LATIME_CONTROL, 20);
            lblMarca.ForeColor = Color.DarkGray;
            this.Controls.Add(lblMarca);

            lblModel = new Label();
            lblModel.Width = LATIME_CONTROL;
            lblModel.Text = "Model";
            lblModel.Location = new Point(10 + DIMENSIUNE_PAS_X, 10);
            lblModel.Size = new Size(LATIME_CONTROL, 20);
            lblModel.ForeColor = Color.DarkGray;
            this.Controls.Add(lblModel);

            lblCuloare = new Label();
            lblCuloare.Width = LATIME_CONTROL;
            lblCuloare.Text = "Culoare";
            lblCuloare.Location = new Point(10 + 2 * DIMENSIUNE_PAS_X, 10);
            lblCuloare.Size = new Size(LATIME_CONTROL, 20);
            lblCuloare.ForeColor = Color.DarkGray;
            this.Controls.Add(lblCuloare);

            lblAnFabricatie = new Label();
            lblAnFabricatie.Width = LATIME_CONTROL;
            lblAnFabricatie.Text = "An Fabricatie";
            lblAnFabricatie.Location = new Point(10 + 3 * DIMENSIUNE_PAS_X, 10);
            lblAnFabricatie.Size = new Size(LATIME_CONTROL, 20);
            lblAnFabricatie.ForeColor = Color.DarkGray;
            this.Controls.Add(lblAnFabricatie);
            lblCuloare = new Label();

            lblPret = new Label();
            lblPret.Width = LATIME_CONTROL;
            lblPret.Text = "Pret";
            lblPret.Location = new Point(10 + 4 * DIMENSIUNE_PAS_X, 10);
            lblPret.Size = new Size(LATIME_CONTROL, 20);
            lblPret.ForeColor = Color.DarkGray;
            this.Controls.Add(lblPret);

            lblOptiuni = new Label();
            lblOptiuni.Width = LATIME_CONTROL;
            lblOptiuni.Text = "Optiuni";
            lblOptiuni.Location = new Point(10 + 5 * DIMENSIUNE_PAS_X, 10);
            lblOptiuni.Size = new Size(LATIME_CONTROL, 20);
            lblOptiuni.ForeColor = Color.DarkGray;
            this.Controls.Add(lblOptiuni);
        }
        public void Form1_Load(object sender, EventArgs e)
        {
            AfiseazaRegistru();
        }
        public void AfiseazaRegistru()
        {
            List<Masina> masini = registru.GetRegistru();
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
                lblsMarca[i].ForeColor = Color.DarkGray;
                this.Controls.Add(lblsMarca[i]);
                lblsModel[i] = new Label();
                lblsModel[i].Width = LATIME_CONTROL;
                lblsModel[i].Text = masina.GetModel();
                lblsModel[i].Location = new Point(10 + DIMENSIUNE_PAS_X, 10 + (i + 1) * DIMENSIUNE_PAS_Y);
                lblsModel[i].Size = new Size(LATIME_CONTROL, 20);
                lblsModel[i].ForeColor = Color.DarkGray;
                this.Controls.Add(lblsModel[i]);
                lblsCuloare[i] = new Label();
                lblsCuloare[i].Width = LATIME_CONTROL;
                lblsCuloare[i].Text = masina.GetCuloare().ToString();
                lblsCuloare[i].Location = new Point(10 + 2 * DIMENSIUNE_PAS_X, 10 + (i + 1) * DIMENSIUNE_PAS_Y);
                lblsCuloare[i].Size = new Size(LATIME_CONTROL, 20);
                lblsCuloare[i].ForeColor = Color.DarkGray;
                this.Controls.Add(lblsCuloare[i]);
                lblsAnFabricatie[i] = new Label();
                lblsAnFabricatie[i].Width = LATIME_CONTROL;
                lblsAnFabricatie[i].Text = masina.GetAnFabricatie().ToString();
                lblsAnFabricatie[i].Location = new Point(10 + 3 * DIMENSIUNE_PAS_X, 10 + (i + 1) * DIMENSIUNE_PAS_Y);
                lblsAnFabricatie[i].Size = new Size(LATIME_CONTROL, 20);
                lblsAnFabricatie[i].ForeColor = Color.DarkGray;
                this.Controls.Add(lblsAnFabricatie[i]);
                lblsPret[i] = new Label();
                lblsPret[i].Width = LATIME_CONTROL;
                lblsPret[i].Text = masina.GetPret().ToString();
                lblsPret[i].Location = new Point(10 + 4 * DIMENSIUNE_PAS_X, 10 + (i + 1) * DIMENSIUNE_PAS_Y);
                lblsPret[i].Size = new Size(LATIME_CONTROL, 20);
                lblsPret[i].ForeColor = Color.DarkGray;
                this.Controls.Add(lblsPret[i]);

                lblsOptiuni[i] = new Label();
                lblsOptiuni[i].Width = LATIME_CONTROL;
                lblsOptiuni[i].Text = masina.GetOptiuni().ToString();
                lblsOptiuni[i].Location = new Point(10 + 5 * DIMENSIUNE_PAS_X, 10 + (i + 1) * DIMENSIUNE_PAS_Y);
                lblsOptiuni[i].Size = new Size(LATIME_CONTROL, 20);
                lblsOptiuni[i].ForeColor = Color.DarkGray;
                this.Controls.Add(lblsOptiuni[i]);
                i++;

            }
        }
    }
}
