using EasyCashIdentityProject.EntityLayer.Abstract;

namespace EasyCashIdentityProject.EntityLayer.Concrete
{
    public class CustomerAccountProcess : BaseEntity
    {
        public string ProcessType { get; set; }
        public decimal Amount { get; set; }
        public DateTime ProcessDate { get; set; }
    }
}
