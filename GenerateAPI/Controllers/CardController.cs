using Azure;
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
            ResponseClass.Response response = new ResponseClass.Response();

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
            ResponseClass.Response response = new ResponseClass.Response();

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


        [HttpDelete("Delete_Card")]
        public async Task<IActionResult> Delete_Card([FromBody] CardVm cardVm)
        {
            ResponseClass.Response response = new ResponseClass.Response();

            try
            {
                response = await _cardBusiness.DeleteCard(cardVm);
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


        [HttpPut("Update_Card")]
        public async Task<IActionResult> Update_Card([FromBody] CardVm cardVm)
        {
            ResponseClass.Response response = new ResponseClass.Response();

            try
            {
                response = await _cardBusiness.UpdateCard(cardVm);
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
