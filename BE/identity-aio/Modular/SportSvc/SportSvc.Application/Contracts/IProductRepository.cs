using Jhipster.Service.Utilities;
using SportSvc.Application.DTO;
using SportSvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSvc.Application.Contracts
{
    public interface IProductRepository
    {
        Task<int> CreateProduct(Product product, CancellationToken cancellationToken);
        Task<int> DeleteProduct(string productId, CancellationToken cancellationToken);
        Task<int> UpdateProduct(Product product, CancellationToken cancellationToken);
        Task<ViewProduct> GetDetailProduct(string productId, CancellationToken cancellationToken);
        Task<PagedList<ViewProduct>> GetAllProductBySportId(string sportId, int page, int pageSize, List<int>? Type, List<string>? Brand, double? Min, double? Max, CancellationToken cancellationToken);
        Task<PagedList<ViewProduct>> SearchProduct(string keyWord, int page, int pageSize, CancellationToken cancellationToken);
        Task<PagedList<ViewProduct>> GetAllProductInShop(string NameProduct, string SportName, int page, int pageSize, CancellationToken cancellationToken);
    }
}
