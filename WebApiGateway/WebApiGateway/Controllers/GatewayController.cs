using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Grpc.Net.Client;
using GrpcServiceDataBaseClient;
using Microsoft.AspNetCore.Mvc.Filters;


namespace WebApiGateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CheckUserDoController : Controller
    {
        private readonly ILogger<CheckUserDoController> _logger;

        public CheckUserDoController(ILogger<CheckUserDoController> logger)
        {
            _logger = logger;
        }


        [HttpPost(Name = "CheckUserDo")]
        public async Task<IActionResult> CheckUserDo(CheckUserDoRequest CheckUserDoRequest)
        {
            try
            {
                var channel = GrpcChannel.ForAddress(ConnectionData.GrpcConnectionString);
                var client = new UserDo.UserDoClient(channel);
                var reply = await client.CheckUserDoAsync(CheckUserDoRequest);
                return Ok((CheckUserDoResponse)reply);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }

    [ApiController]
    [Route("[controller]")]
    public class GetClientInfoUserDoController : Controller
    {
        private readonly ILogger<GetClientInfoUserDoController> _logger;

        public GetClientInfoUserDoController(ILogger<GetClientInfoUserDoController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "GetClientInfoUserDo")]
        public async Task<IActionResult> GetClientInfoUserDo(GetClientInfoUserDoRequest GetClientInfoUserDoRequest)
        {
            try
            {
                var channel = GrpcChannel.ForAddress(ConnectionData.GrpcConnectionString);
                var client = new UserDo.UserDoClient(channel);
                var reply = await client.GetClientInfoUserDoAsync(GetClientInfoUserDoRequest);

                return Ok((GetClientInfoUserDoResponse)reply);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }

    [ApiController]
    [Route("[controller]")]
    public class GetClientBankAccountsUserDoController : Controller
    {
        private readonly ILogger<GetClientBankAccountsUserDoController> _logger;

        public GetClientBankAccountsUserDoController(ILogger<GetClientBankAccountsUserDoController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "GetClientBankAccountsUserDo")]
        public async Task<IActionResult> GetClientBankAccountsUserDo(GetClientBankAccountsUserDoRequest GetClientBankAccountsUserDoRequest)
        {
            try
            {
                var channel = GrpcChannel.ForAddress(ConnectionData.GrpcConnectionString);
                var client = new UserDo.UserDoClient(channel);
                var reply = await client.GetClientBankAccountsUserDoAsync(GetClientBankAccountsUserDoRequest);

                return Ok((GetClientBankAccountsUserDoResponse)reply);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });

            }
        }
    }
}
