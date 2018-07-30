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
    public class KorisnikDAO
    {
        public static void Create(Korisnik k)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "insert into korisnik values (@ime, @prezime, @jmbg, @datum, @kime, @kloz, 0, @ktip)";
                cmd.Parameters.Add(new SqlParameter("@ime", k.Ime));
                cmd.Parameters.Add(new SqlParameter("@prezime", k.Prezime));
                cmd.Parameters.Add(new SqlParameter("@jmbg", k.JMBG));
                cmd.Parameters.Add(new SqlParameter("@datum", k.DatumRodjenja));
                cmd.Parameters.Add(new SqlParameter("@kime", k.KorisnickoIme));
                cmd.Parameters.Add(new SqlParameter("@kloz", k.Lozinka));
                cmd.Parameters.Add(new SqlParameter("@ktip", k.Tip.Id));

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

        public static void Read()
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();
                Aplikacija.Instanca.Korisnici = new ObservableCollection<Korisnik>();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"Select * from korisnik Where Obrisan = 0";

                SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sqlDA.Fill(ds, "korisnici");

                foreach (DataRow row in ds.Tables["korisnici"].Rows)
                {
                    Korisnik k = new Korisnik();
                    k.Id = (long) row["Id"];
                    k.Ime = (string)row["Ime"];
                    k.Prezime = (string)row["Prezime"];
                    k.JMBG = (string)row["JMBG"];
                    k.KorisnickoIme = (string)row["K_Ime"];
                    k.Lozinka = (string)row["lozinka"];
                    k.DatumRodjenja = (DateTime)row["Datum_Rodjenja"];
                    k.Tip = Aplikacija.Instanca.GetByID((long)row["tip_id"]);
                    Aplikacija.Instanca.Korisnici.Add(k);
                }
            }
        }

        public static void Update(Korisnik k) 
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"update korisnik set ime=@ime, prezime=@prezime, jmbg=@jmbg, datum_rodjenja=@datum, k_ime=@kime, lozinka=@kloz, 0, tip_id=@ktip where id=@id";
                cmd.Parameters.Add(new SqlParameter("@ime", k.Ime));
                cmd.Parameters.Add(new SqlParameter("@prezime", k.Prezime));
                cmd.Parameters.Add(new SqlParameter("@jmbg", k.JMBG));
                cmd.Parameters.Add(new SqlParameter("@datum", k.DatumRodjenja));
                cmd.Parameters.Add(new SqlParameter("@kime", k.KorisnickoIme));
                cmd.Parameters.Add(new SqlParameter("@kloz", k.Lozinka));
                cmd.Parameters.Add(new SqlParameter("@id", k.Id));
                cmd.Parameters.Add(new SqlParameter("@ktip", k.Tip.Id));

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

        public static void Delete(Korisnik k)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"Update Korisnik Set Obrisan = 1 Where Id=@id";
                cmd.Parameters.Add(new SqlParameter("@id", k.Id));

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

