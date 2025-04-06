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
    public partial class frmGlavna : Form
    {
        public frmGlavna()
        {
            InitializeComponent();
            dgvZaposleni.DataSource = ZaposleniService.Instance.GetAllZaposleni();
        }
    }
}
