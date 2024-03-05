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
    public class ConfirmShoppingOrderCommand : IRequest<int>
    {
        public int Status { get; set; }
        public string Code { get; set; }
        public string UserId { get; set; }
    }
    public class ConfirmShoppingOrderCommandHandler : IRequestHandler<ConfirmShoppingOrderCommand, int>
    {
        private readonly ISportSvcRepository _repository;
        private readonly IMapper _mapper;
        public ConfirmShoppingOrderCommandHandler(ISportSvcRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<int> Handle(ConfirmShoppingOrderCommand command, CancellationToken cancellationToken)
        {
            return await _repository.ConfirmShoppingOrder(command.Status, command.Code, command.UserId, cancellationToken);
        }
    }
}
