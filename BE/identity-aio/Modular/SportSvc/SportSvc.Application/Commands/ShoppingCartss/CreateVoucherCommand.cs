using AutoMapper;
using MediatR;
using SportSvc.Application.Contracts;
using SportSvc.Domain.Abstractions;
using SportSvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SportSvc.Application.Commands.ShoppingCartss
{
    public class CreateVoucherCommand : IRequest<Voucher>
    {
        public string? Name { get; set; }
        public double? Value { get; set; } //giảm bao nhiêu
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [JsonIgnore]
        public string? CreatedBy { get; set; }
        [JsonIgnore]
        public DateTime? CreatedDate { get; set; }
        [JsonIgnore]
        public string? LastModifiedBy { get; set; }
        [JsonIgnore]
        public DateTime? LastModifiedDate { get; set; }
    }
    public class CreateVoucherCommandHandler : IRequestHandler<CreateVoucherCommand, Voucher>
    {
        private readonly ISportSvcRepository _repository;
        private readonly IMapper _mapper;
        public CreateVoucherCommandHandler(ISportSvcRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Voucher> Handle(CreateVoucherCommand command, CancellationToken cancellationToken)
        {
            var value = _mapper.Map<Voucher>(command);
            return await _repository.CreateVoucher(value, cancellationToken);
        }
    }
}
