using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarCRUDPostgreSQLSederhana.Model
{
    class mahasiswa_m
    {
        string nim, nama, prodi;
        public mahasiswa_m() { }

        public mahasiswa_m(string nim, string nama, string prodi)
        {
            this.Nim = nim;
            this.Nama = nama;
            this.Prodi = prodi;
        }

        public string Nim { get => nim; set => nim = value; }
        public string Nama { get => nama; set => nama = value; }
        public string Prodi { get => prodi; set => prodi = value; }
    }
}
