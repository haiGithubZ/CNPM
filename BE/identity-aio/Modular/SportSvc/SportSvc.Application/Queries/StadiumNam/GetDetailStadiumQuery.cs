using AutoMapper;
using MediatR;
using SportSvc.Application.Commands.ProductsC;
using SportSvc.Application.Contracts;
using SportSvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSvc.Application.Queries.Products
{
    public class GetDetailStadiumQuery : IRequest<Product>
    {
        public string ProductId { get; set; }
    }
    public class GetDetailStadiumQueryHandler : IRequestHandler<GetDetailStadiumQuery, Product>
    {
        private readonly IStadiumRepository _repository;
        private readonly IMapper _mapper;
        public GetDetailStadiumQueryHandler(IStadiumRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Product> Handle(GetDetailStadiumQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetDetailStadium(request.ProductId, cancellationToken);
        }
    }
}