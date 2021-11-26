using Shop.Database.Infrastructure;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Database.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {

    }
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ShopDbContext context) : base(context)
        {
        }
    }
}
