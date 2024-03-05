using AutoMapper;
using MediatR;
using SportSvc.Application.Contracts;
using SportSvc.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSvc.Application.Queries.ShoppingCartQ
{
    public class GetAllCityQuery : IRequest<List<CityDTO>>
    {
    }
    public class GetAllCityQueryHandler : IRequestHandler<GetAllCityQuery, List<CityDTO>>
    {
        private readonly ISportSvcRepository _repository;
        private readonly IMapper _mapper;
        public GetAllCityQueryHandler(ISportSvcRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<CityDTO>> Handle(GetAllCityQuery query, CancellationToken cancellationToken)
        {
            return await _repository.GetAllCity();
        }
    }
}
