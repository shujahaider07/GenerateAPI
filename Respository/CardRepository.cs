using Entities;
using GenerateAPI.BasedataBase;
using IRepository;
using Microsoft.EntityFrameworkCore;
using ViewModel;

namespace Respository
{
    public class CardRepository : ICard
    {
        private readonly ApplicationDbContext _context;

        public CardRepository(ApplicationDbContext _context)
        {
            this._context = _context;
        }
        public async Task<Card> AddCards(CardVm cardvm)
        {
            var card = new Card();
            
            try
            {
                await _context.Cards.AddAsync(new Card
                {
                    CardBatchID  = cardvm.CardBatchID,
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

        public async Task<List<Card>> GetCards()
        {
            List<Card> cardVm = new List<Card>();


            try
            {
               var cards =  await _context.Cards.ToListAsync();

                cardVm = cards;
            }
            catch (Exception)
            {

                throw;
            }

            return cardVm;
        }

        public Task<Card> UpdateCards(CardVm cardvm)
        {
            throw new NotImplementedException();
        }
    }
}