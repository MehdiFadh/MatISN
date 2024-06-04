using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatISN
{
    public abstract class Table
    {
        private NpgsqlConnection connexion = null;
        String sql;

        public NpgsqlConnection Connexion
        {
            get
            {
                return connexion;
            }

            set
            {
                connexion = value;
            }
        }

        public string Sql
        {
            get
            {
                return sql;
            }

            set
            {
                sql = value;
            }
        }

        public Table()
        {
            this.ConnexionBD();
        }


        public void ConnexionBD()
        {
            try
            {
                Connexion = new NpgsqlConnection();
                Connexion.ConnectionString = "Server=srv-peda-new;" +
                                            "port=5433;" +
                                            "Database=TD3;" +
                                            "Search Path = SAE204;" +
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

        public virtual int Create()
        {
            
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(this.Sql, Connexion);
                int nb = cmd.ExecuteNonQuery();
                return nb;
                //nb permet de connaître le nb de lignes affectées par un insert, update, delete
            }
            catch (Exception sqlE)
            {
                Console.WriteLine("pb de requete : " + this.Sql + "" + sqlE);
                // juste pour le debug : à transformer en MsgBox 
                return 0;
            }
        }

        public virtual int Update()
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(this.Sql, Connexion);
                int nb = cmd.ExecuteNonQuery();
                return nb;
                //nb permet de connaître le nb de lignes affectées par un insert, update, delete
            }
            catch (Exception sqlE)
            {
                Console.WriteLine("pb de requete : " + this.Sql + "" + sqlE);
                // juste pour le debug : à transformer en MsgBox 
                return 0;
            }

        }

        public virtual int Delete()
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(this.Sql, Connexion);
                int nb = cmd.ExecuteNonQuery();
                return nb;
                //nb permet de connaître le nb de lignes affectées par un insert, update, delete
            }
            catch (Exception sqlE)
            {
                Console.WriteLine("pb de requete : " + this.Sql + "" + sqlE);
                // juste pour le debug : à transformer en MsgBox 
                return 0;
            }

        }
    }
}
