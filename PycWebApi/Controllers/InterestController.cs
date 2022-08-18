using Microsoft.AspNetCore.Mvc;

namespace PycWebApi.Controllers
{

    public class InterestRequest
    {
        public decimal Amount { get; set; }
        public decimal InterestRate { get; set; }
        public int DueDateAsYear { get; set; }
    }
    public class InterestResponse
    {
        public decimal InterestAmount { get; set; }
        public decimal TotalAmount { get; set; }
    }
    [Route("Pyc/v1.0/api/[controller]")]
    [ApiController]
    public class InterestController : ControllerBase
    {
        public InterestController()
        {

        }

        [HttpPost]
        [Route("InterestCalculation")]
        public CommonResponse<InterestResponse> Post([FromBody] InterestRequest request)
        {
            if (request == null)
            {
                return new CommonResponse<InterestResponse>("Request can not be null !");
            }
            if (request.InterestRate <= 0)
            {
                return new CommonResponse<InterestResponse>("InterestRate can not be null !");
            }
            if (request.DueDateAsYear <= 0)
            {
                return new CommonResponse<InterestResponse>("DueDateAsYear can not be null !");
            }
            if (request.Amount <= 0)
            {
                return new CommonResponse<InterestResponse>("Amount can not be null !");
            }

            if (request.DueDateAsYear > 5  || request.DueDateAsYear < 2)
            {
                return new CommonResponse<InterestResponse>("DueDateAsYear must be 2-5 !");
            }

            InterestResponse response = new InterestResponse();
            decimal interestAmount = 14;
            response.TotalAmount = request.Amount + interestAmount;
            response.InterestAmount = interestAmount;
            return new CommonResponse<InterestResponse>(response);
        }

    }
}
