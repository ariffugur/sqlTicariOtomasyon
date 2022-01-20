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
    public partial class FrmStoklar : Form
    {
        public FrmStoklar()
        {
            InitializeComponent();
        }

        sqlBaglantisi bgl = new sqlBaglantisi();
        
        private void FrmStoklar_Load(object sender, EventArgs e)
        {
            chartControl1.Series["Series 1"].Points.AddPoint("İstanbul", 4);
            chartControl1.Series["Series 1"].Points.AddPoint("ankara", 5);
            chartControl1.Series["Series 1"].Points.AddPoint("izmir", 8);
            chartControl1.Series["Series 1"].Points.AddPoint("çorum", 10);

            SqlDataAdapter da = new SqlDataAdapter("Select UrunAd,Sum(Adet) As 'Miktar' from TBL_URUNLER group by UrunAd",
                bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
    }
}
