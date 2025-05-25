namespace Targ_Auto_UI
{
    partial class Form3
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
            this.GstRegBtn = new System.Windows.Forms.Button();
            this.GstClientiBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.btnGstTranzactii = new System.Windows.Forms.Button();
            this.masiniVanduteBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Titlu
            // 
            this.Titlu.AutoSize = true;
            this.Titlu.Font = new System.Drawing.Font("MV Boli", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titlu.Location = new System.Drawing.Point(331, 37);
            this.Titlu.Name = "Titlu";
            this.Titlu.Size = new System.Drawing.Size(197, 46);
            this.Titlu.TabIndex = 5;
            this.Titlu.Text = "Targ Auto";
            this.Titlu.Click += new System.EventHandler(this.Titlu_Click);
            // 
            // GstRegBtn
            // 
            this.GstRegBtn.BackColor = System.Drawing.Color.Lime;
            this.GstRegBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.GstRegBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GstRegBtn.Location = new System.Drawing.Point(371, 151);
            this.GstRegBtn.Name = "GstRegBtn";
            this.GstRegBtn.Size = new System.Drawing.Size(106, 36);
            this.GstRegBtn.TabIndex = 6;
            this.GstRegBtn.Text = "Gestionare registru";
            this.GstRegBtn.UseVisualStyleBackColor = false;
            this.GstRegBtn.Click += new System.EventHandler(this.GstRegBtn_Click);
            // 
            // GstClientiBtn
            // 
            this.GstClientiBtn.BackColor = System.Drawing.Color.Lime;
            this.GstClientiBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.GstClientiBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GstClientiBtn.Location = new System.Drawing.Point(371, 193);
            this.GstClientiBtn.Name = "GstClientiBtn";
            this.GstClientiBtn.Size = new System.Drawing.Size(106, 45);
            this.GstClientiBtn.TabIndex = 7;
            this.GstClientiBtn.Text = "Gestionare Clienti";
            this.GstClientiBtn.UseVisualStyleBackColor = false;
            this.GstClientiBtn.Click += new System.EventHandler(this.GstClientiBtn_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.BackColor = System.Drawing.Color.Red;
            this.ExitBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ExitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitBtn.Location = new System.Drawing.Point(371, 342);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(106, 44);
            this.ExitBtn.TabIndex = 8;
            this.ExitBtn.Text = "EXIT";
            this.ExitBtn.UseVisualStyleBackColor = false;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // btnGstTranzactii
            // 
            this.btnGstTranzactii.BackColor = System.Drawing.Color.Lime;
            this.btnGstTranzactii.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnGstTranzactii.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGstTranzactii.Location = new System.Drawing.Point(371, 244);
            this.btnGstTranzactii.Name = "btnGstTranzactii";
            this.btnGstTranzactii.Size = new System.Drawing.Size(106, 43);
            this.btnGstTranzactii.TabIndex = 9;
            this.btnGstTranzactii.Text = "Gestionare Tranzactii";
            this.btnGstTranzactii.UseVisualStyleBackColor = false;
            this.btnGstTranzactii.Click += new System.EventHandler(this.GstTranzBtn_Click);
            // 
            // masiniVanduteBtn
            // 
            this.masiniVanduteBtn.BackColor = System.Drawing.Color.Lime;
            this.masiniVanduteBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.masiniVanduteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.masiniVanduteBtn.Location = new System.Drawing.Point(371, 112);
            this.masiniVanduteBtn.Name = "masiniVanduteBtn";
            this.masiniVanduteBtn.Size = new System.Drawing.Size(106, 33);
            this.masiniVanduteBtn.TabIndex = 10;
            this.masiniVanduteBtn.Text = "Masini vandute";
            this.masiniVanduteBtn.UseVisualStyleBackColor = false;
            this.masiniVanduteBtn.Click += new System.EventHandler(this.MasiniVanduteBtn_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Lime;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(371, 293);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 43);
            this.button1.TabIndex = 11;
            this.button1.Text = "Grafic Tranzactii";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.GraficBtn_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 611);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.masiniVanduteBtn);
            this.Controls.Add(this.btnGstTranzactii);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.GstClientiBtn);
            this.Controls.Add(this.GstRegBtn);
            this.Controls.Add(this.Titlu);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Titlu;
        private System.Windows.Forms.Button GstRegBtn;
        private System.Windows.Forms.Button GstClientiBtn;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Button btnGstTranzactii;
        private System.Windows.Forms.Button masiniVanduteBtn;
        private System.Windows.Forms.Button button1;
    }
}