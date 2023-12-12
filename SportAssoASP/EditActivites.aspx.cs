using SportAssoASP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportAssoASP
{
    public partial class EditActivites : System.Web.UI.Page
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Vérifier si l'identifiant de l'activité est passé dans l'URL
                if (Request.QueryString["activiteID"] != null)
                {
                    int activiteID = Convert.ToInt32(Request.QueryString["activiteID"]);
                    List<Employe> employes = GetEmployesFromDatabase();

                    // Remplir le DropDownList avec les données des employés
                    EditEmploye.DataSource = employes;
                    EditEmploye.DataTextField = "NomPrenom"; // Champ affiché (nom de l'employé)
                    EditEmploye.DataValueField = "EmployeID"; // Champ valeur (id de l'employé)
                    EditEmploye.DataBind();

                    // Charger les données de l'activité depuis la base de données
                    LoadActiviteData(activiteID);
                }
            }
        }

        private void LoadActiviteData(int activiteID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string selectQuery = "SELECT Sport, Section, Jour, Heure, Prix, Capacite_max, EmployeID FROM Activites WHERE ActiviteID = @ActiviteID";

                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ActiviteID", activiteID);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Remplir les contrôles de la page avec les données de l'activité
                                EditSport.SelectedValue = reader["Sport"].ToString();
                                EditSection.SelectedValue = reader["Section"].ToString();
                                EditJour.SelectedValue = reader["Jour"].ToString();
                                EditHeure.SelectedValue = reader["Heure"].ToString();
                                Prix.Text = reader["Prix"].ToString();
                                CapMax.Text = reader["Capacite_max"].ToString();
                                // Charger la liste des employés (assurez-vous que la méthode existe dans votre code)
                                GetEmployesFromDatabase();
                                // Sélectionner l'employé associé à l'activité
                                EditEmploye.SelectedValue = reader["EmployeID"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Gestion des erreurs
                ErreurMessage.Text = "Erreur lors du chargement des données : " + ex.Message;
            }
        }

        public List<Employe> GetEmployesFromDatabase()
        {
            // Logique pour récupérer les données des employés depuis la base de données externe
            // Retournez une liste d'objets Employe
            List<Employe> employes = new List<Employe>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Remplacez "VotreTable" par le nom réel de votre table des employés
                string query = "SELECT EmployeID, CONCAT(Nom, ' ', Prenom) AS NomPrenom FROM Employes";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Employe employe = new Employe
                            {
                                EmployeID = Convert.ToInt32(reader["EmployeID"]),
                                //Nom = reader["Nom"].ToString(),
                                //Prenom = reader["Prenom"].ToString(),
                                NomPrenom = reader["NomPrenom"].ToString(),
                            };

                            employes.Add(employe);
                        }
                    }
                }
            }

            return employes;
        }
        //protected void DataGrid_UpdateCommand(object sender, EventArgs e)
        //{
        //    // Récupérer les valeurs mises à jour depuis les contrôles du DataGrid
        //    string sport = EditSport.SelectedValue;
        //    string section = EditSection.SelectedValue;
        //    string jour = EditJour.SelectedValue;
        //    string heure = EditHeure.SelectedValue;
        //    float prix = float.Parse(Prix.Text);
        //    int capaciteMax = Convert.ToInt32(CapMax.Text);
        //    int employeId = Convert.ToInt32(EditEmploye.SelectedValue);

        //    // Mettre à jour l'enregistrement dans la base de données
        //    UpdateActiviteInDatabase(sport, section, jour, heure, prix, capaciteMax, employeId);

        //    // Rafraîchir le DataGrid après la mise à jour
        //    DataGrid.EditItemIndex = -1; // Sortir du mode édition
        //    BindDataGrid(); // Mettre à jour les données dans le DataGrid
        //}

        //private void UpdateActiviteInDatabase(string sport, string section, string jour, string heure, float prix, int capaciteMax, int employeId)
        //{
        //    // Ajouter la logique pour mettre à jour l'enregistrement dans la base de données
        //    // Utilisez la connexion à la base de données et exécutez la requête de mise à jour
        //    // Assurez-vous de gérer les erreurs et de fermer la connexion correctement
        //    // ...

        //    // Exemple de requête de mise à jour (à adapter en fonction de votre schéma de base de données)
        //    string updateQuery = "UPDATE Activites SET Sport = @Sport, Section = @Section, Jour = @Jour, " +
        //        "Heure = @Heure, Prix = @Prix, Capacite_max = @Capacite_max, EmployeID = @EmployeID WHERE ActiviteID = @ActiviteID";

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        using (SqlCommand command = new SqlCommand(updateQuery, connection))
        //        {
        //            // Paramètres de la requête
        //            command.Parameters.AddWithValue("@Sport", sport);
        //            command.Parameters.AddWithValue("@Section", section);
        //            command.Parameters.AddWithValue("@Jour", jour);
        //            command.Parameters.AddWithValue("@Heure", heure);
        //            command.Parameters.AddWithValue("@Prix", prix);
        //            command.Parameters.AddWithValue("@Capacite_max", capaciteMax);
        //            command.Parameters.AddWithValue("@EmployeID", employeId);

        //            // Ajouter d'autres paramètres selon votre schéma de base de données
        //            command.Parameters.AddWithValue("@ActiviteID", 1);

        //            connection.Open();
        //            command.ExecuteNonQuery();
        //            connection.Close();
        //        }
        //    }
        //    UpdateGridViewInActivites();

        //    // ...
        //}

        //private void BindDataGrid()
        //{
        //    try
        //    {
        //        // Connexion à la base de données
        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            // Requête de sélection
        //            string selectQuery = "SELECT ActiviteID, Sport, Section, Jour, Heure, Prix, Capacite_max, EmployeID FROM Activites";

        //            // Création de la commande SQL
        //            using (SqlCommand command = new SqlCommand(selectQuery, connection))
        //            {
        //                // Ouverture de la connexion
        //                connection.Open();

        //                // Exécution de la commande SQL
        //                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
        //                {
        //                    // Création d'un DataTable pour stocker les résultats de la requête
        //                    DataTable dataTable = new DataTable();

        //                    // Remplissage du DataTable avec les résultats de la requête
        //                    dataAdapter.Fill(dataTable);

        //                    // Mettre à jour la source de données du GridView avec le DataTable
        //                    GridActivites.DataSource = dataTable;
        //                    GridActivites.DataBind();
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Gestion des erreurs (vous pouvez ajouter un label ou une autre méthode pour afficher l'erreur)
        //        lblErreur.Text = "Erreur lors du chargement des données : " + ex.Message;
        //    }
        //}
        //private void UpdateGridViewInActivites()
        //{
        //    // Vous devez accéder à la GridView dans activites.aspx
        //    // Vous pouvez le faire en utilisant le MasterPage ou par un autre moyen
        //    // Voici un exemple hypothétique, ajustez-le en fonction de votre structure

        //    // Supposons que votre GridView dans activites.aspx a un ID "DataGridActivites"
        //    GridView gridInActivites = (GridView)Master.FindControl("MainContent").FindControl("DataGridActivites");

        //    if (gridInActivites != null)
        //    {
        //        // Appelez la méthode de liaison de votre GridView dans activites.aspx
        //        BindDataGridInActivites(gridInActivites);
        //    }
        //}

    }
}