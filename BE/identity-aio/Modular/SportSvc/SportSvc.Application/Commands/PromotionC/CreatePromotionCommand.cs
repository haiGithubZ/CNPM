using AutoMapper;
using MediatR;
using SportSvc.Application.Contracts;
using SportSvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SportSvc.Application.Commands.PromotionC
{
    public class CreatePromotionCommand : IRequest<Promotion>
    {
        public string? ProductId { get; set; }
        public string? PromotionName { get; set; }
        public double? Discount { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [JsonIgnore]
        public string? CreatedBy { get; set; }
        [JsonIgnore]
        public string? LastModifiedBy { get; set; }
    }
    public class CreatePromotionCommandHandler : IRequestHandler<CreatePromotionCommand, Promotion>
    {
        private readonly IPromotionRepository _repository;
        private readonly IMapper _mapper;
        public CreatePromotionCommandHandler(IPromotionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Promotion> Handle(CreatePromotionCommand command, CancellationToken cancellationToken)
        {
            var map = _mapper.Map<Promotion>(command);
            map.Id = Guid.NewGuid().ToString();
            map.PromotionId = Guid.NewGuid().ToString();
            map.CreatedDate = DateTime.Now;
            map.LastModifiedDate = DateTime.Now;
            var check = await _repository.CreatePromotion(map, cancellationToken);
            if (check >= 0) return map;
            throw new Exception("Faild");
        }
    }
}
