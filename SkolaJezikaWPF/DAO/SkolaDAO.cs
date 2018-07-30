using SkolaJezikaWPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SkolaJezikaWPF.DAO
{
    public class SkolaDAO
    {
        public static void Read()
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                Aplikacija.Instanca.Skola = new Skola();
                cmd.CommandText = @"Select * From Skola";
                SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();
                sqlDA.Fill(ds, "skola");
                DataRow row = ds.Tables["skola"].Rows[0];

                Skola sk = new Skola();
                sk.Naziv = (string)row["Naziv"];
                sk.Adresa = (string)row["Adresa"];
                sk.Email = (string)row["Email"];
                sk.MaticniBroj = (string)row["MaticniBroj"];
                sk.InternetAdresa = (string)row["InternetAdresa"];
                sk.PIB = (string)row["PIB"];
                sk.Telefon = (string)row["Telefon"];
                sk.ZiroRacun = (string)row["ZiroRacun"];
                Aplikacija.Instanca.Skola = sk;
            }
        }

        public static void Update(Skola sk)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"Update Skola Set Naziv=@naziv, Adresa=@adresa, Telefon=@telefon, InternetAdresa=@internetAdresa, MaticniBroj=@maticniBroj, PIB=@pib, ZiroRacun=@ziroRacun, Email=@email Where Id = 0";
                cmd.Parameters.Add(new SqlParameter("@adresa", sk.Adresa));
                cmd.Parameters.Add(new SqlParameter("@naziv", sk.Naziv));
                cmd.Parameters.Add(new SqlParameter("@telefon", sk.Telefon));
                cmd.Parameters.Add(new SqlParameter("@internetAdresa", sk.InternetAdresa));
                cmd.Parameters.Add(new SqlParameter("@maticniBroj", sk.MaticniBroj));
                cmd.Parameters.Add(new SqlParameter("@pib", sk.PIB));
                cmd.Parameters.Add(new SqlParameter("@ziroRacun", sk.ZiroRacun));
                cmd.Parameters.Add(new SqlParameter("@email", sk.Email));

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
    }
}
