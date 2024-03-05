using AutoMapper;
using Jhipster.Service.Utilities;
using MediatR;
using SportSvc.Application.Contracts;
using SportSvc.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSvc.Application.Queries.Products
{
    public class GetAllProductInShopQuery : IRequest<PagedList<ViewProduct>>
    {
        public string? ProductName { get; set; }
        public string? SportName { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllProductInShopQueryHandler : IRequestHandler<GetAllProductInShopQuery, PagedList<ViewProduct>>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public GetAllProductInShopQueryHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PagedList<ViewProduct>> Handle(GetAllProductInShopQuery query, CancellationToken cancellationToken)
        {
            return await _repository.GetAllProductInShop(query.ProductName, query.SportName, query.Page, query.PageSize, cancellationToken);
        }
    }
}
