using AutoMapper;
using MediatR;
using SportSvc.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSvc.Application.Commands.ShoppingCartss
{
    public class DeleteVoucherForCartCommand : IRequest<int>
    {
        public string ShoppingCartId { get; set; }
    }
    public class DeleteVoucherForCartCommandHandler : IRequestHandler<DeleteVoucherForCartCommand, int>
    {
        private readonly ISportSvcRepository _repository;
        private readonly IMapper _mapper;
        public DeleteVoucherForCartCommandHandler(ISportSvcRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<int> Handle(DeleteVoucherForCartCommand command, CancellationToken cancellationToken)
        {
            return await _repository.DeleteVoucherForShoppingCart(command.ShoppingCartId, cancellationToken);
        }
    }
}
