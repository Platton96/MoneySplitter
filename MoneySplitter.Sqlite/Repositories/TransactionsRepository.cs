using Microsoft.Data.Sqlite;
using MoneySplitter.Infrastructure;
using MoneySplitter.Models;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace MoneySplitter.Sqlite.Repositories
{
    public class TransactionsRepository
    {
        private SqliteConnection _sqliteConnection;

        public TransactionsRepository(DbContext dbContext)
        {
            _sqliteConnection = dbContext.DbConection;
        }

        public async Task ClearUssersTableAsync()
        {
            await _sqliteConnection.OpenAsync();

            SqliteCommand deleteCommand = new SqliteCommand($"DELETE FROM {Defines.SQlilte.TableNammes.TRANSACTIONS}", _sqliteConnection);

            await deleteCommand.ExecuteReaderAsync();

            _sqliteConnection.Close();
        }

        public async Task InsertTransactioAsync(TransactionModel transaction)
        {
            await _sqliteConnection.OpenAsync();
        }
        private async Task HelpInsertTransactioAsync(TransactionModel transaction)
        {
            await _sqliteConnection.OpenAsync();
            SqliteCommand insertCommand = new SqliteCommand("INSERT INTO Transactions (Id, Cost, SingleCost CollaboratorsIds, CreationDate, DeadlineDate, Description, FinishedIds, InProgressIds, OwnerId, Title, OngoingDate) " +
                                                   $"Values (" +
                                                   $"{transaction.Id}, " +
                                                   $"'{transaction.Cost}', " +
                                                   $"'{transaction.SingleCost}', " +
                                                   $"'{string.Join(",", transaction.Collaborators.Select(cl => cl.Id))}', " +
                                                   $"'{transaction.CreationDate}', " +
                                                   $"'{transaction.DeadlineDate}', " +
                                                   $"'{transaction.Description}', " +
                                                   $"'{string.Join(",", transaction.FinishedIds)}', " +
                                                   $"'{string.Join(",", transaction.InProgressIds)}', " +
                                                   $"'{transaction.Owner.Id}', " +
                                                   $"'{transaction.Title}', " +
                                                   $"'{transaction.OngoingDate}')", 
                                                   _sqliteConnection);

            await insertCommand.ExecuteReaderAsync();
        }
    }
}
