using Jhipster.Service.Utilities;
using SportSvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSvc.Application.Contracts
{
    public interface IPromotionRepository
    {
        Task<int> CreatePromotion(Promotion promotion, CancellationToken cancellationToken);
        Task<int> DeletePromotion(string promotionId, CancellationToken cancellationToken);
        Task<int> UpdatePromotion(Promotion promotion, CancellationToken cancellationToken);
        Task<Promotion> GetDetailPromotion(string PromotionId, CancellationToken cancellationToken);
        Task<PagedList<Promotion>> GetAllPromotionOfProduct(string productId, int page, int pageSize, CancellationToken cancellationToken);
        Task<PagedList<Promotion>> GetAllValidPromotion(int page, int pageSize, CancellationToken cancellationToken);
    }
}
