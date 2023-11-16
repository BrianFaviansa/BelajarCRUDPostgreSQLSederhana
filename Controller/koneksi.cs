using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace BelajarCRUDPostgreSQLSederhana.Controller
{
    class koneksi
    {
        string conStr = "Host=localhost;Port=5432;Database=cobaMahasiswa;User Id=postgres;Password=BrianPG3103;";
        NpgsqlConnection con;

        public void openConnection()
        {
            con = new NpgsqlConnection(conStr);
            con.Open();
        }

        public void closeConnection()
        {
            con.Close();
        }

        public void executeQuery(string query)
        {
            NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            cmd.ExecuteNonQuery();
        }

        public object showData(string query)
        {
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, conStr);
            DataSet dataset = new DataSet();

            adapter.Fill(dataset);
            object entity = dataset.Tables[0];
            return entity;
        }
    }
}
