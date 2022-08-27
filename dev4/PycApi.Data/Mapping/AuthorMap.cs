using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace PycApi.Data
{
    public class AuthorMap : ClassMapping<Author>
    {
        public AuthorMap()
        {
            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.String);
                x.Column("Id");
                x.UnsavedValue("");
                x.Generator(Generators.Guid);
            });
           
            Property(b => b.FirstName, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });

            Property(b => b.LastName, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });
           

            Table("author");
        }
    }
}