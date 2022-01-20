﻿using System;
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
    public partial class FrmAyarlar : Form
    {
        public FrmAyarlar()
        {
            InitializeComponent();
        }
        sqlBaglantisi bgl = new sqlBaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBL_ADMIN",bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void FrmAyarlar_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void Btnİslem_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_ADMIN values (@p1,@p2)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtKulAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtPass.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Yeni Admin Sisteme Kaydedildi", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }
    }
}