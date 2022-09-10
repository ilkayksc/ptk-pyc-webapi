namespace PycApi.Data
{
    public class Card
    {
        public virtual int Id { get; set; }
        public virtual int AccountId { get; set; }
        public virtual string CardHolderName { get; set; }
        public virtual int CardLimit { get; set; }

    }
}
