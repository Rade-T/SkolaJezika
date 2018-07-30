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
    class JezikDAO
    {
        public static void Read()
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                Aplikacija.Instanca.Jezici = new ObservableCollection<Jezik>();
                cmd.CommandText = @"Select * from Jezik Where Obrisan = 0";
                SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sqlDA.Fill(ds, "jezici");

                foreach (DataRow row in ds.Tables["jezici"].Rows)
                {
                    Jezik j = new Jezik();
                    j.Id = (long)row["Id"];
                    j.Naziv = (string)row["Naziv"];
                    j.Oznaka = (string)row["Oznaka"];
                    Aplikacija.Instanca.Jezici.Add(j);
                }
            }
        }

        public static void Create(Jezik j)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Insert Into Jezik Values (@naziv, @oznaka, 0)";
                cmd.Parameters.Add(new SqlParameter("@naziv", j.Naziv));
                cmd.Parameters.Add(new SqlParameter("@oznaka", j.Oznaka));

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

        public static void Update(Jezik j)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"Update Jezik Set Naziv=@naziv, Oznaka=@oznaka Where Id=@id";
                cmd.Parameters.Add(new SqlParameter("@naziv", j.Naziv));
                cmd.Parameters.Add(new SqlParameter("@oznaka", j.Oznaka));
                cmd.Parameters.Add(new SqlParameter("@id", j.Id));

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

        public static void Delete(Jezik j)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"Update Jezik Set Obrisan = 1 Where Id=@id";
                cmd.Parameters.Add(new SqlParameter("@id", j.Id));

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
