using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace PycApi.Data
{
    public class PersonMapping : ClassMapping<Person>
    {
        public PersonMapping()
        {
            Table("Person");
            Id(person => person.Id, map => map.Generator(Generators.Identity));
            Property(person => person.Name);
            OneToOne(person => person.PersonInfo, map => map.Cascade(Cascade.All));
        }
    }
}