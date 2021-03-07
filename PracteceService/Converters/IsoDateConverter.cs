
namespace PracteceService.Converters
{
    /// <summary>
    /// Converte data para formato ISO yyyy-MM-dd\\THH:mm:ss\\Z.
    /// </summary>
    public class IsoDateConverter : Newtonsoft.Json.Converters.IsoDateTimeConverter
    {
        public IsoDateConverter()
        {
            base.DateTimeFormat = "yyyy-MM-dd\\THH:mm:ss\\Z";
            base.DateTimeStyles = System.Globalization.DateTimeStyles.RoundtripKind;
        }
    }

    public class SimpleDateConverter : Newtonsoft.Json.Converters.IsoDateTimeConverter
    {
        public SimpleDateConverter()
        {
            base.DateTimeFormat = "yyyy-MM-dd";
            base.DateTimeStyles = System.Globalization.DateTimeStyles.RoundtripKind;
        }
    }

    public class SlashDateConverter : Newtonsoft.Json.Converters.IsoDateTimeConverter
    {
        public SlashDateConverter()
        {
            base.DateTimeFormat = "dd/MM/yyyy";
            base.DateTimeStyles = System.Globalization.DateTimeStyles.RoundtripKind;
        }
    }
}
