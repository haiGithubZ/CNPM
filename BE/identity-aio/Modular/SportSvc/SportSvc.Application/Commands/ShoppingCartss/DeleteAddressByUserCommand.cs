using AutoMapper;
using MediatR;
using SportSvc.Application.Contracts;
using SportSvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSvc.Application.Commands.ShoppingCartss
{
    public class DeleteAddressByUserCommand : IRequest<Address>
    {
        public string addressId { get; set; }
    }
    public class DeleteAddressByUserCommandHandler : IRequestHandler<DeleteAddressByUserCommand, Address>
    {
        private readonly ISportSvcRepository _repository;
        private readonly IMapper _mapper;
        public DeleteAddressByUserCommandHandler(ISportSvcRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Address> Handle(DeleteAddressByUserCommand command, CancellationToken cancellationToken)
        {
            return await _repository.DeleteAddressByUser(command.addressId, cancellationToken);
        }
    }
}
