using BelajarCRUDPostgreSQLSederhana.Controller;
using BelajarCRUDPostgreSQLSederhana.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BelajarCRUDPostgreSQLSederhana
{
    public partial class Form1 : Form
    {
        koneksi koneksi = new koneksi();
        mahasiswa_m mahasiswa = new mahasiswa_m();
        string nimUbah;
        public Form1()
        {
            InitializeComponent();
            cbxProdi.Items.Add("Sistem Informasi");
            cbxProdi.Items.Add("Teknologi Informasi");
            cbxProdi.Items.Add("Informatika");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tampilkanData();
        }

        public void tampilkanData()
        {
            dataGridView1.DataSource = koneksi.showData("SELECT * FROM data_mahasiswa ORDER BY nim") ;

            dataGridView1.Columns[0].HeaderText = "NIM";
            dataGridView1.Columns[1].HeaderText = "Nama Mahasiswa";
            dataGridView1.Columns[2].HeaderText = "Program Studi";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbxNama.Text == "" || tbxNim.Text == "" || cbxProdi.SelectedIndex == -1)
            {
                MessageBox.Show("Data tidak boleh kosong~", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                crud crud = new crud();
                mahasiswa.Nim = tbxNim.Text;
                mahasiswa.Nama = tbxNama.Text;
                mahasiswa.Prodi = cbxProdi.SelectedItem.ToString(); 
                crud.Simpan(mahasiswa);
                tbxNim.Text = "";
                tbxNama.Text = "";
                cbxProdi.SelectedIndex = -1;

                tampilkanData();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (tbxNama.Text == "" || tbxNim.Text == "" || cbxProdi.SelectedIndex == -1)
            {
                MessageBox.Show("Data tidak boleh kosong~", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                crud crud = new crud();
                mahasiswa.Nim = tbxNim.Text;
                mahasiswa.Nama = tbxNama.Text;
                mahasiswa.Prodi = cbxProdi.SelectedItem.ToString();

                crud.Ubah(mahasiswa, nimUbah);
                tbxNim.Text = "";
                tbxNama.Text = "";
                cbxProdi.SelectedIndex = -1;

                tampilkanData();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            nimUbah = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            tbxNim.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            tbxNama.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            cbxProdi.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult pesan = MessageBox.Show("Yakin ingin menghapus data ini?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (pesan == DialogResult.Yes)
            {
                crud crud = new crud();
                crud.Hapus(mahasiswa, nimUbah);
                tampilkanData();
            }
        }

        private void tbxCari_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = koneksi.showData("SELECT * FROM data_mahasiswa WHERE nim LIKE '%" + tbxCari.Text + "%' OR LOWER(nama) LIKE '%" + tbxCari.Text + "%' OR UPPER(nama) LIKE '%" + tbxCari.Text + "%'");
        }
    }
}
