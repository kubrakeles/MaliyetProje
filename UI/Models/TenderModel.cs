﻿namespace UI.Models
{
    public class TenderModel
    {
       
        public int TenderTypeId { get; set; }//ilişkili ihale türü
        public int TenderingProcedure { get; set; } //--İhale Prosedürü ilişkili
        public string JobName { get; set; } //işin adı
        public int UnitId { get; set; } //ilişkili UnitId Birimler
        public string TenderRegisterNo { get; set; }
        public DateTime TenderDate { get; set; }
        public string? JobTypeWorkLoad { get; set; }//İşin türü ve miktarı   
        public decimal OpproximateCost { get; set; } //Yaklaşık Maliyet
        public string AnalysisRate { get; set; } //Yapım işleri için yaklaşık maliyette kullnılan analizlerin oranı*-
        public string PoseRate { get; set; }// YAPIM İŞLERİ İÇİN YAKLAŞIK MALİYETTE KULLANILAN RESMİ YAYINLANMIŞ POZLARIN ORANI 
        public string MarketResearchRate { get; set; } // YAPIM İŞLERİ İÇİN YAKLAşIK MALİYETTE KULLANILAN PİYASA FİYAT ARAŞTIRMALARININ ORANI 
        public decimal PreviousOpproximateCoast { get; set; } //Bir önceki yaklaşık maliyet
        public decimal PreviousOCTotal { get; set; } //Bir önceki yaklaşık maliyet tutar 
        public decimal PreviousConractPrice { get; set; } //Bir önceki sözleşme bedeli
        public decimal PreviousCPTotal { get; set; }//Bir önceki sözleşme tutar
        public string OtherFoundationContractPrice { get; set; }//Diğer kurumlarda yapılmış benzer işlerin söz. tutarı
        public decimal OpproximateCostAfterTender { get; set; } // ihale sonrası güncellenmiş yaklaşık maliyet
        public decimal Contratprice { get; set; } //Sözleşme Bedeli 
        public string KirimRate { get; set; } //Kırım Oranı
        public string TendererProposal { get; set; } //İhale Katılımcısı ve teklifler
        public string EnthusiastFoundation { get; set; } // ihale üzerinde kalan istekli firmalar
        public string City { get; set; }
        public string Scor { get; set; } // puanlama
        public string PriceDifference { get; set; } //Fiyat Farkı
        public string OtherExplanation { get; set; } //Diğer Açıklama
        public DateTime TenderDateArrived { get; set; } //İhalenin geldiği tarih
        public string TenderState { get; set; } // ihale durumu
    }
}