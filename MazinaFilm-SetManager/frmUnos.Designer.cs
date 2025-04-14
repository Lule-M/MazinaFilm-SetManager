namespace MazinaFilm_SetManager
{
    partial class frmUnos
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
            this.txtIme = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtPrezime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNaslov = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRadnoMesto = new System.Windows.Forms.TextBox();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.btnPonisti = new System.Windows.Forms.Button();
            this.lblIdScene = new System.Windows.Forms.Label();
            this.txtIdScene = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtIme
            // 
            this.txtIme.Location = new System.Drawing.Point(88, 95);
            this.txtIme.Name = "txtIme";
            this.txtIme.Size = new System.Drawing.Size(100, 20);
            this.txtIme.TabIndex = 0;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(88, 69);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(100, 20);
            this.txtId.TabIndex = 100;
            // 
            // txtPrezime
            // 
            this.txtPrezime.Location = new System.Drawing.Point(88, 121);
            this.txtPrezime.Name = "txtPrezime";
            this.txtPrezime.Size = new System.Drawing.Size(100, 20);
            this.txtPrezime.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ime";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Prezime";
            // 
            // lblNaslov
            // 
            this.lblNaslov.AutoSize = true;
            this.lblNaslov.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNaslov.Location = new System.Drawing.Point(12, 9);
            this.lblNaslov.Name = "lblNaslov";
            this.lblNaslov.Size = new System.Drawing.Size(168, 24);
            this.lblNaslov.TabIndex = 6;
            this.lblNaslov.Text = "Izmeni zaposlenog";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Radno mesto";
            // 
            // txtRadnoMesto
            // 
            this.txtRadnoMesto.Location = new System.Drawing.Point(88, 147);
            this.txtRadnoMesto.Name = "txtRadnoMesto";
            this.txtRadnoMesto.Size = new System.Drawing.Size(100, 20);
            this.txtRadnoMesto.TabIndex = 2;
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.Location = new System.Drawing.Point(12, 184);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(75, 23);
            this.btnSacuvaj.TabIndex = 3;
            this.btnSacuvaj.Text = "Sačuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = true;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // btnPonisti
            // 
            this.btnPonisti.Location = new System.Drawing.Point(121, 184);
            this.btnPonisti.Name = "btnPonisti";
            this.btnPonisti.Size = new System.Drawing.Size(75, 23);
            this.btnPonisti.TabIndex = 4;
            this.btnPonisti.Text = "Poništi";
            this.btnPonisti.UseVisualStyleBackColor = true;
            this.btnPonisti.Click += new System.EventHandler(this.btnPonisti_Click);
            // 
            // lblIdScene
            // 
            this.lblIdScene.AutoSize = true;
            this.lblIdScene.Location = new System.Drawing.Point(35, 46);
            this.lblIdScene.Name = "lblIdScene";
            this.lblIdScene.Size = new System.Drawing.Size(52, 13);
            this.lblIdScene.TabIndex = 13;
            this.lblIdScene.Text = "ID Scene";
            // 
            // txtIdScene
            // 
            this.txtIdScene.Location = new System.Drawing.Point(88, 43);
            this.txtIdScene.Name = "txtIdScene";
            this.txtIdScene.ReadOnly = true;
            this.txtIdScene.Size = new System.Drawing.Size(100, 20);
            this.txtIdScene.TabIndex = 100;
            // 
            // frmUnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(210, 222);
            this.Controls.Add(this.lblIdScene);
            this.Controls.Add(this.txtIdScene);
            this.Controls.Add(this.btnPonisti);
            this.Controls.Add(this.btnSacuvaj);
            this.Controls.Add(this.txtRadnoMesto);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblNaslov);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPrezime);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.txtIme);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmUnos";
            this.Text = "frmUnos";
            this.Load += new System.EventHandler(this.frmUnos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIme;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtPrezime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNaslov;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRadnoMesto;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.Button btnPonisti;
        private System.Windows.Forms.Label lblIdScene;
        private System.Windows.Forms.TextBox txtIdScene;
    }
}