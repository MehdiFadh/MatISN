using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatISN
{
    public class ApplicationData
    {

        private ObservableCollection<Materiel> lesMateriels;
        private NpgsqlConnection connexion = null;   // futur lien à la BD


        public ObservableCollection<Materiel> LesMateriels
        {
            get
            {
                return lesMateriels;
            }

            set
            {
                lesMateriels = value;
            }
        }



        public NpgsqlConnection Connexion
        {
            get
            {
                return this.connexion;
            }

            set
            {
                this.connexion = value;
            }
        }

        public ApplicationData()
        {

            this.ConnexionBD();
            this.Read();
        }
        public void ConnexionBD()
        {
            try
            {
                Connexion = new NpgsqlConnection();
                Connexion.ConnectionString = "Server=srv-peda-new;" +
                                            "port=5433;" +
                                            "Database=SAE204;" +
                                            "Search Path =sae201;" +
                                            "uid=ezzamaso;" +
                                            "password=cAATY1;";
                //à compléter dans les "" 
                // @ sert à enlever tout pb avec les caractères 
                Connexion.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("pb de connexion : " + e);
                // juste pour le debug : à transformer en MsgBox 
            }
        }

        public int Read()
        {
            LesMateriels = new ObservableCollection<Materiel>();
            String sql = "SELECT NUM_MATERIEL, NUM_FOURNISSEUR,CODE_TYPE,DESCRIPTION_MATERIEL,LIEN_PHOTO,MARQUE,DESCRIPTION,PRIX FROM MATERIEL";
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, Connexion);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                foreach (DataRow res in dataTable.Rows)
                {
                    Materiel nouveau = new Materiel(int.Parse(res["NUM_MATERIEL"].ToString()), int.Parse(res["NUM_FOURNISSEUR"].ToString()),
                    res["CODE_TYPE"].ToString(), res["DESCRIPTION_MATERIEL"].ToString(),
                    res["LIEN_PHOTO"].ToString(),
                    res["MARQUE"].ToString(), res["DESCRIPTION"].ToString(), double.Parse(res["PRIX"].ToString()));
                    LesMateriels.Add(nouveau);
                }
                return dataTable.Rows.Count;
            }
            catch (SqlException e)
            { Console.WriteLine("pb de requete : " + e); return 0; }
        }

        public int Create(Commande c)
        {
            String sql = $" ";
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(sql, Connexion);
                int nb = cmd.ExecuteNonQuery();
                return nb;
                //nb permet de connaître le nb de lignes affectées par un insert, update, delete
            }
            catch (Exception sqlE)
            {
                Console.WriteLine("pb de requete : " + sql + "" + sqlE);
                // juste pour le debug : à transformer en MsgBox 
                return 0;
            }
        }

        public int Update(Commande c)
        {
            String sql = $"";
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(sql, Connexion);
                int nb = cmd.ExecuteNonQuery();
                return nb;
                //nb permet de connaître le nb de lignes affectées par un insert, update, delete
            }
            catch (Exception sqlE)
            {
                Console.WriteLine("pb de requete : " + sql + "" + sqlE);
                // juste pour le debug : à transformer en MsgBox 
                return 0;
            }

        }

        public int Delete(Commande c)
        {
            String sql = $"";
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(sql, Connexion);
                int nb = cmd.ExecuteNonQuery();
                return nb;
                //nb permet de connaître le nb de lignes affectées par un insert, update, delete
            }
            catch (Exception sqlE)
            {
                Console.WriteLine("pb de requete : " + sql + "" + sqlE);
                // juste pour le debug : à transformer en MsgBox 
                return 0;
            }

        }



        public void DeconnexionBD()
        {
            try
            {
                Connexion.Close();
            }
            catch (Exception e)
            { Console.WriteLine("pb à la déconnexion : " + e); }
        }

    }
}
