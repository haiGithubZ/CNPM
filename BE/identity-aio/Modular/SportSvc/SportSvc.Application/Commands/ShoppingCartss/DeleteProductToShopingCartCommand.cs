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
    public class DeleteProductToShopingCartCommand : IRequest<List<ShoppingCartItem>>
    {
        public List<string>? ShoppingCartItemId { get; set; }
    }
    public class DeleteProductToShopingCartCommandHandler : IRequestHandler<DeleteProductToShopingCartCommand, List<ShoppingCartItem>>
    {
        private readonly ISportSvcRepository _repository;
        private readonly IMapper _mapper;
        public DeleteProductToShopingCartCommandHandler(ISportSvcRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<ShoppingCartItem>> Handle(DeleteProductToShopingCartCommand command, CancellationToken cancellationToken)
        {
            return await _repository.DeleteProductToShopingCart(command.ShoppingCartItemId, cancellationToken);
        }
    }
}
