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
            this.dgvZaposleni = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNoviZaposleni = new System.Windows.Forms.Button();
            this.btnIzmeniZaposlenog = new System.Windows.Forms.Button();
            this.btnObrisiZaposlenog = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvZaposleni)).BeginInit();
            this.SuspendLayout();
            // 
            // lbScene
            // 
            this.lbScene.FormattingEnabled = true;
            this.lbScene.Location = new System.Drawing.Point(13, 28);
            this.lbScene.Name = "lbScene";
            this.lbScene.Size = new System.Drawing.Size(376, 199);
            this.lbScene.TabIndex = 0;
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
            this.gbDetaljiScene.Location = new System.Drawing.Point(395, 28);
            this.gbDetaljiScene.Name = "gbDetaljiScene";
            this.gbDetaljiScene.Size = new System.Drawing.Size(370, 199);
            this.gbDetaljiScene.TabIndex = 2;
            this.gbDetaljiScene.TabStop = false;
            this.gbDetaljiScene.Text = "Detalji scene";
            // 
            // dgvZaposleni
            // 
            this.dgvZaposleni.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvZaposleni.Location = new System.Drawing.Point(15, 258);
            this.dgvZaposleni.Name = "dgvZaposleni";
            this.dgvZaposleni.Size = new System.Drawing.Size(750, 231);
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
            this.btnObrisiZaposlenog.Location = new System.Drawing.Point(690, 495);
            this.btnObrisiZaposlenog.Name = "btnObrisiZaposlenog";
            this.btnObrisiZaposlenog.Size = new System.Drawing.Size(75, 23);
            this.btnObrisiZaposlenog.TabIndex = 7;
            this.btnObrisiZaposlenog.Text = "Obrisi";
            this.btnObrisiZaposlenog.UseVisualStyleBackColor = true;
            // 
            // frmGlavna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 533);
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
    }
}