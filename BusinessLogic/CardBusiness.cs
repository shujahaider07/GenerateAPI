using Entities;
using IBusiness;
using IRepository;
using Newtonsoft.Json;
using ViewModel;
using Response = ResponseClass.Response;

namespace BusinessLogic
{
    public class CardBusiness : ICardBusiness
    {
        private readonly ICard _card;
        public CardBusiness(ICard _card)
        {
            this._card = _card;

        }

        public async Task<Response> AddCard(CardVm cardVm)
        {
            Response response = new Response();

            try
            {
                Card cards = await _card.AddCards(cardVm);

                if (cards != null)
                {
                    response.returnId = (int)cards.CardID;


                }
                else
                {
                    response.returnId = 0;
                }

                response.returnCode = "1";
                response.returnStatus = "Success";
                response.returnObject = cards;


            }
            catch (Exception ex)
            {
                string req = "JSON Request: Add " + JsonConvert.SerializeObject(cardVm) + "AddCard Bussiness";

                response.returnId = -1;
                response.returnCode = "0";
                response.returnStatus = "Error";
                response.returnText = ex.Message.ToString();
                response.returnException = ex.InnerException == null ? req + Environment.NewLine + Environment.NewLine + "Message: " + ex.Message.ToString() + Environment.NewLine + Environment.NewLine + "Stack Trace: " + ex.StackTrace.ToString() : req + Environment.NewLine + Environment.NewLine + "Inner Exception: " + ex.InnerException.ToString() + Environment.NewLine + Environment.NewLine + "Message: " + ex.Message.ToString() + Environment.NewLine + Environment.NewLine + "Stack Trace: " + ex.StackTrace.ToString();
                response.returnObject = null;
            }

            return response;
        }

        public async Task<Response> DeleteCard(CardVm cardVm)
        {
            Response response = new Response();

            try
            {
                Card cards = await _card.DeleteCards(cardVm);
                response.returnCode = "1";
                response.returnStatus = "Success";
                response.returnObject = cards;
            }
            catch (Exception ex)
            {
                string req = "JSON Request: Delete " + JsonConvert.SerializeObject(cardVm) + "DeleteContact Bussiness";

                response.returnId = -1;
                response.returnCode = "0";
                response.returnStatus = "Error";
                response.returnText = ex.Message.ToString();
                response.returnException = ex.InnerException == null ? req + Environment.NewLine + Environment.NewLine + "Message: " + ex.Message.ToString() + Environment.NewLine + Environment.NewLine + "Stack Trace: " + ex.StackTrace.ToString() : req + Environment.NewLine + Environment.NewLine + "Inner Exception: " + ex.InnerException.ToString() + Environment.NewLine + Environment.NewLine + "Message: " + ex.Message.ToString() + Environment.NewLine + Environment.NewLine + "Stack Trace: " + ex.StackTrace.ToString();
                response.returnObject = null;
                throw;
            }

            return response;
        }

        public Response GetCard()
        {
            Response response = new Response();
            List<CardVm> crdVM1 = new List<CardVm>();
            try
            {
                var cards = _card.GetCards();


                if (cards != null)
                {
                    response.returnId = 1;

                    foreach (var item in cards)
                    {
                        CardVm cityVM = new CardVm();


                        cityVM.CardBatchID = item.CardBatchID;
                        cityVM.CardID = item.CardID;
                        cityVM.CityID = item.CityID;
                        cityVM.MerchantID = item.MerchantID;
                        cityVM.FormNumber = item.FormNumber;
                        cityVM.CardEntryDate = item.CardEntryDate;
                        cityVM.CardRequestDate = item.CardRequestDate;
                        cityVM.ExpiryDate = item.ExpiryDate;
                        cityVM.EmbossName = item.EmbossName;
                        cityVM.IsDelete = item.IsDelete;
                        cityVM.LastCreatedBy = item.LastCreatedBy;
                        cityVM.LastCreatedDateTime = item.LastCreatedDateTime;
                        cityVM.Status = item.Status;

                        crdVM1.Add(cityVM);

                    }
                }
                else
                {
                    response.returnId = 0;
                }


                response.returnCode = "1";
                response.returnStatus = "Success";
                response.returnObject = crdVM1;


            }
            catch (Exception ex)
            {
                string req = "JSON Request: GET GetAllCards Bussiness";

                response.returnId = -1;
                response.returnCode = "0";
                response.returnStatus = "Error";
                response.returnText = ex.Message.ToString();
                response.returnException = ex.InnerException == null ? req + Environment.NewLine + Environment.NewLine + "Message: " + ex.Message.ToString() + Environment.NewLine + Environment.NewLine + "Stack Trace: " + ex.StackTrace.ToString() : req + Environment.NewLine + Environment.NewLine + "Inner Exception: " + ex.InnerException.ToString() + Environment.NewLine + Environment.NewLine + "Message: " + ex.Message.ToString() + Environment.NewLine + Environment.NewLine + "Stack Trace: " + ex.StackTrace.ToString();
                response.returnObject = null;
            }

            return response;
        }

        public Response GetCardById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> UpdateCard(CardVm cardVm)
        {
            Card card = new Card();
            Response response = new Response();
            try
            {
                Card card1 = await _card.UpdateCards(cardVm);

                if (card1 != null)
                {
                    response.returnCode = "1";
                    response.returnStatus = "Success";
                    response.returnObject = card;
                }
                else
                {
                    response.returnId = -1;
                }
            }
            catch (Exception ex)
            {
                string req = "JSON Request: Edit " + JsonConvert.SerializeObject(card) + "EditCard Bussiness";

                response.returnId = -1;
                response.returnCode = "0";
                response.returnStatus = "Error";
                response.returnText = ex.Message.ToString();
                response.returnException = ex.InnerException == null ? req + Environment.NewLine + Environment.NewLine + "Message: " + ex.Message.ToString() + Environment.NewLine + Environment.NewLine + "Stack Trace: " + ex.StackTrace.ToString() : req + Environment.NewLine + Environment.NewLine + "Inner Exception: " + ex.InnerException.ToString() + Environment.NewLine + Environment.NewLine + "Message: " + ex.Message.ToString() + Environment.NewLine + Environment.NewLine + "Stack Trace: " + ex.StackTrace.ToString();
                response.returnObject = null;

                throw;
            }

            return response;
        }
    }
}