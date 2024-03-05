using AutoMapper;
using MediatR;
using SportSvc.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSvc.Application.Queries.ShoppingCartQ
{
    public class GetTotalMoneyInShoppingCartQuery : IRequest<double>
    {
        public double intoMoney { get; set; }
        public string? voucherCode { get; set; }
    }
    public class GetTotalMoneyInShoppingCartQueryHandler : IRequestHandler<GetTotalMoneyInShoppingCartQuery, double>
    {
        private readonly ISportSvcRepository _repository;
        private readonly IMapper _mapper;
        public GetTotalMoneyInShoppingCartQueryHandler(ISportSvcRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<double> Handle(GetTotalMoneyInShoppingCartQuery query, CancellationToken cancellationToken)
        {
            return await _repository.GetTotalMoneyInShoppingCart(query.intoMoney, query.voucherCode, cancellationToken);
        }
    }
}
