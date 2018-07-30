using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkolaJezikaConsole;
using System.Data;
using System.Windows;
using System.Collections.ObjectModel;

namespace SkolaJezikaWPF.DAO
{
    public class TipKorisnikaDAO
    {
        public static void Read()
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();

                Aplikacija.Instanca.TipoviKorisnika = new ObservableCollection<TipKorisnika>();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"Select * from tip_korisnika Where Obrisan = 0";

                SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sqlDA.Fill(ds, "tipovi");

                foreach (DataRow row in ds.Tables["tipovi"].Rows)
                {
                    TipKorisnika t = new TipKorisnika();
                    t.Id = (long) row["id"];
                    t.Naziv = (string)row["Naziv"];
                    t.Opis = (string)row["Opis"];
                    Aplikacija.Instanca.TipoviKorisnika.Add(t);
                }
            }
        }

        public static void Create(TipKorisnika t)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "insert into tip_korisnika values (@naziv, @opis, 0)";
                cmd.Parameters.Add(new SqlParameter("@naziv", t.Naziv));
                cmd.Parameters.Add(new SqlParameter("@opis", t.Opis));

                try
                {
                    cmd.ExecuteNonQuery();
                    t.Id = getId("tip_korisnika");
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "Greska", MessageBoxButton.OK);
                    throw new Exception();
                }
            }
        }

        public static void Delete(TipKorisnika t)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"Update Tip_Korisnika Set Obrisan = 1 Where Id=@id";
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

        private static long getId(string table)
        {
            long retVal = -1;
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select ident_current('" + table + "')";

                retVal = Convert.ToInt64(cmd.ExecuteScalar());
            }
            return retVal;
        }
    }
}
