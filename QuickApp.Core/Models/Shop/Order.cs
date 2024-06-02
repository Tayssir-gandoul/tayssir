

using QuickApp.Core.Models.Account;

namespace QuickApp.Core.Models.Shop
{
    public class Order : BaseEntity
    {
        public decimal Discount { get; set; }
        public string? Comments { get; set; }

        public string? CashierId { get; set; }
        public ApplicationUser? Cashier { get; set; }

        public int CompteurId { get; set; }
        public required Compteur Compteur { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();
    }
}
