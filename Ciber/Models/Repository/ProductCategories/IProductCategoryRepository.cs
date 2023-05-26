using Ciber.Models.Repository.ProductCategories;

namespace Ciber.Models.Repository.ProductCategories
{
    public interface IProductCategoryRepository : IDisposable
    {
        List<ProductCategory> GetProductCategories();
        ProductCategory GetProductCategoryByID(int ProductCategoryId);
        void InsertProductCategory(ProductCategory ProductCategory);
        void DeleteProductCategory(int ProductCategoryID);
        void UpdateProductCategory(ProductCategory ProductCategory);
        void Save();
    }
}
