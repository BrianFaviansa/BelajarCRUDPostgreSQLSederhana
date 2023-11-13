using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BelajarCRUDPostgreSQLSederhana.Model;
using Npgsql;

namespace BelajarCRUDPostgreSQLSederhana.Controller
{
    class crud
    {
        koneksi koneksi = new koneksi();


        public bool Simpan(mahasiswa_m mahasiswa)
        {
            Boolean status = false;
            try
            {
                koneksi.openConnection();
                koneksi.executeQuery("INSERT INTO data_mahasiswa (nim, nama, prodi) VALUES ('" + mahasiswa.Nim + "', '" + mahasiswa.Nama + "', '" + mahasiswa.Prodi + "' )");
                status = true;
                MessageBox.Show("Data berhasil ditambahkan", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                koneksi.closeConnection();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return status;
        }

        public bool Ubah(mahasiswa_m mahasiswa, string nim)
        {
            Boolean status = false;
            try
            {
                koneksi.openConnection();
                koneksi.executeQuery("UPDATE data_mahasiswa SET nim='"+ mahasiswa.Nim+"', " + "nama='"+ mahasiswa.Nama+ "', " + "prodi='"+ mahasiswa.Prodi+"' WHERE nim='"+nim +"'");
                status = true;
                MessageBox.Show("Data berhasil diubah", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                koneksi.closeConnection();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return status;
        }

        public bool Hapus(mahasiswa_m mahasiswa, string nim)
        {
            Boolean status = false;
            try
            {
                koneksi.openConnection();
                koneksi.executeQuery("DELETE FROM data_mahasiswa WHERE nim='" + nim + "'");
                status = true;
                MessageBox.Show("Data berhasil dihapus", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                koneksi.closeConnection();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return status;
        }
    }
}
