using System;

namespace PycTest.Test
{

    [Obsolete("Use PCStaff insted of")]
    public class PycStaff
    {
        public string Name { get; set; }
    }

    [Help("url", Topic = "message data")]
    public class PcStaff
    {
        public string Name { get; set; }
    } 
    
    [MySpecial]
    public class PStaff
    {
        public string Name { get; set; }
    }
    public class AttributeTest
    {
        public void Test_1()
        {
            PcStaff pStaff = new PcStaff();   

        }
    }
}
