using Model;

namespace Services
{
  public interface ICategoryService
  {
    Task<IEnumerable<Category>> GetCategories();
  }
}
