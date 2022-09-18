namespace PycApi.Dto
{
    public class PersonDto
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual PersonInfoDto PersonInfo { get; set; }

    }
}
