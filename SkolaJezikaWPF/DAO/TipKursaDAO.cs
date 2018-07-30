using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using SkolaJezikaConsole;
using System.Windows;
using System.Collections.ObjectModel;

namespace SkolaJezikaWPF.DAO
{
    class TipKursaDAO
    {
        public static void Read()
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();
                Aplikacija.Instanca.TipoviKursa = new ObservableCollection<TipKursa>();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"Select * from TipKursa Where Obrisan = 0";
                SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sqlDA.Fill(ds, "tipovi_kursa");

                foreach (DataRow row in ds.Tables["tipovi_kursa"].Rows)
                {
                    TipKursa t = new TipKursa();
                    t.Id = (long)row["Id"];
                    t.Nivo = (string)row["Nivo"];
                    Aplikacija.Instanca.TipoviKursa.Add(t);
                }
            }
        }

        public static void Create(TipKursa t)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Insert Into TipKursa Values (@nivo, 0)";
                cmd.Parameters.Add(new SqlParameter("@nivo", t.Nivo));

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "Greska", MessageBoxButton.OK);
                    throw new Exception();
                }
            }
        }

        public static void Update(TipKursa t)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"Update TipKursa Set Nivo=@nivo Where Id=@id";
                cmd.Parameters.Add(new SqlParameter("@nivo", t.Nivo));
                cmd.Parameters.Add(new SqlParameter("@id", t.Id));

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "Greska", MessageBoxButton.OK);
                    throw new Exception();
                }
            }
        }

        public static void Delete(TipKursa t)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"Update TipKursa Set Obrisan = 1 Where Id=@id";
                cmd.Parameters.Add(new SqlParameter("@id", t.Id));

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "Greska", MessageBoxButton.OK);
                }
            }
        }
    }
}
