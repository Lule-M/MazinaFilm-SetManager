using Shared;
using BL___Poslovna_Logika;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazinaFilm_SetManager
{
    public partial class frmUnos : Form
    {
        Zaposleni zaposleni = null;
        private int? idScene = null;

        public frmUnos(Zaposleni zaposleni, int idScene)
        {
            InitializeComponent();
            this.zaposleni = zaposleni;
            this.idScene = idScene;
        }

        public frmUnos()
        {
            InitializeComponent();
        }

        private void frmUnos_Load(object sender, EventArgs e)
        {
            if (idScene is null)
            {
                lblNaslov.Text = "Novi zaposleni";

                lblIdScene.Visible = false;
                txtIdScene.Visible = false;
            }
            else
            {
                lblNaslov.Text = "Izmena zaposlenog";
                txtIdScene.Text = this.idScene.ToString();
                txtId.Text = zaposleni.IDZaposleni.ToString();
                txtIme.Text = zaposleni.Ime;
                txtPrezime.Text = zaposleni.Prezime;
                txtRadnoMesto.Text = zaposleni.RadnoMesto;
            }
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (idScene is null)
            {
                ZaposleniService.Instance.InsertZaposleniIntoDb(
                    txtIme.Text,
                    txtPrezime.Text,
                    txtRadnoMesto.Text,
                    idScene is null ? null : (int?)Convert.ToInt32(txtIdScene.Text)
                );

                MessageBox.Show("Zaposleni uspešno dodat.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();
            }
            else
            {
                ZaposleniService.Instance.UpdateZaposleni(
                    Convert.ToInt32(txtId.Text),
                    txtIme.Text,
                    txtPrezime.Text,
                    txtRadnoMesto.Text
                );

                MessageBox.Show("Zaposleni uspešno izmenjen.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();
            }

        }

        private void btnPonisti_Click(object sender, EventArgs e)
        {
            txtId.Text = string.Empty;
            txtIme.Text = string.Empty;
            txtPrezime.Text = string.Empty;
            txtRadnoMesto.Text = string.Empty;
        }
    }
}
