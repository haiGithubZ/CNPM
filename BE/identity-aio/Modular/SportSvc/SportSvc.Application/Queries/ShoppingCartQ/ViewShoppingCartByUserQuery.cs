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
    public class ViewShoppingCartByUserQuery : IRequest<ViewShoppingCartDTO>
    {
        public string UserId { get; set; }
    }
    public class ViewShoppingCartByUserQueryHandler : IRequestHandler<ViewShoppingCartByUserQuery, ViewShoppingCartDTO>
    {
        private readonly ISportSvcRepository _repository;
        private readonly IMapper _mapper;
        public ViewShoppingCartByUserQueryHandler(ISportSvcRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ViewShoppingCartDTO> Handle(ViewShoppingCartByUserQuery query, CancellationToken cancellationToken)
        {
            return await _repository.ViewShoppingCartByUser(query.UserId, cancellationToken);
        }
    }
}
