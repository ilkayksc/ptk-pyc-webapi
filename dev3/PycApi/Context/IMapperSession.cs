using PycApi.Model;
using System.Linq;
using System.Threading.Tasks;

namespace PycApi.Context
{
    public interface IMapperSession
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
        void CloseTransaction();
        void Save(Book entity);
        void Update(Book entity);
        void Delete(Book entity);

        IQueryable<Book> Books { get; }
    }
}
