using DiziFilm.Core.DataAccess;
using DiziFilm.Project.Entities.Concrete;

namespace DiziFilm.Project.DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        //Custom Operations
    }
}
