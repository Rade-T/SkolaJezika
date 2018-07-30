using SkolaJezikaConsole;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkolaJezikaWPF;
using System.Windows;
using System.Collections.ObjectModel;

namespace SkolaJezikaWPF.DAO
{
    class NastavnikDAO
    {
        public static void Read()
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();

                Aplikacija.Instanca.Nastavnici = new ObservableCollection<Nastavnik>();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"Select * from Nastavnik Where Obrisan = 0";
                SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sqlDA.Fill(ds, "nastavnici");

                foreach (DataRow row in ds.Tables["nastavnici"].Rows)
                {
                    Nastavnik n = new Nastavnik();
                    n.Id = (long)row["Id"];
                    n.Ime = (string)row["Ime"];
                    n.Prezime = (string)row["Prezime"];
                    n.JMBG = (string)row["JMBG"];
                    n.Kursevi = new ObservableCollection<Kurs>();
                    n.Ucenici = new ObservableCollection<Ucenik>();

                    foreach (Kurs kurs in Aplikacija.Instanca.Kursevi)
                    {
                        if (kurs.Predavac.Id == n.Id)
                        {
                            n.Kursevi.Add(kurs);
                            foreach (Ucenik ucenik in kurs.Ucenici)
                            {
                                if (GetUcenikByID(ucenik.Id, n.Ucenici) == null)
                                {
                                    n.Ucenici.Add(ucenik);
                                }
                            }
                        }
                    }

                    Aplikacija.Instanca.Nastavnici.Add(n);
                }
            }
        }

        public static void Create(Nastavnik n)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Insert Into Nastavnik Values (@ime, @prezime, @jmbg, 0)";
                cmd.Parameters.Add(new SqlParameter("@ime", n.Ime));
                cmd.Parameters.Add(new SqlParameter("@prezime", n.Prezime));
                cmd.Parameters.Add(new SqlParameter("@jmbg", n.JMBG));

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "Greska", MessageBoxButton.OK);
                    throw new Exception("Greska prilikom dodavanja nastavnika");
                }
            }
        }

        public static void Update(Nastavnik n)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"Update Nastavnik Set Ime=@ime, Prezime=@prezime, JMBG=@jmbg Where Id=@id";
                cmd.Parameters.Add(new SqlParameter("@ime", n.Ime));
                cmd.Parameters.Add(new SqlParameter("@prezime", n.Prezime));
                cmd.Parameters.Add(new SqlParameter("@jmbg", n.JMBG));
                cmd.Parameters.Add(new SqlParameter("@id", n.Id));

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

        public static void Delete(Nastavnik n)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"Update Nastavnik Set Obrisan = 1 Where Id=@id";
                cmd.Parameters.Add(new SqlParameter("@id", n.Id));

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

        public static Ucenik GetUcenikByID(long id, ObservableCollection<Ucenik> ucenici)
        {
            Ucenik retVal = null;
            
            foreach (Ucenik u in ucenici)
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
