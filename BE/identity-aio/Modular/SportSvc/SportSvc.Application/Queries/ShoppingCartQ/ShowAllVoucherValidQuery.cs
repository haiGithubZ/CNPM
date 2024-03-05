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
    public class ShowAllVoucherValidQuery : IRequest<List<Voucher>>
    {

    }
    public class ShowAllVoucherValidQueryHandler : IRequestHandler<ShowAllVoucherValidQuery, List<Voucher>>
    {
        private readonly ISportSvcRepository _repository;
        private readonly IMapper _mapper;
        public ShowAllVoucherValidQueryHandler(ISportSvcRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<Voucher>> Handle(ShowAllVoucherValidQuery query, CancellationToken cancellationToken)
        {
            return await _repository.ShowAllVoucherValid();
        }
    }
}
