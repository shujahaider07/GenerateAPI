using Entities;
using GenerateAPI.BasedataBase;
using IRepository;
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

        public Task<Card> DeleteCards(CardVm vm)
        {
            throw new NotImplementedException();
        }

        public List<Card> GetCardById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Card> GetCards()
        {
            try
            {
                return _context.Cards.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<Card> UpdateCards(CardVm cardvm)
        {
            throw new NotImplementedException();
        }
    }



}


