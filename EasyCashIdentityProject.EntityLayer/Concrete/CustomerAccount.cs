using EasyCashIdentityProject.EntityLayer.Abstract;

namespace EasyCashIdentityProject.EntityLayer.Concrete
{
    public class CustomerAccount : BaseEntity
    {
        public string CustomerAccountNumber { get; set; }
        public string CustomerAccountCurrency { get; set; }
        public decimal CustomerAccountBalance { get; set; }
        public string BankBranch { get; set; }
        public int AppUserID { get; set; }
        public AppUser AppUser { get; set; }
    }
}
