using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkolaJezikaWPF;
using SkolaJezikaConsole;
using System.Windows;
using System.Collections.ObjectModel;

namespace SkolaJezikaWPF.DAO
{
    public class KursDAO
    {
        public static void Read()
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();

                Aplikacija.Instanca.Kursevi = new ObservableCollection<Kurs>();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"Select * from Kurs Where Obrisan = 0";
                SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sqlDA.Fill(ds, "Kursevi");

                foreach (DataRow row in ds.Tables["Kursevi"].Rows)
                {
                    Kurs k = new Kurs();
                    k.Id = (long)row["Id"];

                    Nastavnik n = GetNastavnikByID((long)row["NastavnikID"]);
                    k.Predavac = n;
                    n.Kursevi.Add(k);

                    k.JezikKursa = GetJezikByID((long)row["JezikID"]);
                    k.Tip = GetTipKursaByID((long)row["TipID"]);
                    k.Cena = (double)row["Cena"];

                    SqlCommand cmdPohadja = conn.CreateCommand();
                    cmdPohadja.CommandText = @"Select * from Pohadja Where KursID = @idKursa";
                    cmdPohadja.Parameters.Add(new SqlParameter("@idKursa", k.Id));
                    SqlDataAdapter sqlDAPohadja = new SqlDataAdapter(cmdPohadja);
                    DataSet dsPohadja = new DataSet();
                    sqlDAPohadja.Fill(dsPohadja, "Pohadja");
                    foreach (DataRow pohadjaRow in dsPohadja.Tables["Pohadja"].Rows)
                    {
                        Ucenik u = GetUcenikByID((long)pohadjaRow["UcenikID"]);
                        k.Ucenici.Add(u);
                        u.Kursevi.Add(k);
                    }
                    Aplikacija.Instanca.Kursevi.Add(k);
                }
            }
        }

        public static void Create(Kurs k)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Insert Into Kurs Values (@jezikId, @tipId, @nastavnikId, @cena, 0)";
                cmd.Parameters.Add(new SqlParameter("@jezikId", k.JezikKursa.Id));
                cmd.Parameters.Add(new SqlParameter("@tipId", k.Tip.Id));
                cmd.Parameters.Add(new SqlParameter("@nastavnikId", k.Predavac.Id));
                cmd.Parameters.Add(new SqlParameter("@cena", k.Cena));

                SqlCommand cmdPohadja;
                try
                {
                    cmd.ExecuteNonQuery();
                    foreach (Ucenik u in k.Ucenici)
                    {
                        cmdPohadja = conn.CreateCommand();
                        cmdPohadja.CommandText = "Insert Into Pohadja Values (@ucenikId, (Select IDENT_CURRENT('Kurs')))";
                        cmdPohadja.Parameters.Add(new SqlParameter("@ucenikID", u.Id));
                        cmdPohadja.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "Greska", MessageBoxButton.OK);
                    throw new Exception();
                }

                
            }
        }

        public static void Update(Kurs k)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"Update Kurs Set JezikId=@jezikId, TipId=@tipId, NastavnikId=@nastavnikId, Cena=@cena Where Id=@id";
                cmd.Parameters.Add(new SqlParameter("@jezikId", k.JezikKursa.Id));
                cmd.Parameters.Add(new SqlParameter("@tipId", k.Tip.Id));
                cmd.Parameters.Add(new SqlParameter("@nastavnikId", k.Predavac.Id));
                cmd.Parameters.Add(new SqlParameter("@cena", k.Cena));
                cmd.Parameters.Add(new SqlParameter("@id", k.Id));

                SqlCommand cmdPohadja;
                cmdPohadja = conn.CreateCommand();
                cmdPohadja.CommandText = "Delete Pohadja Where KursId = @kursId";
                cmdPohadja.Parameters.Add(new SqlParameter("@kursID", k.Id));

                try
                {
                    cmd.ExecuteNonQuery();
                    cmdPohadja.ExecuteNonQuery();
                    foreach (Ucenik u in k.Ucenici)
                    {
                        cmdPohadja = conn.CreateCommand();
                        cmdPohadja.CommandText = "Insert Into Pohadja Values (@ucenikId, @kursId)";
                        cmdPohadja.Parameters.Add(new SqlParameter("@ucenikID", u.Id));
                        cmdPohadja.Parameters.Add(new SqlParameter("@kursID", k.Id));
                        cmdPohadja.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "Greska", MessageBoxButton.OK);
                    throw new Exception();
                }
            }
        }

        public static void Delete(Kurs k)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"Update Kurs Set Obrisan = 1 Where Id=@id";
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

        public static Nastavnik GetNastavnikByID(long id)
        {
            Nastavnik retVal = null;
            foreach (Nastavnik k in Aplikacija.Instanca.Nastavnici)
            {
                if (k.Id == id)
                {
                    retVal = k;
                    break;
                }
            }

            return retVal;
        }

        public static Jezik GetJezikByID(long id)
        {
            Jezik retVal = null;
            foreach (Jezik j in Aplikacija.Instanca.Jezici)
            {
                if (j.Id == id)
                {
                    retVal = j;
                    break;
                }
            }

            return retVal;
        }

        public static TipKursa GetTipKursaByID(long id)
        {
            TipKursa retVal = null;
            foreach (TipKursa k in Aplikacija.Instanca.TipoviKursa)
            {
                if (k.Id == id)
                {
                    retVal = k;
                    break;
                }
            }

            return retVal;
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
    }
}
