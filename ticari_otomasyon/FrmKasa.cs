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
    public partial class FrmKasa : Form
    {
        public FrmKasa()
        {
            InitializeComponent();
        }
        sqlBaglantisi bgl=new sqlBaglantisi();
        void musteriHareket()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Execute MusteriHareketler", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;

        }
        void firmaHareket()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2=new SqlDataAdapter("Execute FirmaHareketler", bgl.baglanti());
            da2.Fill(dt2);
            gridControl3.DataSource = dt2;
        }
        public String ad;
        private void FrmKasa_Load(object sender, EventArgs e)
        {
            lblAktifKullanici.Text = ad;
            musteriHareket();
            firmaHareket();
            SqlCommand komut1 = new SqlCommand("Select Sum(Tutar) From Tbl_FaturaDetay", bgl.baglanti());
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                lblKasaToplam.Text = dr1[0].ToString()+" TL";
            }
            bgl.baglanti().Close();
            SqlCommand komut2 = new SqlCommand("Select (ELEKTRIK+SU+DOGALGAZ+INTERNET+EKSTRA) from TBL_GIDERLER order by ID asc", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read()) {
                lblOdemeler.Text = dr2[0].ToString()+" TL";

            }
            bgl.baglanti().Close();
            //personel maasları
            SqlCommand komut3 = new SqlCommand("Select Maaslar from TBL_GIDERLER order by ID asc", bgl.baglanti());
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                lblPersonelMaaslari.Text = dr3[0].ToString();
            }
            bgl.baglanti().Close();
            //musteri sayısı
            SqlCommand komut4 = new SqlCommand("Select Count(*) from TBL_MUSTERILER", bgl.baglanti());
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                lblMusteriSayisi.Text = dr4[0].ToString();
            }
            bgl.baglanti().Close();
            //firma sayısı
            SqlCommand komut5 = new SqlCommand("Select Count(*) from TBL_FIRMALAR", bgl.baglanti());
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                lblFirmaSayisi.Text = dr5[0].ToString();
            }
            bgl.baglanti().Close();

            //toplam firma şehir sayısı
            SqlCommand komut6 = new SqlCommand("Select Count(Distinct(IL)) from TBL_FIRMALAR", bgl.baglanti());
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                lblSehirSayisi.Text = dr6[0].ToString();
            }
            bgl.baglanti().Close();

            //toplam müşteri şehir sayısı
            SqlCommand komut7 = new SqlCommand("Select Count(Distinct(IL)) from TBL_MUSTERILER", bgl.baglanti());
            SqlDataReader dr7 = komut7.ExecuteReader();
            while (dr7.Read())
            {
                lblSehirSayisi2.Text = dr7[0].ToString();
            }
            bgl.baglanti().Close();


            //toplam personel sayısı
            SqlCommand komut8 = new SqlCommand("Select Count(*) from TBL_PERSONELLER", bgl.baglanti());
            SqlDataReader dr8 = komut8.ExecuteReader();
            while (dr8.Read())
            {
                lblPersonelSayisi.Text = dr8[0].ToString();
            }
            bgl.baglanti().Close();

            //toplam ürün sayısı
            SqlCommand komut9 = new SqlCommand("Select SUM(Adet) from TBL_URUNLER", bgl.baglanti());
            SqlDataReader dr9 = komut9.ExecuteReader();
            while (dr9.Read())
            {
                lblStokSayisi.Text = dr9[0].ToString();
            }
            bgl.baglanti().Close();
        }
    }
}
