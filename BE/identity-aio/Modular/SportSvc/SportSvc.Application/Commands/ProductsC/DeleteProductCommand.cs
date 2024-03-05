using AutoMapper;
using MediatR;
using SportSvc.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSvc.Application.Commands.ProductsC
{
    public class DeleteProductCommand : IRequest<int>
    {
        public string ProductId { get; set; }
    }
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, int>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public DeleteProductCommandHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<int> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            return await _repository.DeleteProduct(command.ProductId, cancellationToken);
        }
    }
}
