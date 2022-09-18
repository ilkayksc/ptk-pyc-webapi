namespace PycApi.Data
{
    public class PersonInfo
    {
        public virtual int Id { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual string Remarks { get; set; }
        public virtual Person Person { get; set; }

    }
}
