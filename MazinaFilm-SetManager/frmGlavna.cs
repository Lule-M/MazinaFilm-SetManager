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

            dgvZaposleni.DataSource = ZaposleniService.Instance.GetAllZaposleni();

            List<Scena> scene = ScenaService.Instance.GetAllScene();

            foreach (Scena s in scene)
            {
                string red = $"{s.RedniBroj} | {s.DobaDana} | {s.DatumSnimanja.ToShortDateString()} | {s.Snimljeno}";
                lbScene.Items.Add(red);
            }

            lbScene.SelectedIndex = 0;
        }

        private void lbScene_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRedniBroj.Text = lbScene.SelectedItem.ToString().Split('|')[0].Trim();
            txtLokacija.Text = lbScene.SelectedItem.ToString().Split('|')[1].Trim();
            txtDatum.Text = lbScene.SelectedItem.ToString().Split('|')[2].Trim();
            cbSnimljeno.Checked = bool.Parse(lbScene.SelectedItem.ToString().Split('|')[3].Trim());
        }
    }
}
