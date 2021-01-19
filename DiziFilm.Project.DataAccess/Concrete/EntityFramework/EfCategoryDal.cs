using DiziFilm.Core.DataAccess.EntityFramework;
using DiziFilm.Project.DataAccess.Abstract;
using DiziFilm.Project.DataAccess.Concrete.EntityFramework.Context;
using DiziFilm.Project.Entities.Concrete;

namespace DiziFilm.Project.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, NorthwindContext>, ICategoryDal
    {
    }
}