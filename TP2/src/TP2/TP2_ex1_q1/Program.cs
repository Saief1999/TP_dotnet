using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace TP2
{
    class Program
    {

        private static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=db_tp2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static void GetAllUsers()
        {

            string queryString = @" Select id,first_name,last_name,age,phone
                    from dbo.users";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, sqlConnection);
                try
                {
                    // ouverture de la connexion
                    sqlConnection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}",
                            "ID", "Prenom", "Nom", "Age", "Telephone");
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}",
                            reader[0], reader[1], reader[2], reader[3], reader[4]);
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }

            }
        }

        public static void GetUsersByAge(int minAge)
        {
           
            string queryString = @" Select id,first_name,last_name,age,phone
                    from dbo.users
                    where Age <= @Age
                    order by Age Desc";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, sqlConnection);
                command.Parameters.AddWithValue("@Age", minAge);
                try
                {
                    // ouverture de la connexion
                    sqlConnection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}",
                            "ID", "Prenom","Nom" ,"Age", "Telephone");
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}",
                            reader[0], reader[1], reader[2], reader[3],reader[4]);
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }

            }
        }


        public static void AddUser(string firstName,string lastName,int age,int phone)
        {
            string queryString = @" insert into Users(first_name,last_name,age,phone) values 
                                    (@first_name, @last_name, @age, @phone)";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(queryString, sqlConnection);

                command.Parameters.AddWithValue("@first_name", firstName);
                command.Parameters.AddWithValue("@last_name", lastName);
                command.Parameters.AddWithValue("@Age", age);
                command.Parameters.AddWithValue("@phone", phone);

                try
                {
                    sqlConnection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception e )
                {
                    Console.WriteLine(e.Message); 
                }
                finally
                {
                    sqlConnection.Close();
                }

            }

        }
        public static void DelUser(long id)
        {

            string queryString = @" delete from users where id = @id";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(queryString, sqlConnection);

                command.Parameters.AddWithValue("@id", id);


                try
                {
                    sqlConnection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }

            }
        }



        public static void UpdateUser(long id, int newPhone)
        {

            string queryString = @"UPDATE Users SET phone=@phone 
                                   WHERE id=@id ";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(queryString, sqlConnection);

                command.Parameters.AddWithValue("@phone", newPhone);
                command.Parameters.AddWithValue("@id", id);

                try
                {
                    sqlConnection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }

            }
        }


        public static void DisconnectedGetAllUsers()
        {
            SqlConnection userConnection = new SqlConnection(connectionString);

            string queryString = "SELECT id,first_name,last_name,age,phone from Users"; 

            SqlDataAdapter userDataAdapter = new SqlDataAdapter(queryString, userConnection); 


            DataSet userDataSet = new DataSet();

            userDataAdapter.Fill(userDataSet,"users"); 


            foreach (DataRow row in userDataSet.Tables["users"].Rows)
            {
                Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}",
                    row["id"],row["first_name"], row["last_name"], row["age"], row["phone"]);
            }
            
        }

        public static void DisconnectedUpdateUserById(long id,string firstName)
        {

            SqlConnection userConnection = new SqlConnection(connectionString);

            string updateQueryString = "UPDATE users set first_name=@first_name  where id=@id";
            string selectQueryString = "SELECT id, first_name from Users";

            SqlDataAdapter userDataAdapter = new SqlDataAdapter(selectQueryString, userConnection);

            userDataAdapter.UpdateCommand = new SqlCommand(updateQueryString, userConnection);
            userDataAdapter.UpdateCommand.Parameters.AddWithValue("@first_name", firstName);
            userDataAdapter.UpdateCommand.Parameters.AddWithValue("@id", id);

            DataTable usersDataTable = new DataTable();
            userDataAdapter.Fill(usersDataTable);

            var row = usersDataTable.AsEnumerable()
               .SingleOrDefault(r => r.Field<int>("id") == id);

            row["first_name"] = firstName;



            userDataAdapter.Update(usersDataTable); // update the source using the dataAdapter with its dataTable "users"

        }




        public static void GetUserByNameStoredProcedure(long id)
        {
            string queryString = @" Select id,first_name,last_name,age,phone
                    from dbo.users";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, sqlConnection);
                try
                {
                    // ouverture de la connexion
                    sqlConnection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    Console.WriteLine("\t{0}\t{1}",
                            "Prenom", "Nom");
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}",
                            reader[0], reader[1]);
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }

        static void Main(string[] args)
        {

            //addUser("Salah", "Chaabani", 15, 26351548);
            //GetUsersByAge(28);
            //DelUser(1002);
            //Console.WriteLine("-------Utilisateurs aprés supprimer l'utilisateur avec id 1002--------");

            //GetAllUsers();
            //UpdateUser(2, 00000000);
            //Console.WriteLine("-------Utilisateurs aprés modifier le numero de l'utilisateur avec id 2--------");

            //GetAllUsers();


            DisconnectedGetAllUsers();
            DisconnectedUpdateUserById(1, "Ammar");
            Console.WriteLine("-------Utilisateurs aprés modifier le nom de l'utilisateur avec id 1--------");

            DisconnectedGetAllUsers();

        }
    }
}
