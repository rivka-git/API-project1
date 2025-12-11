using Repository;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public class CategoryService : ICategoryService
  {
    ICategoryRepository _r;
    public CategoryService(ICategoryRepository i)
    {
      _r = i;
    }
    public async Task<IEnumerable<Category>> GetCategories()
    {
      return await _r.GetCategories();
    }
  }
}
