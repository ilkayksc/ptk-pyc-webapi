using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PycTest.Test
{

    // old way
    public abstract class Kus
    {
        public abstract string Uc();
        public abstract string Yuru();
    }
    public class Tavuk : Kus
    {
        public override string Uc()
        {
            throw new NotImplementedException();
        }
        public override string Yuru()
        {
            return "Yürüdü..";
        }
    }
    public class Guvercin : Kus
    {
        public override string Uc()
        {
            return "Uçtu..";
        }
        public override string Yuru()
        {
            return "Yürüdü..";
        }
    }



    // liskov
    public interface INoise
    {
        string Noise();
    }
    public interface IUcanlar
    {
        string Uc();
    }
    public interface IYuruyenler
    {
        string Yuru();
    }
    public class TavukLiskov : IYuruyenler
    {
        public string Yuru()
        {
            return "Yürüdü..";
        }
    }
    public class GuvercinLiskov : IYuruyenler, IUcanlar, INoise
    {
        public string Noise()
        {
            return "Noise..";
        }

        public string Uc()
        {
            return "Uçtu..";
        }
        public string Yuru()
        {
            return "Yürüdü..";
        }
    }






    public class LiskovSubstitutionPrinciple
    {
        void Test_()
        {
            Kus kanatli = new Guvercin();
            kanatli.Uc();
            kanatli.Yuru();
            kanatli = new Tavuk();
            kanatli.Uc();  
            kanatli.Yuru();


            TavukLiskov tavukLiskov = new TavukLiskov();
            tavukLiskov.Yuru();
        }
    }
}
