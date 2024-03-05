using AutoMapper;
using MediatR;
using SportSvc.Application.Contracts;
using SportSvc.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Information = SportSvc.Application.DTO.Information;

namespace SportSvc.Application.Queries.ShoppingCartQ
{
    public class GetInformationDefaultQuery : IRequest<Information>
    {
        public string UserId { get; set; }
    }
    public class GetInformationDefaultQueryHandler : IRequestHandler<GetInformationDefaultQuery, Information>
    {
        private readonly ISportSvcRepository _repository;
        private readonly IMapper _mapper;
        public GetInformationDefaultQueryHandler(ISportSvcRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Information> Handle(GetInformationDefaultQuery query, CancellationToken cancellationToken)
        {
            return await _repository.GetInformationDefault(query.UserId, cancellationToken);
        }
    }
}
