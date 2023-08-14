using eShopSolution.ViewModels.Catalog.Product;
using eShopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e.ShopSolution.Application.Catalog
{
    public interface IPublicProductService
    {
        Task<PagedResult<ProductViewModel>> GetAllByCategoryId(string languageId,GetPublicProductPagingRequest request);

        
    }
}
