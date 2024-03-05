using AutoMapper;
using Jhipster.Infrastructure.Data;
using Jhipster.Service.Utilities;
using Microsoft.EntityFrameworkCore;
using SportSvc.Application.Contracts;
using SportSvc.Application.DTO;
using SportSvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSvc.Infrastructure.Persistences.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDatabaseContext _databaseContext;
        private readonly IMapper _mapper;
        public ProductRepository(ApplicationDatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }
        public async Task<int> CreateProduct(Product product, CancellationToken cancellationToken)
        {
            await _databaseContext.Products.AddAsync(product);
            return await _databaseContext.SaveChangesAsync(cancellationToken);
        }
        public async Task<int> DeleteProduct(string productId, CancellationToken cancellationToken)
        {
            var check = await _databaseContext.Products.AsNoTracking().FirstOrDefaultAsync(i => i.Id == productId);
            if (check == null)
            {
                throw new Exception("Product does not exist");
            }
            _databaseContext.Products.Remove(check);
            var promotion = await _databaseContext.Promotions.AsNoTracking().FirstOrDefaultAsync(i =>i.ProductId == productId);
            _databaseContext.Promotions.Remove(promotion);
            return await _databaseContext.SaveChangesAsync(cancellationToken);
        }
        public async Task<int> UpdateProduct(Product product, CancellationToken cancellationToken)
        {
            var check = await _databaseContext.Products.AsNoTracking().FirstOrDefaultAsync(i => i.Id == product.Id && i.Type != 5);
            if (check == null) throw new Exception("Product does not exist");
            var map = _mapper.Map<Product, Product>(product, check);
            _databaseContext.Products.Update(check);
            return await _databaseContext.SaveChangesAsync(cancellationToken);
        }
        public async Task<ViewProduct> GetDetailProduct(string productId, CancellationToken cancellationToken)
        {
            var product = await _databaseContext.Products.AsNoTracking().FirstOrDefaultAsync(i => i.Id == productId);
            if (product == null) throw new Exception("Product does not exist");
            var res = _mapper.Map<ViewProduct>(product);
            var promotion = await _databaseContext.Promotions.AsNoTracking().FirstOrDefaultAsync(i => i.ProductId == productId && i.EndDate >= DateTime.Now);
            if (promotion != null)
            {
                res.PromotionPrice = res.Price * (100 - promotion.Discount) / 100;
                res.EndDatePromotion = promotion.EndDate;
                res.Promotion = promotion.PromotionName;
            }
            return res;
        }
        public async Task<PagedList<ViewProduct>> GetAllProductBySportId(string sportId, int page, int pageSize, List<int>? Type, List<string>? Brand, double? Min, double? Max, CancellationToken cancellationToken)
        {
            var pagedList = new PagedList<ViewProduct>();
            var temp = await _databaseContext.Products.AsNoTracking().Where(i => i.SportId == sportId && i.Type !=5 ).ToListAsync();
            var listProd = new List<Product>();
            if (Brand != null)
            {
                for (int i = 0; i < Brand.Count; i++)
                {
                    Brand[i] = Brand[i].ToUpper();
                }

                foreach (var item in temp)
                {
                    if (Brand.Contains(item.Brand.ToUpper()))
                    {
                        listProd.Add(item);
                    }
                }
            }
            else
            {
                listProd = temp;
            }
            if (Min != null) listProd = listProd.Where(i => i.Price >= Min).ToList();

            if (Max != null) listProd = listProd.Where(i => i.Price <= Max).ToList();

            if (Type != null) listProd = listProd.Where(i => Type.Contains(i.Type)).ToList();

            var prodPromotion = _mapper.Map<List<ViewProduct>>(listProd);
            foreach (var item in prodPromotion)
            {
                var promotion = await _databaseContext.Promotions.AsNoTracking().FirstOrDefaultAsync(i => i.ProductId == item.Id && i.EndDate >= DateTime.Now);
                if (promotion != null)
                {
                    item.PromotionPrice = item.Price * (100 - promotion.Discount) / 100;
                    item.EndDatePromotion = promotion.EndDate;
                    item.Promotion = promotion.PromotionName;
                }
            }
            prodPromotion = prodPromotion.OrderBy(i => i.PromotionPrice).ToList();
            var data = prodPromotion.Skip(pageSize * (page - 1)).Take(pageSize).ToList();
            pagedList.Data = data;
            pagedList.TotalCount = prodPromotion.Count();
            return pagedList;
        }
        public async Task<PagedList<ViewProduct>> SearchProduct(string keyWord, int page, int pageSize, CancellationToken cancellationToken)
        {
            var pagedList = new PagedList<ViewProduct>();
            var response = await _databaseContext.Products.Where(m => m.Type != 5 && m.Description.ToUpper().Contains(keyWord.ToUpper())
                || m.Name.ToUpper().Contains(keyWord.ToUpper())).ToListAsync();

            var prodPromotion = _mapper.Map<List<ViewProduct>>(response);
            foreach (var item in prodPromotion)
            {
                var promotion = await _databaseContext.Promotions.AsNoTracking().FirstOrDefaultAsync(i => i.ProductId == item.Id && i.EndDate >= DateTime.Now);
                if (promotion != null)
                {
                    item.PromotionPrice = item.Price * (100 - promotion.Discount) / 100;
                    item.EndDatePromotion = promotion.EndDate;
                    item.Promotion = promotion.PromotionName;

                }
            }
            prodPromotion = prodPromotion.OrderBy(i => i.PromotionPrice).ToList();
            var data = prodPromotion.Skip(pageSize * (page - 1)).Take(pageSize).ToList();
            pagedList.Data = data;
            pagedList.TotalCount = prodPromotion.Count();
            return pagedList;
        }
        public async Task<PagedList<ViewProduct>> GetAllProductInShop(string NameProduct, string SportName, int page, int pageSize, CancellationToken cancellationToken)
        {
            var listSport = await _databaseContext.Sports.ToListAsync();
            var pagedList = new PagedList<ViewProduct>();
            var result = new List<ViewProduct>();
            foreach (var a in listSport)
            {
                var listProduct = await _databaseContext.Products.Where(i => i.SportId == a.Id && i.Type != 5).ToListAsync();
                var listP = _mapper.Map<List<ViewProduct>>(listProduct);
                foreach (var item in listP)
                {
                    var promotion = await _databaseContext.Promotions.AsNoTracking().FirstOrDefaultAsync(i => i.ProductId == item.Id && i.EndDate >= DateTime.Now);
                    if (promotion != null)
                    {
                        item.PromotionPrice = item.Price * (100 - promotion.Discount) / 100;
                        item.EndDatePromotion = promotion.EndDate;
                        item.Promotion = promotion.PromotionName;

                    }
                    item.SportName = a.Name;
                }
                result.AddRange(listP);
            }
            if (!string.IsNullOrEmpty(NameProduct)) result = result.Where(i => i.Name.Contains(NameProduct)).ToList();
            if (!string.IsNullOrEmpty(SportName)) result = result.Where(i => i.SportName == SportName).ToList();


            result = result.OrderBy(i => i.PromotionPrice).ToList();
            var data = result.Skip(pageSize * (page - 1)).Take(pageSize).ToList();
            pagedList.Data = data;
            pagedList.TotalCount = result.Count();
            return pagedList;
        }
    }
}
