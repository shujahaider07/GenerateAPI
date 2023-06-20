using Entities;
using IBusiness;
using Microsoft.AspNetCore.Mvc;
using ResponseClass;
using ViewModel;

namespace GenerateAPI.Controllers
{
    public class CardController : Controller
    {
        private readonly ICardBusiness _cardBusiness;
        public CardController(ICardBusiness _cardBusiness)
        {
            this._cardBusiness = _cardBusiness;
        }
        public IActionResult Index()
        {
            return View();
        }
       
        [HttpPost("Add_Card")]
        public async Task<IActionResult> AddCard([FromBody] CardVm cardvm)
        {
            Response response = new Response();

            try
            {
                response = await _cardBusiness.AddCard(cardvm);
            }
            catch (Exception ex)
            {
                response.returnId = -1;
                response.returnCode = "0";
                response.returnStatus = "Error";
                response.returnText = ex.InnerException == null ? ex.Message.ToString() : ex.InnerException.ToString() + " " + ex.Message.ToString();
                response.returnObject = null;
            }

            return Ok(response);
           
        }

        [HttpGet("Get_Card")]
        public async Task<IActionResult> GetCard()
        {
            Response response = new Response();

            try
            {
                response = _cardBusiness.GetCard();
            }
            catch (Exception ex)
            {
                response.returnId = -1;
                response.returnCode = "0";
                response.returnStatus = "Error";
                response.returnText = ex.InnerException == null ? ex.Message.ToString() : ex.InnerException.ToString() + " " + ex.Message.ToString();
                response.returnObject = null;
            }

            return Ok(response);

        }



    }
}
