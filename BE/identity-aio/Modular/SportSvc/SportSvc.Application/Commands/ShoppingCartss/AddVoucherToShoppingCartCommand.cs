using AutoMapper;
using MediatR;
using SportSvc.Application.Contracts;
using SportSvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSvc.Application.Commands.ShoppingCartss
{
    public class AddVoucherToShoppingCartCommand : IRequest<Voucher>
    {
        [Required]
        public string voucherCode { get; set; }
        [Required]
        public string ShoppingCartId { get; set; }  
    }
    public class AddVoucherToShoppingCartCommandHandler : IRequestHandler<AddVoucherToShoppingCartCommand, Voucher>
    {
        private readonly ISportSvcRepository _repository;
        private readonly IMapper _mapper;
        public AddVoucherToShoppingCartCommandHandler(ISportSvcRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Voucher> Handle(AddVoucherToShoppingCartCommand command, CancellationToken cancellationToken)
        {
            return await _repository.AddVoucherToShoppingCart(command.voucherCode, command.ShoppingCartId, cancellationToken);
        }
    }
}
