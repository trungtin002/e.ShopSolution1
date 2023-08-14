using eShopSolution.ViewModels.Catalog.Product;
using eShopSolution.ViewModels.Catalog.ProductImage;
using eShopSolution.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e.ShopSolution.Application.Catalog
{
    public interface IManageProductService
    {
        Task<int> Create(ProductCreateRequest request);

        Task<int> Update(ProductUpdateRequest request);

        Task<int> Delete(int productId);

        Task<bool> UpdatePrice(int productId, decimal newPrice);

        Task<bool> UpdateStock(int productId, int addedQuantity);
        Task<ProductViewModel> GetById(int productId, string languageId);
        Task AddViewcount(int productId);

        Task<PagedResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request);

        Task<int> AddImage(int productId, ProductImageCreateRequest repuest);

        Task<int> RemoveImage(int imageId);

        Task<int> UpdateImage( int imageId, ProductImageUpdateRequest request);
        Task<ProductImageViewModel> GetImageById(int imageId);
        Task<List<ProductImageViewModel>> GetListImages(int productId);
    }
}
