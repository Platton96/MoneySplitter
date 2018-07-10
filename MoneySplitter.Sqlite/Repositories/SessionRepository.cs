using Microsoft.Data.Sqlite;
using MoneySplitter.Infrastructure;
using MoneySplitter.Models;
using System;
using System.Threading.Tasks;

namespace MoneySplitter.Sqlite.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private SqliteConnection _sqliteConnection;

        public SessionRepository(DbContext dbContext)
        {
            _sqliteConnection = dbContext.DbConection;
        }

        public async Task<UserModel> GetUserAsync()
        {
            await _sqliteConnection.OpenAsync();

            SqliteCommand selectCommand = new SqliteCommand($"SELECT TOP 1 * FROM Users", _sqliteConnection);

            var myReader = await selectCommand.ExecuteReaderAsync();

            await myReader.ReadAsync();

            var userModel = new UserModel
            {
                Id = Int32.Parse(myReader["Id"].ToString()),
                Name = myReader["UserName"].ToString(),
                Surname = myReader["Surname"].ToString(),
                Email = myReader["Email"].ToString(),
                PhoneNumber = Int64.Parse(myReader["PhoneNumber"].ToString()),
                CreditCardNumber = Int64.Parse(myReader["CreditCardNumber"].ToString()),
                Token = myReader["Token"].ToString(),
                ImageUrl = myReader["ImageUrl"].ToString(),
                BackgroundImageUrl = myReader["BackgroundImageUrl"].ToString()
            };

            _sqliteConnection.Close();
            return userModel;
        }

        public async Task ClearUssersTableAsync()
        {
            await _sqliteConnection.OpenAsync();

            SqliteCommand deleteCommand = new SqliteCommand($"DELETE * FROM Users", _sqliteConnection);

            await deleteCommand.ExecuteReaderAsync();

            _sqliteConnection.Close();
        }

        public async Task AddUserAsync(UserModel userModel)
        {
          //  await ClearUssersTableAsync();

            await _sqliteConnection.OpenAsync();

            SqliteCommand insertCommand = new SqliteCommand("INSERT INTO Users (Id, Name, Surname, Email, PhoneNumber, CreditCardNumber, ImageUrl, BackgroundImageUrl) " +
                                                  $"Values ({userModel.Id}, N'{userModel.Name}', N'{userModel.Surname}', N'{userModel.Email}',  '{userModel.PhoneNumber}', '{userModel.CreditCardNumber}', '{userModel.ImageUrl}', '{userModel.BackgroundImageUrl}')", _sqliteConnection);

            await insertCommand.ExecuteReaderAsync();

            _sqliteConnection.Close();
        }

    }

}
