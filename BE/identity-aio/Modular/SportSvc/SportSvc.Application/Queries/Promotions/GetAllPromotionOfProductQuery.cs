using AutoMapper;
using Jhipster.Service.Utilities;
using MediatR;
using SportSvc.Application.Contracts;
using SportSvc.Application.Queries.Products;
using SportSvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSvc.Application.Queries.Promotions
{
    public class GetAllPromotionOfProductQuery : IRequest<PagedList<Promotion>>
    {
        public string ProductId { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }

    public class GetAllPromotionOfProductQueryHandler : IRequestHandler<GetAllPromotionOfProductQuery, PagedList<Promotion>>
    {
        private readonly IPromotionRepository _repository;
        private readonly IMapper _mapper;
        public GetAllPromotionOfProductQueryHandler(IPromotionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PagedList<Promotion>> Handle(GetAllPromotionOfProductQuery rq, CancellationToken cancellationToken)
        {
            return await _repository.GetAllPromotionOfProduct(rq.ProductId, rq.Page, rq.PageSize, cancellationToken);
        }
    }
}
