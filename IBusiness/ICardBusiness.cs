using ResponseClass;
using ViewModel;

namespace IBusiness
{
    public interface ICardBusiness
    {

        public Task<Response> AddCard(CardVm cardVm);
        public Task<Response> DeleteCard(CardVm cardVm);
        public Task<Response> UpdateCard(CardVm cardVm);
        public Response GetCard();
        public Response GetCardById(int id);

       

    }
}