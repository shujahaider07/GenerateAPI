using Entities;
using GenerateAPI.BasedataBase;
using IRepository;
using Microsoft.IdentityModel.Tokens;
using ViewModel;

namespace GenerateAPI.Repository
{
    public class Cardrepostory : ICard
    {

        private readonly ApplicationDbContext _context;

        public Cardrepostory(ApplicationDbContext _context)
        {
            this._context = _context;
        }
        public async Task<Card> AddCards(CardVm cardvm)
        {
            var card = new Card();

            try
            {
                 _context.Cards.Add(new Card
                {
                    CardBatchID = cardvm.CardBatchID,
                    CardID = cardvm.CardID,
                    CityID = cardvm.CityID,
                    MerchantID = cardvm.MerchantID,
                    FormNumber = cardvm.FormNumber,
                    CardEntryDate = cardvm.CardEntryDate,
                    CardRequestDate = cardvm.CardRequestDate,
                    ExpiryDate = cardvm.ExpiryDate,
                    EmbossName = cardvm.EmbossName,
                    IsDelete = cardvm.IsDelete,
                    LastCreatedBy = cardvm.LastCreatedBy,
                    LastCreatedDateTime = cardvm.LastCreatedDateTime,
                    Status = cardvm.Status,

                });
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                {

                    int id = (int)_context.Cards.OrderBy(x => x.CardID).LastOrDefault().CardID;
                    var res = _context.Cards.Where(x => x.CardID == id).FirstOrDefault();

                    card = res;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return card;

        }

        public async Task<Card> DeleteCards(CardVm vm)
        {
            var card = new Card();

            try
            {
              var result = _context.Cards.FirstOrDefault(x => x.CardID == vm.CardID);

                if (result == null) return null;
                result.IsDelete = true;
                result.Status = vm.Status;
                result.LastCreatedBy = vm.LastCreatedBy;
                result.LastCreatedDateTime = vm.LastCreatedDateTime;

                _context.Cards.Update(result);
               
                var result2 = await _context.SaveChangesAsync();
                if (result2 > 0)
                {
                    var res = _context.Cards.Where(x => x.CardID == vm.CardID).FirstOrDefault();
                    card = res;
                }

            }
            catch (Exception)
            {

                throw;
            }

            return card;
        }

        public List<Card> GetCardById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Card> GetCards()
        {
            try
            {
                return _context.Cards.Where(x => x.IsDelete == false).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Card> UpdateCards(CardVm cardvm)
        {
            Card card = new Card();
            
            try
            {
              var EditItem =  _context.Cards.FirstOrDefault(x =>x.CardID == cardvm.CardID);
                if (EditItem == null) return null;

                EditItem.EmbossName = string.IsNullOrEmpty(cardvm.EmbossName) == true ? EditItem.EmbossName : cardvm.EmbossName;
                EditItem.Status = string.IsNullOrEmpty(cardvm.Status) == true ? EditItem.Status : cardvm.Status;
                EditItem.CityID = Convert.ToBoolean(cardvm.CityID) == true ? EditItem.CityID : cardvm.CityID;
                EditItem.FormNumber = string.IsNullOrEmpty(cardvm.FormNumber) == true ? EditItem.FormNumber : cardvm.FormNumber;
                EditItem.MerchantID = string.IsNullOrEmpty(cardvm.MerchantID) == true ? EditItem.MerchantID : cardvm.MerchantID;
                _context.Cards.Update(EditItem);
              
                var result2 = await _context.SaveChangesAsync();
                if (result2 > 0)
                {
                    var res = _context.Cards.Where(x => x.CardID == cardvm.CardID).FirstOrDefault();
                    card = res;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return card;
        }
    }



}


