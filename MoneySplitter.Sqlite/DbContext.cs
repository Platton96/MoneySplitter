using Microsoft.Data.Sqlite;
using System.Threading.Tasks;
using System;

namespace MoneySplitter.Sqlite
{
    public class DbContext
    {
        public SqliteConnection DbConection {get; private set; }

        public DbContext()
        {
            DbConection = new SqliteConnection(Defines.SQlilte.CONECTION_STRING);
        }

        public async Task InitializeAsyns()
        {
            await CreateUsersTableAsync();
        }

        public async Task CreateUsersTableAsync()
        {
            await DbConection.OpenAsync();

            SqliteCommand deleteUsersCommand = new SqliteCommand("DROP TABLE Users;", DbConection);

            try
            {
                await deleteUsersCommand.ExecuteNonQueryAsync();
            }
            catch 
            {

            }

            SqliteCommand createUsersCommand = new SqliteCommand(@"
				CREATE TABLE Users (
				Id int PRIMARY KEY,
				Name nvarchar(255),
				Surname nvarchar(255),
				Email nvarchar(255),
				PhoneNumber bigint,
				CreditCardNumber bigint,
				Token nvarchar(255),
				ImageUrl nvarchar(255),
				BackgroundImageUrl nvarchar(255));",
                DbConection);

            await createUsersCommand.ExecuteNonQueryAsync();
            DbConection.Close();
        }
    }
}
