using NHibernate;
using NHibernate.Mapping.ByCode.Conformist;

namespace PycApi
{
    public class AuthorMap : ClassMapping<Author>
    {
        public AuthorMap()
        {
            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.String);
                x.Column("Id");
                x.UnsavedValue(0);
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