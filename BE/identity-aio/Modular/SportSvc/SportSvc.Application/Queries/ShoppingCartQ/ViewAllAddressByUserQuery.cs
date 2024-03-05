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
    public class ViewAllAddressByUserQuery : IRequest<List<Address>>
    {
        public string UserId { get; set; }
    }
    public class ViewAllAddressByUserQueryHandler : IRequestHandler<ViewAllAddressByUserQuery, List<Address>>
    {
        private readonly ISportSvcRepository _repository;
        private readonly IMapper _mapper;
        public ViewAllAddressByUserQueryHandler(ISportSvcRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<Address>> Handle(ViewAllAddressByUserQuery query, CancellationToken cancellationToken)
        {
            return await _repository.ViewAllAddressByUser(query.UserId, cancellationToken);
        }
    }
}
