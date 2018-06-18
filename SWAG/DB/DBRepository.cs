namespace SWAG
{
    using Dapper;
    using Microsoft.Extensions.Options;
    using SWAG.DB;
    using SWAG.DB.Entity;
    using SWAG.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;

    public class DBRepository : IDBRepository
    {
        string _connString;

        public DBRepository(IOptions<StorageOptions> settings)
        {
            _connString = settings.Value.DefaultConnection;
        }

        public void SaveResult(Result item)
        {
            using (IDbConnection db = new SqlConnection(_connString))
            {
                var sqlQuery = "INSERT INTO Result (Id, Value, CreatedAt) VALUES(@Id, @Value, @CreatedAt)";
                db.Query(sqlQuery, item);
            }
        }

        public double? FindResultById(Guid id)
        {
            using (IDbConnection db = new SqlConnection(_connString))
            {
                var result = db.Query<Result>("SELECT * FROM Result WHERE Id = @id", new { id }).FirstOrDefault();
                return result?.Value;
            }
        }
    }
}
