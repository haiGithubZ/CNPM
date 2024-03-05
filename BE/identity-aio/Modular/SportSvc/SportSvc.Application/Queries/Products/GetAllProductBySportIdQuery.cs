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
    public class GetAllProductBySportIdQuery : IRequest<PagedList<ViewProduct>>
    {
        public string? SportId { get; set; }
        public List<int>? Type { get; set; }
        public List<string>? Brand { get; set; }
        public double? Min { get; set; }
        public double? Max { get; set; }    
        public int Page {  get; set; }
        public int PageSize {  get; set; }
    }
    public class GetAllProductBySportIdQueryHandler : IRequestHandler<GetAllProductBySportIdQuery, PagedList<ViewProduct>>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public GetAllProductBySportIdQueryHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PagedList<ViewProduct>> Handle(GetAllProductBySportIdQuery rq, CancellationToken cancellationToken)
        {
            return await _repository.GetAllProductBySportId(rq.SportId, rq.Page, rq.PageSize, rq.Type, rq.Brand, rq.Min, rq.Max, cancellationToken);
        }
    }
}
