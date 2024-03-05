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
    public class UpdatePromotionCommand : IRequest<Promotion>
    {
        public string PromotionId { get; set; }
        public string? ProductId { get; set; }
        public string? PromotionName { get; set; }
        public double? Discount { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [JsonIgnore]
        public DateTime? LastModifiedDate { get; set; }
        [JsonIgnore]
        public string? LastModifiedBy { get; set; }
    }
    public class UpdatePromotionCommandHandler : IRequestHandler<UpdatePromotionCommand, Promotion>
    {
        private readonly IPromotionRepository _repository;
        private readonly IMapper _mapper;
        public UpdatePromotionCommandHandler(IPromotionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Promotion> Handle(UpdatePromotionCommand command, CancellationToken cancellationToken)
        {
            command.LastModifiedDate = DateTime.Now;
            var map = _mapper.Map<Promotion>(command);
            var check = await _repository.UpdatePromotion(map, cancellationToken);
            if (check >= 0) return map;
            throw new Exception("Nothing change");
        }
    }
}
