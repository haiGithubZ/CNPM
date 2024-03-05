using AutoMapper;
using MediatR;
using SportSvc.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSvc.Application.Commands.PromotionC
{
    public class DeletePromotionCommand : IRequest<int>
    {
        public string PromotionId { get; set; }
    }
    public class DeletePromotionCommandHandler : IRequestHandler<DeletePromotionCommand, int>
    {
        private readonly IPromotionRepository _repository;
        private readonly IMapper _mapper;
        public DeletePromotionCommandHandler(IPromotionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<int> Handle(DeletePromotionCommand command, CancellationToken cancellationToken)
        {
            return await _repository.DeletePromotion(command.PromotionId, cancellationToken);
        }
    }
}
