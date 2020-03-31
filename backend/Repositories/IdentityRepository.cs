using System;
using Microsoft.Data.SqlClient;
using backend.Objects;
using Microsoft.Extensions.Logging;

namespace backend.Repositories
{
    public class IdentityRepository : IIdentityRepository
    {
        private readonly ILogger<IdentityRepository> logger;
        private readonly string connectionString;

        public IdentityRepository(ILogger<IdentityRepository> logger)
        {
            this.logger = logger;
            //TODO: Config
            this.connectionString = "Data Source=localhost;Initial Catalog=podcast_me;Persist Security Info=True;"
                                        + "User ID=sa;Password=Password1";
        }
        public bool Create(IdentityInformation identity)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var query = $"INSERT INTO IdentityInformation VALUES ('{identity.ProfileId}', '{identity.Email}', '{identity.PasswordHash}');";
                    var command = new SqlCommand(query, connection);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception e)
            {
                logger.LogError($"Couldn't create identity for email {identity.Email}. {e.Message}");
            }

            return false;
        }

        public bool Delete(IdentityInformation identity)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var query = $"DELETE FROM IdentityInformation WHERE ProfileId='{identity.ProfileId}';";
                    var command = new SqlCommand(query, connection);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception e)
            {
                logger.LogError($"Couldn't delete identity for email {identity.Email}. {e.Message}");
            }

            return false;
        }

        public IdentityInformation GetForEmail(string email)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var query = $"SELECT * FROM IdentityInformation WHERE Email='{email}';";
                    var command = new SqlCommand(query, connection);
                    command.Connection.Open();
                    var reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        return new IdentityInformation()
                        {
                            ProfileId = reader.GetString(0),
                            Email = reader.GetString(1),
                            PasswordHash = reader.GetString(2)
                        };
                    }

                    throw new Exception("Identity not found.");
                }
            }
            catch (Exception e)
            {
                logger.LogError($"Couldn't retrieve identity for email {email}. {e.Message}");
                return null;
            }
        }

        public IdentityInformation Update(IdentityInformation identity)
        {
            throw new NotImplementedException();
        }

        private static SqlDataReader GetReader(SqlConnection connection, string query)
        {
            var command = new SqlCommand(query, connection);
            command.Connection.Open();
            var reader = command.ExecuteReader();
            return reader;
        }
    }
}