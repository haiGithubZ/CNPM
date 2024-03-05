using AutoMapper;
using Jhipster.Infrastructure.Data;
using Jhipster.Service.Utilities;
using Microsoft.EntityFrameworkCore;
using SportSvc.Application.Contracts;
using SportSvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSvc.Infrastructure.Persistences.Repositories
{
    public class PromotionRepository : IPromotionRepository
    {
        private readonly ApplicationDatabaseContext _databaseContext;
        private readonly IMapper _mapper;
        public PromotionRepository(ApplicationDatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }
        public async Task<int> CreatePromotion(Promotion promotion, CancellationToken cancellationToken)
        {
            var checkPromotionExist = await _databaseContext.Promotions.Where(i => i.ProductId == promotion.ProductId).AsNoTracking().FirstOrDefaultAsync();
            if (checkPromotionExist != null && (checkPromotionExist.StartDate <= promotion.StartDate && checkPromotionExist.EndDate >= promotion.StartDate)) _databaseContext.Promotions.Remove(checkPromotionExist);
            await _databaseContext.Promotions.AddAsync(promotion);
            return await _databaseContext.SaveChangesAsync(cancellationToken);
        }
        public async Task<int> DeletePromotion(string promotionId, CancellationToken cancellationToken)
        {
            var check = await _databaseContext.Promotions.AsNoTracking().FirstOrDefaultAsync(i => i.PromotionId == promotionId);
            if (check == null)
            {
                throw new Exception("Promotion does not exist");
            }
            _databaseContext.Promotions.Remove(check);
            return await _databaseContext.SaveChangesAsync(cancellationToken);
        }
        public async Task<int> UpdatePromotion(Promotion promotion, CancellationToken cancellationToken)
        {
            var check = await _databaseContext.Promotions.AsNoTracking().FirstOrDefaultAsync(i => i.PromotionId == promotion.PromotionId);
            if (check == null) throw new Exception("Promotion does not exist");
            var map = _mapper.Map<Promotion, Promotion>(promotion, check);
            _databaseContext.Promotions.Update(check);
            return await _databaseContext.SaveChangesAsync(cancellationToken);
        }
        public async Task<Promotion> GetDetailPromotion(string promotionId, CancellationToken cancellationToken)
        {
            var promotion = await _databaseContext.Promotions.AsNoTracking().FirstOrDefaultAsync(i => i.PromotionId == promotionId);
            if (promotion == null) throw new Exception("Promotion does not exist");
            return promotion;
        }
        public async Task<PagedList<Promotion>> GetAllPromotionOfProduct(string productId, int page, int pageSize, CancellationToken cancellationToken)
        {
            var pagedList = new PagedList<Promotion>();
            var listPromotions = await _databaseContext.Promotions.AsNoTracking().Where(i => i.ProductId == productId && i.EndDate >= DateTime.UtcNow).ToListAsync();
            if (listPromotions == null)
            {
                throw new Exception("There are no promotions for this product");
            }
            listPromotions = listPromotions.OrderBy(p => p.StartDate).ToList();
            var data = listPromotions.Skip(pageSize * (page - 1)).Take(pageSize).ToList();
            pagedList.Data = data;
            pagedList.TotalCount = listPromotions.Count();
            return pagedList;
        }
        public async Task<PagedList<Promotion>> GetAllValidPromotion(int page, int pageSize, CancellationToken cancellationToken)
        {
            var pagedList = new PagedList<Promotion>();
            var listPromotions = await _databaseContext.Promotions.AsNoTracking().Where(i => i.EndDate >= DateTime.UtcNow).ToListAsync();
            if (listPromotions == null) throw new Exception("No valid promotion exist");
            listPromotions = listPromotions.OrderBy(p => p.StartDate).ToList();
            var data = listPromotions.Skip(pageSize * (page - 1)).Take(pageSize).ToList();
            pagedList.Data = data;
            pagedList.TotalCount = listPromotions.Count();
            return pagedList;
        }
    }
}
