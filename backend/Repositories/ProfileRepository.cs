using System;
using Microsoft.Data.SqlClient;
using backend.Objects;
using Microsoft.Extensions.Logging;

namespace backend.Repositories
{
    public class ProfileRepository : IProfileRepostory
    {
        private readonly ILogger<ProfileRepository> logger;
        private readonly string connectionString;

        public ProfileRepository(ILogger<ProfileRepository> logger)
        {
            this.logger = logger;
            //TODO: Config
            this.connectionString = "Data Source=localhost;Initial Catalog=podcast_me;Persist Security Info=True;"
                                        + "User ID=sa;Password=Password1";
        }

        public bool Create(ref Profile profile)
        {
            try
            {
                AssertProfileNotExists(profile);
                using (var connection = new SqlConnection(connectionString))
                {
                    var profileId = Guid.NewGuid();
                    var createdOn = DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss");
                    var command = new SqlCommand($"INSERT INTO Profile VALUES ('{profileId.ToString()}', '{profile.Name}', '{profile.Email}', NULL, 'New bio', '{createdOn}');", connection);
                    command.Connection.Open();
                    command.ExecuteNonQuery();

                    profile.ProfileId = profileId.ToString();
                }

                return true;
            }
            catch (Exception e)
            {
                logger.LogError($"Unable to create profile with email {profile.Email}. {e.Message}");
            }

            return false;
        }

        public Profile Get(string id)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    SqlDataReader reader = GetReader(connection, $"SELECT * FROM Profile WHERE ProfileId='{id}'");

                    if (reader.Read())
                    {
                        return new Profile()
                        {
                            ProfileId = reader.GetString(0),
                            Name = reader.GetString(1),
                            Email = reader.GetString(2),
                            ProfilePhoto = reader.GetString(3),
                            Bio = reader.GetString(4),
                            JoinedOn = reader.GetDateTime(5)
                        };
                    }

                    throw new Exception($"No results found for profile id: {id}.");
                }
            }
            catch (Exception e)
            {
                logger.LogError($"Couldn't retrieve profile with id: {id}. {e.Message}");
                return null;
            }
        }

        private void AssertProfileNotExists(Profile profile)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                SqlDataReader reader = GetReader(connection, $"SELECT * FROM Profile WHERE Email='{profile.Email}'");
                if (reader.HasRows)
                {
                    throw new Exception("Profile already exists.");
                }
            }
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