using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PycTest.Test
{

    // old way 
    public class ReportService
    {
        public string RaporTipi { get; private set; }

        /// <summary> 
        /// Rapor oluşturmak için kullanılan metod 
        /// </summary> 
        /// <param name="em"></param> 
        public void RaporOlustur(PvEmployee em)
        {
            if (RaporTipi == "CRS")
            {
                // Crystal Report ile rapor oluştur 
            }
            if (RaporTipi == "PDF")
            {
                // PDF formatında rapor oluştur 
            }
        }
    }
    public class PvEmployee
    {

    }

    // open closed principle
    abstract class Report
    {
        public int RaporId { get; set; }
        public string RaporAdi { get; set; }
        public abstract void RaporOlustur(PvEmployee em);
    }

    class CrystalReportOlustur : Report
    {
        public override void RaporOlustur(PvEmployee em)
        {
            // Crystal Report ile rapor oluştur 
        }
    }
    class PDFRaporOlustur : Report
    {
        public override void RaporOlustur(PvEmployee em)
        {
            // PDF ile rapor oluştur 
        }
    }
    class CsvRaporOlustur : Report
    {
        public override void RaporOlustur(PvEmployee em)
        {
            // CSV ile rapor oluştur 
        }
    }

    public class OpenClosedPrinciple
    {

    }
}
