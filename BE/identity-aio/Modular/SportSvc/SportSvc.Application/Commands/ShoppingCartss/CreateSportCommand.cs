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
    public class CreateSportCommand : IRequest<Sport>
    {
        public string? Name { get; set; }
    }
    public class CreateSportCommandHandler : IRequestHandler<CreateSportCommand, Sport>
    {
        private readonly ISportSvcRepository _repository;
        private readonly IMapper _mapper;
        public CreateSportCommandHandler(ISportSvcRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Sport> Handle(CreateSportCommand command, CancellationToken cancellationToken)
        {
            var value = _mapper.Map<Sport>(command);
            return await _repository.CreateSport(value, cancellationToken);
        }
    }
}
