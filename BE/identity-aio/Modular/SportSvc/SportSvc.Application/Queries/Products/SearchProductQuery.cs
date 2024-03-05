using AutoMapper;
using Jhipster.Service.Utilities;
using MediatR;
using SportSvc.Application.Commands.ProductsC;
using SportSvc.Application.Contracts;
using SportSvc.Application.DTO;
using SportSvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSvc.Application.Queries.Products
{
    public class SearchProductQuery : IRequest<PagedList<ViewProduct>>
    {
        public string KeyWord {  get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
    public class SearchProductQueryHandler : IRequestHandler<SearchProductQuery, PagedList<ViewProduct>>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public SearchProductQueryHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PagedList<ViewProduct>> Handle(SearchProductQuery rq, CancellationToken cancellationToken)
        {
            return await _repository.SearchProduct(rq.KeyWord, rq.Page, rq.PageSize, cancellationToken);
        }
    }
}
