using System;
using Microsoft.Data.SqlClient;
using backend.Objects;
using Microsoft.Extensions.Logging;

namespace backend.Repositories
{
    public class ProfileRepository : IRepository<Profile>
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

        public Profile Get(string id)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var command = new SqlCommand($"SELECT * FROM PROFILE WHERE ProfileId='{id}'", connection);
                    command.Connection.Open();
                    var reader = command.ExecuteReader();

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
    }
}