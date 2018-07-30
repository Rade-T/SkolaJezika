using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkolaJezikaConsole;
using System.Windows;
using System.Collections.ObjectModel;

namespace SkolaJezikaWPF.DAO
{
    class UcenikDAO
    {
        public static void Read()
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();

                Aplikacija.Instanca.Ucenici = new ObservableCollection<Ucenik>();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"Select * from Ucenik Where Obrisan = 0";

                SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sqlDA.Fill(ds, "Ucenici");

                foreach (DataRow row in ds.Tables["Ucenici"].Rows)
                {
                    Ucenik u = new Ucenik();
                    u.Id = (long) row["Id"];
                    u.Ime = (string)row["Ime"];
                    u.Prezime = (string)row["Prezime"];
                    u.JMBG = (string)row["JMBG"];
                    u.Kursevi = new ObservableCollection<Kurs>();
                    u.Uplate = new ObservableCollection<Uplata>();

                    foreach (Kurs k in Aplikacija.Instanca.Kursevi)
                    {
                        foreach (Ucenik ucenikKursa in k.Ucenici)
                        {
                            if (ucenikKursa.Id == u.Id)
                            {
                                u.Kursevi.Add(k);
                            }
                        }
                    }

                    foreach (Uplata uplata in Aplikacija.Instanca.Uplate)
                    {
                        if (uplata.Ucenik.Id == u.Id)
                        {
                            u.Uplate.Add(uplata);
                        }
                    }

                    Aplikacija.Instanca.Ucenici.Add(u);
                }
            }
        }

        public static void Create(Ucenik n)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Insert Into Ucenik Values (@ime, @prezime, @jmbg, 0)";
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
                    throw new Exception();
                }
            }
        }

        public static void Update(Ucenik n)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"Update Ucenik Set Ime=@ime, Prezime=@prezime, JMBG=@jmbg Where Id=@id";
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

        public static void Delete(Ucenik u)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"Update Ucenik Set Obrisan = 1 Where Id=@id";
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
    }
}
