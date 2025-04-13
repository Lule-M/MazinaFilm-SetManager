namespace MazinaFilm_SetManager
{
    partial class frmGlavna
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
            this.lbScene = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbDetaljiScene = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbLokacija = new System.Windows.Forms.ComboBox();
            this.dtpDatumSnimanja = new System.Windows.Forms.DateTimePicker();
            this.chkSnimljeno = new System.Windows.Forms.CheckBox();
            this.txtLokacija = new System.Windows.Forms.TextBox();
            this.txtRedniBroj = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvZaposleni = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNoviZaposleni = new System.Windows.Forms.Button();
            this.btnIzmeniZaposlenog = new System.Windows.Forms.Button();
            this.btnObrisiZaposlenog = new System.Windows.Forms.Button();
            this.gbDetaljiScene.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvZaposleni)).BeginInit();
            this.SuspendLayout();
            // 
            // lbScene
            // 
            this.lbScene.FormattingEnabled = true;
            this.lbScene.Location = new System.Drawing.Point(13, 28);
            this.lbScene.Name = "lbScene";
            this.lbScene.Size = new System.Drawing.Size(256, 199);
            this.lbScene.TabIndex = 0;
            this.lbScene.SelectedIndexChanged += new System.EventHandler(this.lbScene_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Scene";
            // 
            // gbDetaljiScene
            // 
            this.gbDetaljiScene.Controls.Add(this.label7);
            this.gbDetaljiScene.Controls.Add(this.cbLokacija);
            this.gbDetaljiScene.Controls.Add(this.dtpDatumSnimanja);
            this.gbDetaljiScene.Controls.Add(this.chkSnimljeno);
            this.gbDetaljiScene.Controls.Add(this.txtLokacija);
            this.gbDetaljiScene.Controls.Add(this.txtRedniBroj);
            this.gbDetaljiScene.Controls.Add(this.label6);
            this.gbDetaljiScene.Controls.Add(this.label5);
            this.gbDetaljiScene.Controls.Add(this.label4);
            this.gbDetaljiScene.Controls.Add(this.label3);
            this.gbDetaljiScene.Location = new System.Drawing.Point(275, 23);
            this.gbDetaljiScene.Name = "gbDetaljiScene";
            this.gbDetaljiScene.Size = new System.Drawing.Size(215, 204);
            this.gbDetaljiScene.TabIndex = 2;
            this.gbDetaljiScene.TabStop = false;
            this.gbDetaljiScene.Text = "Detalji scene";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Lokacija";
            // 
            // cbLokacija
            // 
            this.cbLokacija.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLokacija.FormattingEnabled = true;
            this.cbLokacija.Location = new System.Drawing.Point(87, 45);
            this.cbLokacija.Name = "cbLokacija";
            this.cbLokacija.Size = new System.Drawing.Size(100, 21);
            this.cbLokacija.TabIndex = 17;
            this.cbLokacija.SelectedIndexChanged += new System.EventHandler(this.cbLokacija_SelectedIndexChanged);
            // 
            // dtpDatumSnimanja
            // 
            this.dtpDatumSnimanja.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDatumSnimanja.Location = new System.Drawing.Point(87, 124);
            this.dtpDatumSnimanja.Name = "dtpDatumSnimanja";
            this.dtpDatumSnimanja.Size = new System.Drawing.Size(100, 20);
            this.dtpDatumSnimanja.TabIndex = 16;
            // 
            // chkSnimljeno
            // 
            this.chkSnimljeno.AutoSize = true;
            this.chkSnimljeno.Location = new System.Drawing.Point(87, 150);
            this.chkSnimljeno.Name = "chkSnimljeno";
            this.chkSnimljeno.Size = new System.Drawing.Size(15, 14);
            this.chkSnimljeno.TabIndex = 15;
            this.chkSnimljeno.UseVisualStyleBackColor = true;
            // 
            // txtLokacija
            // 
            this.txtLokacija.Location = new System.Drawing.Point(87, 98);
            this.txtLokacija.Name = "txtLokacija";
            this.txtLokacija.Size = new System.Drawing.Size(100, 20);
            this.txtLokacija.TabIndex = 13;
            // 
            // txtRedniBroj
            // 
            this.txtRedniBroj.Location = new System.Drawing.Point(87, 72);
            this.txtRedniBroj.Name = "txtRedniBroj";
            this.txtRedniBroj.Size = new System.Drawing.Size(100, 20);
            this.txtRedniBroj.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Snimljeno";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Datum";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Doba dana";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Redni broj";
            // 
            // dgvZaposleni
            // 
            this.dgvZaposleni.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvZaposleni.Location = new System.Drawing.Point(15, 258);
            this.dgvZaposleni.Name = "dgvZaposleni";
            this.dgvZaposleni.Size = new System.Drawing.Size(475, 231);
            this.dgvZaposleni.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 242);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Zaposleni na sceni";
            // 
            // btnNoviZaposleni
            // 
            this.btnNoviZaposleni.Location = new System.Drawing.Point(15, 495);
            this.btnNoviZaposleni.Name = "btnNoviZaposleni";
            this.btnNoviZaposleni.Size = new System.Drawing.Size(75, 23);
            this.btnNoviZaposleni.TabIndex = 5;
            this.btnNoviZaposleni.Text = "Novi";
            this.btnNoviZaposleni.UseVisualStyleBackColor = true;
            // 
            // btnIzmeniZaposlenog
            // 
            this.btnIzmeniZaposlenog.Location = new System.Drawing.Point(96, 495);
            this.btnIzmeniZaposlenog.Name = "btnIzmeniZaposlenog";
            this.btnIzmeniZaposlenog.Size = new System.Drawing.Size(75, 23);
            this.btnIzmeniZaposlenog.TabIndex = 6;
            this.btnIzmeniZaposlenog.Text = "Izmeni";
            this.btnIzmeniZaposlenog.UseVisualStyleBackColor = true;
            // 
            // btnObrisiZaposlenog
            // 
            this.btnObrisiZaposlenog.Location = new System.Drawing.Point(415, 495);
            this.btnObrisiZaposlenog.Name = "btnObrisiZaposlenog";
            this.btnObrisiZaposlenog.Size = new System.Drawing.Size(75, 23);
            this.btnObrisiZaposlenog.TabIndex = 7;
            this.btnObrisiZaposlenog.Text = "Obriši";
            this.btnObrisiZaposlenog.UseVisualStyleBackColor = true;
            // 
            // frmGlavna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 533);
            this.Controls.Add(this.btnObrisiZaposlenog);
            this.Controls.Add(this.btnIzmeniZaposlenog);
            this.Controls.Add(this.btnNoviZaposleni);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvZaposleni);
            this.Controls.Add(this.gbDetaljiScene);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbScene);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmGlavna";
            this.Text = "frmGlavna";
            this.gbDetaljiScene.ResumeLayout(false);
            this.gbDetaljiScene.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvZaposleni)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbScene;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbDetaljiScene;
        private System.Windows.Forms.DataGridView dgvZaposleni;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnNoviZaposleni;
        private System.Windows.Forms.Button btnIzmeniZaposlenog;
        private System.Windows.Forms.Button btnObrisiZaposlenog;
        private System.Windows.Forms.CheckBox chkSnimljeno;
        private System.Windows.Forms.TextBox txtLokacija;
        private System.Windows.Forms.TextBox txtRedniBroj;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDatumSnimanja;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbLokacija;
    }
}