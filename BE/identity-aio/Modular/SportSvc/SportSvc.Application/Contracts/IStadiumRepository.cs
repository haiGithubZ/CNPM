using Jhipster.Service.Utilities;
using SportSvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSvc.Application.Contracts
{
    public interface IStadiumRepository
    {


        Task<PagedList<Product>> GetAllStadium(int page, int pageSize, CancellationToken cancellationToken);
        Task<Product> GetDetailStadium(string productId, CancellationToken cancellationToken);
        Task<PagedList<Product>> SearchStadium(string keyWord, int page, int pageSize, CancellationToken cancellationToken);
    }
}
