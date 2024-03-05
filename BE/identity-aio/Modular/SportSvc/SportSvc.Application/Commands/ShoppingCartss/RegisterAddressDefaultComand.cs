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
    public class RegisterAddressDefaultComand: IRequest<Address>
    {
        public string AddressId { get; set; }
    }
    public class RegisterAddressDefaultComandHandler : IRequestHandler<RegisterAddressDefaultComand, Address>
    {
        private readonly ISportSvcRepository _repository;
        private readonly IMapper _mapper;
        public RegisterAddressDefaultComandHandler(ISportSvcRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Address> Handle(RegisterAddressDefaultComand comand, CancellationToken cancellationToken)
        {
            return await _repository.RegisterAddressDefault(comand.AddressId, cancellationToken);
        }
    }
}
