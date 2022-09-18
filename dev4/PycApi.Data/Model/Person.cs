namespace PycApi.Data
{
    public class Person
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual PersonInfo PersonInfo { get; set; }
    }
}
