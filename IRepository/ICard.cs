using Entities;
using ViewModel;

namespace IRepository
{
    public interface ICard
    {
        public List<Card> GetCards();

        public Task<Card> AddCards(CardVm cardvm);
        public Task<Card> UpdateCards(CardVm cardvm);
        public Task<Card> DeleteCards(CardVm vm);
        public List<Card> GetCardById(int id);

    }

}