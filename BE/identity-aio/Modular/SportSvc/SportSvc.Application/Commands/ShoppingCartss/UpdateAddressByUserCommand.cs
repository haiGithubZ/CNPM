using AutoMapper;
using MediatR;
using SportSvc.Application.Contracts;
using SportSvc.Application.DTO;
using SportSvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSvc.Application.Commands.ShoppingCartss
{
    public class UpdateAddressByUserCommand : IRequest<Address>
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string UserId { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
        public string? Ward { get; set; }
        public int? Status { get; set; } //0: Mặc định, 1: Tùy chọn
    }
    public class UpdateAddressByUserCommandHandler : IRequestHandler<UpdateAddressByUserCommand, Address>
    {
        private readonly ISportSvcRepository _repository;
        private readonly IMapper _mapper;
        public UpdateAddressByUserCommandHandler(ISportSvcRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Address> Handle(UpdateAddressByUserCommand command, CancellationToken cancellationToken)
        {
            var value = _mapper.Map<AddressDTO>(command);
            return await _repository.UpdateAddressByUser(value, cancellationToken);
        }
    }
}
