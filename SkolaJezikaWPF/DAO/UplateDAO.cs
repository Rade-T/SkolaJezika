using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SkolaJezikaWPF;
using SkolaJezikaConsole;
using System.Windows;
using System.Collections.ObjectModel;

namespace SkolaJezikaWPF.DAO
{
    class UplateDAO
    {
        public static void Read()
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();

                Aplikacija.Instanca.Uplate = new ObservableCollection<Uplata>();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"Select * from Uplata Where Obrisan = 0";
                SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sqlDA.Fill(ds, "Uplate");

                foreach (DataRow row in ds.Tables["Uplate"].Rows)
                {
                    Uplata u = new Uplata();
                    u.Id = (long)row["Id"];
                    Ucenik ucenik = GetUcenikByID((long)row["UcenikID"]);
                    ucenik.Uplate.Add(u);
                    u.Ucenik = ucenik;
                    u.Kurs = GetKursByID((long)row["KursID"]);
                    u.Datum = (DateTime)row["DatumUplate"];
                    u.Cena = (double)row["Cena"];

                    Aplikacija.Instanca.Uplate.Add(u);
                }
            }
        }

        public static void Create(Uplata u)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Insert Into Uplata Values (@kursId, @ucenikId, @datum, @cena, 0)";
                cmd.Parameters.Add(new SqlParameter("@kursId", u.Kurs.Id));
                cmd.Parameters.Add(new SqlParameter("@ucenikId", u.Ucenik.Id));  
                cmd.Parameters.Add(new SqlParameter("@datum", u.Datum));
                cmd.Parameters.Add(new SqlParameter("@cena", u.Cena));

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

        public static void Update(Uplata u)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"Update Uplata Set KursId=@kursId, UcenikId=@ucenikId, DatumUplate=@datum, Cena=@cena Where Id=@id";
                cmd.Parameters.Add(new SqlParameter("@kursId", u.Kurs.Id));
                cmd.Parameters.Add(new SqlParameter("@ucenikId", u.Ucenik.Id));
                cmd.Parameters.Add(new SqlParameter("@datum", u.Datum));
                cmd.Parameters.Add(new SqlParameter("@cena", u.Cena));
                cmd.Parameters.Add(new SqlParameter("@id", u.Id));

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

        public static void Delete(Uplata u)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"Update Uplata Set Obrisan = 1 Where Id=@id";
                cmd.Parameters.Add(new SqlParameter("@id", u.Id));

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

        public static Ucenik GetUcenikByID(long id)
        {
            Ucenik retVal = null;
            foreach (Ucenik u in Aplikacija.Instanca.Ucenici)
            {
                if (u.Id == id)
                {
                    retVal = u;
                    break;
                }
            }

            return retVal;
        }

        public static Kurs GetKursByID(long id)
        {
            Kurs retVal = null;
            foreach (Kurs u in Aplikacija.Instanca.Kursevi)
            {
                if (u.Id == id)
                {
                    retVal = u;
                    break;
                }
            }

            return retVal;
        }
    }
}
