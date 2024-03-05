using AutoMapper;
using MediatR;
using SportSvc.Application.Contracts;
using SportSvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSvc.Application.Queries.ShoppingCartQ
{
    public class GetAllSportQuery : IRequest<List<Sport>>
    {

    }
    public class GetAllSportQueryHandler : IRequestHandler<GetAllSportQuery, List<Sport>>
    {
        private readonly ISportSvcRepository _repository;
        private readonly IMapper _mapper;
        public GetAllSportQueryHandler(ISportSvcRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<Sport>> Handle(GetAllSportQuery query, CancellationToken cancellationToken)
        {
            return await _repository.GetAllSports();
        }
    }
}
