using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions;
using Dapper;
using System.Data;
using Npgsql;
using Cytel.Top.Model;
using Microsoft.Extensions.Configuration;

namespace Cytel.Top.Repository
{
    public class StudyRepository  : IRepository<Study>
    {
        private string connectionString;
        public StudyRepository(IConfiguration configuration)
        {
           // connectionString = configuration.GetValue<string>("DBInfo:ConnectionString");
            connectionString = "User ID=postgres;Password=Emids123;Host=localhost;Port=5432;Database=postgres;";
        }

        internal IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection(connectionString);
            }
        }

        public void Add(Study item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                // dbConnection.Execute("INSERT INTO customer (name,phone,email,address) VALUES(@Name,@Phone,@Email,@Address)", item);
                dbConnection.Execute("INSERT INTO public.\"Inputs\"(\"StudyName\",\"StudyStartDate\",\"EstimatedCompletionDate\",\"ProtocolID\",\"StudyGroup\",\"Phase\",\"PrimaryIndication\",\"SecondaryIndication\") VALUES(@StudyName,@StudyStartDate,@EstimatedCompletionDate,@ProtocolID,@StudyGroup,@Phase, @PrimaryIndication, @SecondaryIndication);", item);
            }

        }

        public IEnumerable<Study> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Study>("SELECT * FROM public.\"Inputs\"");
            }
        }

        public Study FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Study>("SELECT * FROM public.\"Inputs\" WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }

        public void Remove(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM customer WHERE Id=@Id", new { Id = id });
            }
        }

        public void Update(Study item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Query("UPDATE customer SET name = @Name,  phone  = @Phone, email= @Email, address= @Address WHERE id = @Id", item);
            }
        }
    }
}
