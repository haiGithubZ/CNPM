using AutoMapper;
using MediatR;
using SportSvc.Application.Contracts;
using SportSvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSvc.Application.Queries.ShoppingCartQ
{
    public class SearchAndDetailBillQuery : IRequest<Bill>
    {
        public string Code { get; set; }
        public string UserId { get; set; }
    }
    public class SearchAndDetailBillQueryHandler : IRequestHandler<SearchAndDetailBillQuery, Bill>
    {
        private readonly ISportSvcRepository _repository;
        private readonly IMapper _mapper;
        public SearchAndDetailBillQueryHandler(ISportSvcRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Bill> Handle(SearchAndDetailBillQuery query, CancellationToken cancellationToken)
        {
            return await _repository.SearchAndDetailBill(query.Code, query.UserId, cancellationToken);
        }
    }
    
}
