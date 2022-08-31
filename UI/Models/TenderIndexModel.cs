namespace UI.Models
{
    public class TenderIndexModel
    {
        public int TenderID { get; set; }
        public string IsinAdi { get; set; }
        public string IhaleTuru { get; set; }
        public string BirimAdi { get; set; }
        public DateTime IhaleGeldigiTarih { get; set; }
        public string Durum { get; set; }

    }
}
