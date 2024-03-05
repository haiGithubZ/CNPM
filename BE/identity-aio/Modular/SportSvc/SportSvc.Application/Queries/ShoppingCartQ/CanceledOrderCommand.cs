using AutoMapper;
using MediatR;
using SportSvc.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSvc.Application.Queries.ShoppingCartQ
{
    public class CanceledOrderCommand : IRequest<int>
    {
        public string Code { get; set; }
        public string UserId { get; set; }
    }
    public class CanceledOrderCommandHandler : IRequestHandler<CanceledOrderCommand, int>
    {
        private readonly ISportSvcRepository _repository;
        private readonly IMapper _mapper;
        public CanceledOrderCommandHandler(ISportSvcRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CanceledOrderCommand command, CancellationToken cancellationToken)
        {
            return await _repository.CanceledOrder(command.Code, command.UserId, cancellationToken);
        }
    }
}
