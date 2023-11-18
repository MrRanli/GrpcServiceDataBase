using Grpc.Core;
using GrpcServiceDataBase.Model.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GrpcServiceDataBase.Model.DAL.Helpers
{
    public class AddInfoOnBb : UserDo.UserDoBase
    {

        //private readonly AppDataContext _dbContext;
        //public AddInfoOnBb(AppDataContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}

        //public override async Task<CheckUserDoResponse> PasteValuesOnTableUserDo(CheckUserDoRequest request, ServerCallContext context)
        //{
        //    if (request.Password == string.Empty || request.Phone == string.Empty)
        //        throw new RpcException(new Status(StatusCode.InvalidArgument, "Not found info"));

        //    var _ClientInfo = new ClientInfo
        //    {
        //        Id = 1,
        //        Name = "Тест",
        //        FirstName = "Тестов",
        //        LastName = "Тестович",
        //        Password = "12345",
        //        Phone = "89969520206",
        //    };

        //    //await _dbContext.
        //    await _dbContext.AddAsync(_ClientInfo);
        //    await _dbContext.SaveChangesAsync();

        //    return await Task.FromResult(new CheckUserDoResponse
        //    {
        //        UserId = _ClientInfo.Id
        //    });
        //}
    }
}
