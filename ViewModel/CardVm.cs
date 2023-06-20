using System.ComponentModel.DataAnnotations;
using Utilities;

namespace ViewModel
{
    public class CardVm: Common
    {
        public int CardID { get; set; }
        public int? CardBatchID { get; set; }
        public int? CityID { get; set; }
        public string? MerchantID { get; set; }
        public string? FormNumber { get; set; }
        public DateTime? CardEntryDate { get; set; }
        public DateTime? CardRequestDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string? EmbossName { get; set; }
    }
}