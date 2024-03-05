using AutoMapper;
using MediatR;
using SportSvc.Application.Contracts;
using SportSvc.Domain.Abstractions;
using SportSvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSvc.Application.Queries.ShoppingCartQ
{
    public class ViewAllTransactionHistoryQuery : IRequest<List<Bill>>
    {
        public string UserId { get; set; }
    }
    public class ViewAllTransactionHistoryQueryHandler : IRequestHandler<ViewAllTransactionHistoryQuery, List<Bill>>
    {
        private readonly ISportSvcRepository _repository;
        private readonly IMapper _mapper;
        public ViewAllTransactionHistoryQueryHandler(ISportSvcRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<Bill>> Handle(ViewAllTransactionHistoryQuery query, CancellationToken cancellationToken)
        {
            return await _repository.ViewAllTransactionHistory(query.UserId, cancellationToken);
        }
    }
}
