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
    public class StadiumRepository : IStadiumRepository
    {
        private readonly ApplicationDatabaseContext _databaseContext;
        private readonly IMapper _mapper;
        public StadiumRepository(ApplicationDatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public async Task<PagedList<Product>> GetAllStadium(int page, int pageSize, CancellationToken cancellationToken)
        {
            var pagedList = new PagedList<Product>();
            var listProd = await _databaseContext.Products.AsNoTracking().Where(i => i.Type == 5).ToListAsync();
            if (listProd == null) throw new Exception("Does not exist any stadium ");
            listProd = listProd.OrderBy( i => i.Price).ToList();
            var data = listProd.Skip(pageSize*(page - 1)).Take(pageSize).ToList();
            pagedList.Data = data;
            pagedList.TotalCount = listProd.Count();
            return pagedList;
        }

        public async Task<Product> GetDetailStadium(string productId, CancellationToken cancellationToken)
        {
            var product = await _databaseContext.Products.AsNoTracking().FirstOrDefaultAsync(i => i.Id == productId);
            if (product == null) throw new Exception("Stadium does not exist");
            return product;
        }

        public async Task<PagedList<Product>> SearchStadium(string keyWord, int page, int pageSize, CancellationToken cancellationToken)
        {
            var pagedList = new PagedList<Product>();
            //var response = await _databaseContext.Products.Where(m => m.Type == 5 && (m.Description.ToUpper().Contains(keyWord.ToUpper())
                //|| m.Name.ToUpper().Contains(keyWord.ToUpper()) || m.Address.ToUpper().Contains(keyWord.ToUpper()))).ToListAsync();

            var response = await _databaseContext.Products.Where(m => m.Type == 5 && (m.Name.ToUpper().Contains(keyWord.ToUpper()) || m.Address.ToUpper().Contains(keyWord.ToUpper()) || m.Description.ToUpper().Contains(keyWord.ToUpper()))).ToListAsync();
            response = response.OrderBy(i => i.Price).ToList();
            var data = response.Skip(pageSize * (page - 1)).Take(pageSize).ToList();
            pagedList.Data = data;
            pagedList.TotalCount = response.Count();
            return pagedList;
        }







    }
}
