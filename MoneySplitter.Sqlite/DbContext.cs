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
            await CreateTableAsync(Defines.SQlilte.TableNammes.USERS, createUsersCommand);
        }

        public async Task CreateFriendsTableAsync()
        {
            SqliteCommand createFriendsCommand = new SqliteCommand(@"
				CREATE TABLE Friends (
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

            await CreateTableAsync(Defines.SQlilte.TableNammes.FRIENDS, createFriendsCommand);
        }

        public async Task CreateTransactionsTableAsync()
        {
            SqliteCommand createFriendsCommand = new SqliteCommand(@"
				CREATE TABLE Friends (
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

            await CreateTableAsync(Defines.SQlilte.TableNammes.TRANSACTIONS, createFriendsCommand);
        }

        public async Task CreateTableAsync(string nameTable, SqliteCommand createTableCommand)
        {
            await DbConection.OpenAsync();

            SqliteCommand deleteFriendsCommand = new SqliteCommand($"DROP TABLE {nameTable};", DbConection);

            try
            {
                await deleteFriendsCommand.ExecuteNonQueryAsync();
            }
            catch
            {

            }

            await createTableCommand.ExecuteNonQueryAsync();
            DbConection.Close();
        }

    }
}
