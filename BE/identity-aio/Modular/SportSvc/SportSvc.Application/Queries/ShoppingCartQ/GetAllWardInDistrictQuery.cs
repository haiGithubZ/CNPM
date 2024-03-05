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
    public class GetAllWardInDistrictQuery : IRequest<List<WardDTO>>
    {
        public string district_code { get; set; }
    }
    public class GetAllWardInDistrictQueryHandler : IRequestHandler<GetAllWardInDistrictQuery, List<WardDTO>>
    {
        private readonly ISportSvcRepository _repository;
        private readonly IMapper _mapper;
        public GetAllWardInDistrictQueryHandler(ISportSvcRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<WardDTO>> Handle(GetAllWardInDistrictQuery query, CancellationToken cancellationToken)
        {
            return await _repository.GetAllWard(query.district_code);
        }
    }
}
