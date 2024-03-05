using AutoMapper;
using Jhipster.Service.Utilities;
using MediatR;
using SportSvc.Application.Commands.ProductsC;
using SportSvc.Application.Contracts;
using SportSvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSvc.Application.Queries.Products
{
    public class SearchStadiumQuery : IRequest<PagedList<Product>>
    {
        public string KeyWord { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
    public class SearchStadiumQueryHandler : IRequestHandler<SearchStadiumQuery, PagedList<Product>>
    {
        private readonly IStadiumRepository _repository;
        private readonly IMapper _mapper;
        public SearchStadiumQueryHandler(IStadiumRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PagedList<Product>> Handle(SearchStadiumQuery rq, CancellationToken cancellationToken)
        {
            return await _repository.SearchStadium(rq.KeyWord, rq.Page, rq.PageSize, cancellationToken);
        }
    }
}