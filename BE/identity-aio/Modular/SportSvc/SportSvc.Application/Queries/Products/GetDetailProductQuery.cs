using AutoMapper;
using MediatR;
using SportSvc.Application.Commands.ProductsC;
using SportSvc.Application.Contracts;
using SportSvc.Application.DTO;
using SportSvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSvc.Application.Queries.Products
{
    public class GetDetailProductQuery : IRequest<ViewProduct>
    {
        public string ProductId { get; set; }
    }
    public class GetDetailProductQueryHandler : IRequestHandler<GetDetailProductQuery, ViewProduct>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public GetDetailProductQueryHandler(IProductRepository repository, IMapper mapper)
        {   
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ViewProduct> Handle(GetDetailProductQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetDetailProduct(request.ProductId, cancellationToken);
        }
    }
}
