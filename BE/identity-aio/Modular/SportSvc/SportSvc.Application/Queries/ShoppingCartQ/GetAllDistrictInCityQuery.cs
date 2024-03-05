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
    public class GetAllDistrictInCityQuery : IRequest<List<DistrictDTO>>
    {
        public string city_code { get; set; }
    }
    public class GetAllDistrictInCityQueryHandler : IRequestHandler<GetAllDistrictInCityQuery, List<DistrictDTO>>
    {
        private readonly ISportSvcRepository _repository;
        private readonly IMapper _mapper;
        public GetAllDistrictInCityQueryHandler(ISportSvcRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<DistrictDTO>> Handle(GetAllDistrictInCityQuery query, CancellationToken cancellationToken)
        {
            return await _repository.GetAllDistrict(query.city_code);
        }
    }
}
