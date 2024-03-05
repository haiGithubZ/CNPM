using AutoMapper;
using MediatR;
using SportSvc.Application.Contracts;
using SportSvc.Application.DTO;
using SportSvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSvc.Application.Queries.ShoppingCartQ
{
    public class GetShoppingOrderQuery : IRequest<Bill>
    {
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
        public string? Ward { get; set; }
        public string? ShoppingCartId { get; set; }
    }
    public class GetShoppingOrderQueryHandler : IRequestHandler<GetShoppingOrderQuery, Bill>
    {
        private readonly ISportSvcRepository _repository;
        private readonly IMapper _mapper;
        public GetShoppingOrderQueryHandler(ISportSvcRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Bill> Handle(GetShoppingOrderQuery query, CancellationToken cancellationToken)
        {
            var value = new Information()
            {
                FullName = query.FullName,
                PhoneNumber = query.PhoneNumber,
                City = query.City,
                District = query.District,
                Ward = query.Ward,
            };
            return await _repository.GetShoppingOrder(value, query.ShoppingCartId, cancellationToken);
        }
    }
}
