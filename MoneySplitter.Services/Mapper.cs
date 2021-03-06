﻿using MoneySplitter.Models;
using MoneySplitter.Services.DataModels;
using MoneySplitter.Services.Inerfaces;
using MoneySplitter.Models.Session;
using System.Linq;

namespace MoneySplitter.Services
{
    public class Mapper : IMapper
    {
        public UserModel ConvertUserDataToUserModel(UserData userData)
        {
            if (userData == null)
            {
                return null;
            }

            return new UserModel()
            {
                Id = userData.Id,
                Name = userData.UserName,
                Surname = userData.Surname,
                Email = userData.Email,
                PhoneNumber = userData.PhoneNumber,
                CreditCardNumber = userData.CreditCardNumber,
                Ballance = userData.Ballance,
                Token = userData.Token,
                ImageUrl = userData.ImageUrl,
                BackgroundImageUrl=userData.BackgroundImageUrl
            };
        }

        public RegisterUserData ConvertRegisterModelToRegisterUserData(RegisterModel registerModel)
        {
            return new RegisterUserData()
            {
                Name = registerModel.Name,
                Surname = registerModel.Surname,
                Email = registerModel.Email,
                Password = registerModel.Password,
                PhoneNumber = registerModel.PhoneNumber,
                CreditCardNumber = registerModel.CreditCardNumber,
                ImageBase64String = registerModel.ImageBase64String,
                BackgroundImageBase64String = registerModel.BackgroundImageBase64String
            };
        }

        public AddTransactionData ConvertAddTransactioModelToAddTransactionData(AddTransactionModel addTransactionModel)
        {
            return new AddTransactionData()
            {
                Title = addTransactionModel.Title,
                Cost = addTransactionModel.Cost,
                DeadlineDate = addTransactionModel.DeadlineDate.DateTime,
                Description = addTransactionModel.Description,
                CollaboratorsIds = addTransactionModel.CollaboratorsIds,
                ImageBase64String = addTransactionModel.ImageBase64String,
            };
        }

        public TransactionModel ConvertTransactioDataToTransactionModel(TransactionData transactionData)
        {
            return new TransactionModel()
            {
                Id = transactionData.Id,
                Owner = ConvertUserDataToUserModel(transactionData.Owner),
                CreationDate = transactionData.CreationDate,
                Title = transactionData.Title,
                DeadlineDate = transactionData.DeadlineDate,
                Description = transactionData.Description,
                Cost = transactionData.Cost,
                Collaborators = transactionData.Collaborators.Select(user => ConvertUserDataToUserModel(user)),
                FinishedIds = transactionData.FinishedIds,
                InProgressIds = transactionData.InProgressIds,
                ImageUrl = transactionData.ImageUrl,
                SingleCost = transactionData.SingleCost,
                OngoingDate = transactionData.OngoingDate
            };
        }

    }
}
