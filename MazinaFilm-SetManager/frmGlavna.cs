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

        private void UpdateDataGridView()
        {
            dgvZaposleni.DataSource = ScenaService.Instance.GetScena(int.Parse(txtIdScene.Text)).Zaposleni;
        }

        private void lbScene_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIdScene.Text = lbScene.SelectedItem.ToString().Split('|')[0].Trim();
            txtRedniBroj.Text = lbScene.SelectedItem.ToString().Split('|')[0].Trim();
            txtLokacija.Text = lbScene.SelectedItem.ToString().Split('|')[2].Trim();
            dtpDatumSnimanja.Text = lbScene.SelectedItem.ToString().Split('|')[3].Trim();
            chkSnimljeno.Checked = bool.Parse(lbScene.SelectedItem.ToString().Split('|')[4].Trim());

            UpdateDataGridView();
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
                string red = $"{s.IdScena} | {s.RedniBroj} | {s.DobaDana} | {s.DatumSnimanja.ToShortDateString()} | {s.Snimljeno}";
                lbScene.Items.Add(red);
            }

        }

        private void btnNoviZaposleni_Click(object sender, EventArgs e)
        {       
            Form frmDodajZaposlenog = new frmUnos();
            frmDodajZaposlenog.Text = "Novi zaposleni";
            frmDodajZaposlenog.ShowDialog();

            UpdateDataGridView();
        }

        private void btnIzmeniZaposlenog_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = dgvZaposleni.CurrentCell.RowIndex;
            Zaposleni selectedZaposleni = dgvZaposleni.Rows[selectedRowIndex].DataBoundItem as Zaposleni;

            Form frmIzmeniZaposlenog = new frmUnos(selectedZaposleni, int.Parse(txtIdScene.Text));
            frmIzmeniZaposlenog.Text = "Izmeni zaposlenog";
            frmIzmeniZaposlenog.ShowDialog();

            UpdateDataGridView();
        }

        private void btnObrisiZaposlenog_Click(object sender, EventArgs e)
        {
            int selectedZaposleniId = int.Parse(dgvZaposleni.SelectedRows[0].Cells[0].Value.ToString());

            if (MessageBox.Show($"Da li ste sigurni da želite da obrišete zaposlenog ID {selectedZaposleniId}?", "Brisanje zaposlenog", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            ZaposleniService.Instance.DeleteZaposleni(selectedZaposleniId);
            UpdateDataGridView();
        }

        private void btnXmlSerialization_Click(object sender, EventArgs e)
        {
            if( XML_SerializeService.Instance.SerializeToXML())
            {
                MessageBox.Show("Uspešno serijalizovano u XML.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Greška prilikom serijalizacije u XML.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
