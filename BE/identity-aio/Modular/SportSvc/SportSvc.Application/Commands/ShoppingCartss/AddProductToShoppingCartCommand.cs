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
    public class AddProductToShoppingCartCommand : IRequest<ShoppingCartItem>
    {
        public string? ProductId { get; set; }
        public string? UserId { get; set; }
        public int Quantity { get; set; }
        public string? Size { get; set; }
        public string? Color { get; set; }
    }
    public class AddProductToShoppingCartCommandHandler : IRequestHandler<AddProductToShoppingCartCommand, ShoppingCartItem>
    {
        private readonly ISportSvcRepository _repository;
        private readonly IMapper _mapper;
        public AddProductToShoppingCartCommandHandler(ISportSvcRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ShoppingCartItem> Handle(AddProductToShoppingCartCommand command, CancellationToken cancellationToken)
        {
            return await _repository.AddProductToShoppingCart(command.ProductId, command.Quantity, command.Size, command.Color, command.UserId, cancellationToken);
        }
    }
}
