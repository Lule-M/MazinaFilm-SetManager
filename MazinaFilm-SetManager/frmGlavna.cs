using BL___Poslovna_Logika;
using Shared;
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
    public partial class frmGlavna : Form
    {
        public frmGlavna()
        {
            InitializeComponent();

            lbScene.Font = new Font("Courier", 10, FontStyle.Bold);

            List<Scena> scene = ScenaService.Instance.GetAllScene();

            FillSceneListBox(scene);

            lbScene.SelectedIndex = 0;

            cbLokacija.ValueMember = "IDLokacija";
            cbLokacija.DisplayMember = "Naziv";
            cbLokacija.DataSource = LokacijaService.Instance.GetAllLokacije();
            cbLokacija.SelectedIndex = 0;
        }

        private void lbScene_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRedniBroj.Text = lbScene.SelectedItem.ToString().Split('|')[0].Trim();
            txtLokacija.Text = lbScene.SelectedItem.ToString().Split('|')[1].Trim();
            dtpDatumSnimanja.Text = lbScene.SelectedItem.ToString().Split('|')[2].Trim();
            chkSnimljeno.Checked = bool.Parse(lbScene.SelectedItem.ToString().Split('|')[3].Trim());

            dgvZaposleni.DataSource = ScenaService.Instance.GetScena(int.Parse(txtRedniBroj.Text)).Zaposleni;
        }

        private void cbLokacija_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (cb.SelectedItem == null)
                return;

            lbScene.Items.Clear();

            List<Scena> scene = ScenaService.Instance.GetAllScene((int)cbLokacija.SelectedValue);

            FillSceneListBox(scene);
            lbScene.SelectedIndex = 0;
        }

        private void FillSceneListBox(List<Scena> scene)
        {
            foreach (Scena s in scene)
            {
                string red = $"{s.RedniBroj} | {s.DobaDana} | {s.DatumSnimanja.ToShortDateString()} | {s.Snimljeno}";
                lbScene.Items.Add(red);
            }

        }
    }
}
