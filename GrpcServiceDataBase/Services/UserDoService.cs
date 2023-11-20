using Grpc.Core;
using GrpcServiceDataBase.Model;
using GrpcServiceDataBase.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace GrpcServiceDataBase.Services
{
    public class UserDoService : UserDo.UserDoBase
    {
        private readonly AppDataContext _dbContext;
        public UserDoService(AppDataContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public override async Task<PasteValuesOnTableResponse> PasteValuesOnTableUserDo(PasteValuesOnTableRequest request, ServerCallContext context)//экспериментальное заполнение таблицы
        {
            var _ClientInfoCheck = await _dbContext.ClientInfo.FirstOrDefaultAsync(t => t.Id != 0 || t.Id >0 );
            if (_ClientInfoCheck == null)
            {
                var _ClientInfo = new ClientInfo
                {
                    Id = 1,
                    Name = "Тест",
                    FirstName = "Тестов",
                    LastName = "Тестович",
                    Password = "12345",
                    Phone = "89969520206",
                };

                await _dbContext.AddAsync(_ClientInfo);

                var _ClientBankAccounts = new ClientBankAccount
                {
                    Id =1,
                    ClientInfoId = 1,
                    Account = "Срочный",
                    Number = "42305840513000000112"
                };

                await _dbContext.AddAsync(_ClientBankAccounts);

                var _ClientBankAccounts2 = new ClientBankAccount
                {
                    Id = 2,
                    ClientInfoId = 1,
                    Account = "До востреббования",
                    Number = "42301810413002008000"
                };

                await _dbContext.AddAsync(_ClientBankAccounts2);

                var _ClientBankAccounts3 = new ClientBankAccount
                {
                    Id = 3,
                    ClientInfoId = 1,
                    Account = "Карточный",
                    Number = "40817810310009035474"
                };

                await _dbContext.AddAsync(_ClientBankAccounts3);
                await _dbContext.SaveChangesAsync();

                return await Task.FromResult(new PasteValuesOnTableResponse
                {
                    Text = "Dates was Addet",
                });
            }
            throw new RpcException(new Status(StatusCode.NotFound, $"U have dates on tables"));
        }


        public override async Task<CheckUserDoResponse> CheckUserDo(CheckUserDoRequest request, ServerCallContext context)
        {
            if (request.Password == string.Empty || request.Phone == string.Empty)
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Not found info"));


            //await _dbContext.
            ////await _dbContext.AddAsync(_UserAuthenticationInfo);
            ////await _dbContext.SaveChangesAsync();

            var _ClientInfo = await _dbContext.ClientInfo.FirstOrDefaultAsync(t => t.Password == request.Password && t.Phone == request.Phone );
            if (_ClientInfo != null)
            {
                return await Task.FromResult(new CheckUserDoResponse
                {
                    ClientId = _ClientInfo.Id

                });
            }
            throw new RpcException(new Status(StatusCode.NotFound, $"No ClientInfo with Password = {request.Password} and Phone = {request.Phone}."));
        }


        public override async Task<GetClientInfoUserDoResponse> GetClientInfoUserDo(GetClientInfoUserDoRequest request, ServerCallContext context)
        { 
            if(request.ClientId <=0)
                throw new RpcException(new Status(StatusCode.InvalidArgument, "User not Found"));

            var _ClientInfo = await _dbContext.ClientInfo.FirstOrDefaultAsync(t => t.Id == request.ClientId);
            if (_ClientInfo != null)
            {
                return await Task.FromResult(new GetClientInfoUserDoResponse
                {
                    ClientId = _ClientInfo.Id,
                    FirstName = _ClientInfo.FirstName,
                    LastName = _ClientInfo.LastName,
                    Name = _ClientInfo.Name,
                    Phone = _ClientInfo.Phone,
                });
            }
            throw new RpcException(new Status(StatusCode.NotFound, $"No ClientInfo with id = {request.ClientId}."));

        }


        public override async Task<GetClientBankAccountsUserDoResponse> GetClientBankAccountsUserDo(GetClientBankAccountsUserDoRequest request, ServerCallContext context)
        {
            if (request.ClientId <= 0)
                throw new RpcException(new Status(StatusCode.InvalidArgument, "User not Found"));

            var response = new GetClientBankAccountsUserDoResponse();
            var _ClientBankAccounts = await _dbContext.ClientBankAccounts
             .Where(t => t.ClientInfoId == request.ClientId)
            .ToListAsync();
            if (_ClientBankAccounts.Count != 0)
            {
                foreach (var item in _ClientBankAccounts)
                {
                    response.ClientBanckAccount.Add(new GetClientBankAccountUserDoResponse
                    {
                        ClientId = item.ClientInfoId,
                        Accounts = item.Account,
                        Numbers = item.Number
                    });
                }
                return await Task.FromResult(response);
            }
            throw new RpcException(new Status(StatusCode.NotFound, $"No ClientBankAccounts with id = {request.ClientId}."));
        }
    }
}
