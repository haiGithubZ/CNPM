using AutoMapper;
using MediatR;
using SportSvc.Application.Contracts;
using SportSvc.Application.Queries.Promotions;
using SportSvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSvc.Application.Queries.Promotions
{
    public class GetDetailPromotionQuery : IRequest<Promotion>
    {
        public string PromotionId { get; set; }
    }
    public class GetDetailPromotionQueryHandler : IRequestHandler<GetDetailPromotionQuery, Promotion>
    {
        private readonly IPromotionRepository _repository;
        private readonly IMapper _mapper;
        public GetDetailPromotionQueryHandler(IPromotionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Promotion> Handle(GetDetailPromotionQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetDetailPromotion(request.PromotionId, cancellationToken);
        }
    }
}
