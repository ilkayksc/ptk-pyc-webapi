using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace PycApi.Data
{
    public class PersonInfoMapping : ClassMapping<PersonInfo>
    {
        public PersonInfoMapping()
        {
            Table("PersonInfo");
            Id(personInfo => personInfo.Id, map => map.Generator(Generators.Foreign<PersonInfo>(personInfo => personInfo.Person)));
            Property(personInfo => personInfo.PhoneNumber);
            Property(personInfo => personInfo.Remarks);
            OneToOne(personInfo => personInfo.Person, map=> map.Constrained(true));
        }
    }
}