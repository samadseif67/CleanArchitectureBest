namespace ZarinPal_Saman_PatternAdaptore.Services
{
    public interface IPaymentAdapter
    {
        string Pay();
    }


    public class ZarinpalPaymentAdapter:IPaymentAdapter
    {
        private readonly IZarinPal _zarinPal;
        public ZarinpalPaymentAdapter(IZarinPal zarinPal)
        {
            _zarinPal = zarinPal;   
        }
        public string Pay()
        {
          return  _zarinPal.GetBankName();
        }
    }


    public class SamanBankPaymentAdapter : IPaymentAdapter
    {
        private readonly ISamanBank _samanBank;
        public SamanBankPaymentAdapter(ISamanBank samanBank)
        {
            _samanBank = samanBank;
        }
        public string Pay()
        {
            return _samanBank.GetBankName();
        }
    }






}
