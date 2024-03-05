using AutoMapper;
using MediatR;
using SportSvc.Application.Contracts;
using SportSvc.Domain.Abstractions;
using SportSvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SportSvc.Application.Commands.ShoppingCartss
{
    public class AddAddressByUserCommand : IRequest<Address>
    {
        public string? UserId { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
        public string? Ward { get; set; }
        public int? Status { get; set; } //0: Mặc định, 1: Tùy chọn
        [JsonIgnore]
        public string? CreatedBy { get; set; }
        [JsonIgnore]
        public DateTime? CreatedDate { get; set; }
        [JsonIgnore]
        public string? LastModifiedBy { get; set; }
        [JsonIgnore]
        public DateTime? LastModifiedDate { get; set; }
    }
    public class AddAddressByUserCommandHandler : IRequestHandler<AddAddressByUserCommand, Address>
    {
        private readonly ISportSvcRepository _sportSvcRepository;
        private readonly IMapper _mapper;
        public AddAddressByUserCommandHandler(ISportSvcRepository sportSvcRepository, IMapper mapper)
        {
            _sportSvcRepository = sportSvcRepository;
            _mapper = mapper;
        }
        public async Task<Address> Handle(AddAddressByUserCommand command, CancellationToken cancellationToken)
        {
            var value = _mapper.Map<Address>(command);
            return await _sportSvcRepository.AddAddressByUser(value, cancellationToken);
        }
    }
}
