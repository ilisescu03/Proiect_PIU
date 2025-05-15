namespace Targ_Auto_UI
{
    partial class Form4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Titlu = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lstbxTranzactii = new System.Windows.Forms.ListBox();
            this.grp = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cmbxRegistru = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbxCumparatori = new System.Windows.Forms.ComboBox();
            this.cmbxVanzatori = new System.Windows.Forms.ComboBox();
            this.dataPick = new System.Windows.Forms.DateTimePicker();
            this.txtSuma = new System.Windows.Forms.TextBox();
            this.txtCodTranzactie = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNume = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnCautare = new System.Windows.Forms.Button();
            this.txtCautare = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.grp.SuspendLayout();
            this.SuspendLayout();
            // 
            // Titlu
            // 
            this.Titlu.AutoSize = true;
            this.Titlu.Font = new System.Drawing.Font("MV Boli", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titlu.Location = new System.Drawing.Point(234, 9);
            this.Titlu.Name = "Titlu";
            this.Titlu.Size = new System.Drawing.Size(382, 46);
            this.Titlu.TabIndex = 5;
            this.Titlu.Text = "Gestionare tranzactii";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MV Boli", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(69, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 46);
            this.label3.TabIndex = 24;
            this.label3.Text = "Tranzactii";
            // 
            // lstbxTranzactii
            // 
            this.lstbxTranzactii.FormattingEnabled = true;
            this.lstbxTranzactii.Location = new System.Drawing.Point(90, 146);
            this.lstbxTranzactii.Name = "lstbxTranzactii";
            this.lstbxTranzactii.Size = new System.Drawing.Size(369, 290);
            this.lstbxTranzactii.TabIndex = 25;
            // 
            // grp
            // 
            this.grp.Controls.Add(this.btnAdd);
            this.grp.Controls.Add(this.cmbxRegistru);
            this.grp.Controls.Add(this.label6);
            this.grp.Controls.Add(this.cmbxCumparatori);
            this.grp.Controls.Add(this.cmbxVanzatori);
            this.grp.Controls.Add(this.dataPick);
            this.grp.Controls.Add(this.txtSuma);
            this.grp.Controls.Add(this.txtCodTranzactie);
            this.grp.Controls.Add(this.label5);
            this.grp.Controls.Add(this.label4);
            this.grp.Controls.Add(this.label2);
            this.grp.Controls.Add(this.label1);
            this.grp.Controls.Add(this.lblNume);
            this.grp.Location = new System.Drawing.Point(490, 105);
            this.grp.Name = "grp";
            this.grp.Size = new System.Drawing.Size(321, 331);
            this.grp.TabIndex = 26;
            this.grp.TabStop = false;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(97, 270);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(116, 40);
            this.btnAdd.TabIndex = 40;
            this.btnAdd.Text = "Adaugare";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdauga_Click);
            // 
            // cmbxRegistru
            // 
            this.cmbxRegistru.FormattingEnabled = true;
            this.cmbxRegistru.Location = new System.Drawing.Point(83, 174);
            this.cmbxRegistru.Name = "cmbxRegistru";
            this.cmbxRegistru.Size = new System.Drawing.Size(121, 21);
            this.cmbxRegistru.TabIndex = 39;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 20);
            this.label6.TabIndex = 38;
            this.label6.Text = "Masina:";
            // 
            // cmbxCumparatori
            // 
            this.cmbxCumparatori.FormattingEnabled = true;
            this.cmbxCumparatori.Location = new System.Drawing.Point(120, 143);
            this.cmbxCumparatori.Name = "cmbxCumparatori";
            this.cmbxCumparatori.Size = new System.Drawing.Size(121, 21);
            this.cmbxCumparatori.TabIndex = 36;
            // 
            // cmbxVanzatori
            // 
            this.cmbxVanzatori.FormattingEnabled = true;
            this.cmbxVanzatori.Location = new System.Drawing.Point(110, 111);
            this.cmbxVanzatori.Name = "cmbxVanzatori";
            this.cmbxVanzatori.Size = new System.Drawing.Size(121, 21);
            this.cmbxVanzatori.TabIndex = 35;
            // 
            // dataPick
            // 
            this.dataPick.Location = new System.Drawing.Point(72, 82);
            this.dataPick.Name = "dataPick";
            this.dataPick.Size = new System.Drawing.Size(189, 20);
            this.dataPick.TabIndex = 34;
            // 
            // txtSuma
            // 
            this.txtSuma.Location = new System.Drawing.Point(72, 50);
            this.txtSuma.Name = "txtSuma";
            this.txtSuma.Size = new System.Drawing.Size(100, 20);
            this.txtSuma.TabIndex = 33;
            // 
            // txtCodTranzactie
            // 
            this.txtCodTranzactie.Location = new System.Drawing.Point(156, 16);
            this.txtCodTranzactie.Name = "txtCodTranzactie";
            this.txtCodTranzactie.Size = new System.Drawing.Size(100, 20);
            this.txtCodTranzactie.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 20);
            this.label5.TabIndex = 31;
            this.label5.Text = "Cumparator:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 20);
            this.label4.TabIndex = 30;
            this.label4.Text = "Vanzator:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 29;
            this.label2.Text = "Data:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 28;
            this.label1.Text = "Suma:";
            // 
            // lblNume
            // 
            this.lblNume.AutoSize = true;
            this.lblNume.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNume.Location = new System.Drawing.Point(6, 16);
            this.lblNume.Name = "lblNume";
            this.lblNume.Size = new System.Drawing.Size(131, 20);
            this.lblNume.TabIndex = 27;
            this.lblNume.Text = "Cod tranzactie:";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Red;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(695, 553);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(116, 40);
            this.btnBack.TabIndex = 41;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // btnCautare
            // 
            this.btnCautare.BackColor = System.Drawing.Color.PaleGreen;
            this.btnCautare.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCautare.Location = new System.Drawing.Point(354, 105);
            this.btnCautare.Name = "btnCautare";
            this.btnCautare.Size = new System.Drawing.Size(87, 35);
            this.btnCautare.TabIndex = 43;
            this.btnCautare.Text = "Cautare dupa cod";
            this.btnCautare.UseVisualStyleBackColor = false;
            this.btnCautare.Click += new System.EventHandler(this.btnCautare_Click);
            // 
            // txtCautare
            // 
            this.txtCautare.Location = new System.Drawing.Point(283, 117);
            this.txtCautare.Name = "txtCautare";
            this.txtCautare.Size = new System.Drawing.Size(65, 20);
            this.txtCautare.TabIndex = 42;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(220, 442);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 40);
            this.button2.TabIndex = 44;
            this.button2.Text = "Sterge tranzactii";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Stergere_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 622);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnCautare);
            this.Controls.Add(this.txtCautare);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.grp);
            this.Controls.Add(this.lstbxTranzactii);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Titlu);
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.grp.ResumeLayout(false);
            this.grp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Titlu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstbxTranzactii;
        private System.Windows.Forms.GroupBox grp;
        private System.Windows.Forms.ComboBox cmbxCumparatori;
        private System.Windows.Forms.ComboBox cmbxVanzatori;
        private System.Windows.Forms.DateTimePicker dataPick;
        private System.Windows.Forms.TextBox txtSuma;
        private System.Windows.Forms.TextBox txtCodTranzactie;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNume;
        private System.Windows.Forms.ComboBox cmbxRegistru;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnCautare;
        private System.Windows.Forms.TextBox txtCautare;
        private System.Windows.Forms.Button button2;
    }
}