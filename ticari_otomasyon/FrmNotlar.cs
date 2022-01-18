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
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }
        sqlBaglantisi bgl = new sqlBaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Notlar", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;

        }

        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_NOTLAR (TARIH,SAAT,BASLIK,DETAY,OLUSTURAN,HITAP) VALUES (@P1,@P2,@P3,@P4,@P5,@p6)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",MskTarih.Text);
            komut.Parameters.AddWithValue("@p2", MskSaat.Text);
            komut.Parameters.AddWithValue("@p3", TxtBaslik.Text);
            komut.Parameters.AddWithValue("@p4", RchDetay.Text);
            komut.Parameters.AddWithValue("@p5", TxtOlusturan.Text);
            komut.Parameters.AddWithValue("@p6", TxtHitap.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            listele();
            MessageBox.Show("Not Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
