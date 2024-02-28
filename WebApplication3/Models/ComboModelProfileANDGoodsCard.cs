using WebApplication3.Models;

namespace WebApplication3.Models
{
    public class ComboModelProfileANDGoodsCard
    {
        public IEnumerable<userss> userssData { get; set; } = null!;
        public IEnumerable<Goodss> GoodssData { get; set; } = null!;
        public IEnumerable<Carts> CartData { get; set; } = null!;
        public int usersID { get; set; }
    }
}