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
        private ObservableCollection<Commande> lesCommandes;
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

        public ObservableCollection<Commande> LesCommandes
        {
            get
            {
                return lesCommandes;
            }

            set
            {
                lesCommandes = value;
            }
        }

        public ApplicationData()
        {

            this.ConnexionBD();
            this.Read();
            this.ReadSuivie();
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
                                            $"uid={pageConnection.user};" +
                                            $"password={pageConnection.password};";
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
                    Materiel nouveau = new Materiel(int.Parse(res["NUM_MATERIEL"].ToString()), new Fournisseur() ,
                    new type_materiel(), res["DESCRIPTION_MATERIEL"].ToString(),
                    res["LIEN_PHOTO"].ToString(),
                    res["MARQUE"].ToString(), res["DESCRIPTION"].ToString(), double.Parse(res["PRIX"].ToString()));
                    LesMateriels.Add(nouveau);
                }
                return dataTable.Rows.Count;
            }
            catch (SqlException e)
            { Console.WriteLine("pb de requete : " + e); return 0; }
        }

        public int ReadSuivie()
        {
            LesCommandes = new ObservableCollection<Commande>();
            String sql = "SELECT NUM_TRANSPORT, NUM_CASERNE, DATE_COMMANDE, DATE_LIVRAISON FROM COMMANDE";
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, Connexion);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                foreach (DataRow res in dataTable.Rows)
                {
                    Commande nouveau = new Commande(DateTime.Parse(res["DATE_COMMANDE"].ToString()), DateTime.Parse(res["DATE_LIVRAISON"].ToString()),
                    new Caserne(), new Mode_transport());
                    LesCommandes.Add(nouveau);
                }
                return dataTable.Rows.Count;
            }
            catch (SqlException e)
            { Console.WriteLine("pb de requete : " + e); return 0; }
        }

        public int Create(Commande c)
        {
            String sql = $"insert into commande(num_transport,num_caserne,date_commande,date_livraison) values({c.UnModeTransport.NumTransport},{c.UneCaserne.NumCaserne},{c.DateCommande},{c.DateLivraison})";
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
            String sql = $"update commande set DATE_LIVRAISON = {c.DateLivraison} where NUM_COMMANDE = {c.NumCommande}";
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
            String sql = $"Delete from commande where NUM_COMMANDE = {c.NumCommande}";
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
