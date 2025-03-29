namespace ZarinPal_Saman_PatternAdaptore.Services
{
    public interface IZarinPal
    {
        string GetBankName();
    }



    public class ZarinPal: IZarinPal
    {
        public string GetBankName()
        {
            return "ZarinPal";
        }
    }
}
