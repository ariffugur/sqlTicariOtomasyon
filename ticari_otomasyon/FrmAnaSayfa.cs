using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ticari_otomasyon
{
    public partial class FrmAnaSayfa : Form
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }

        sqlBaglantisi bgl = new sqlBaglantisi();
        void stoklar()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select URUNAD,Sum(Adet) as 'Adet' From TBL_URUNLER group by URUNAD having Sum(ADET) <= 20 order by Sum(ADET)", bgl.baglanti());
            da.Fill(dt);
            gridControlStoklar.DataSource = dt;
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {
            stoklar();
        }
    }
}
