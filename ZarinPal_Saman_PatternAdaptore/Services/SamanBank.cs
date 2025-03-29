namespace ZarinPal_Saman_PatternAdaptore.Services
{

    public interface ISamanBank
    {
        string GetBankName();
    }



    public class SamanBank : ISamanBank
    {
        public string GetBankName()
        {
            return "SamanBank";
        }
    }
}
