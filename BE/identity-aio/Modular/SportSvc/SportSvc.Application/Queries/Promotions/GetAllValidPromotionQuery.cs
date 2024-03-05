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
    public class GetAllValidPromotionQuery : IRequest<PagedList<Promotion>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }

    public class GetAllValidPromotionQueryHandler : IRequestHandler<GetAllValidPromotionQuery, PagedList<Promotion>>
    {
        private readonly IPromotionRepository _repository;
        private readonly IMapper _mapper;
        public GetAllValidPromotionQueryHandler(IPromotionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PagedList<Promotion>> Handle(GetAllValidPromotionQuery rq, CancellationToken cancellationToken)
        {
            return await _repository.GetAllValidPromotion (rq.Page, rq.PageSize, cancellationToken);
        }
    }
}
