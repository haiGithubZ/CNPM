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

namespace SportSvc.Application.Commands.ProductsC
{
    public class UpdateProductCommand : IRequest<Product>
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public double? Price { get; set; }
        public string? SportId { get; set; }
        public string? Brand { get; set; }
        public int Quantity { get; set; }
        public int Type { get; set; } //0: Quần, 1: Áo, 2: Giày, 3: Bóng,  4: Kính bơi, 5: Sân bóng
        public List<string>? ListSize { get; set; }
        public List<string>? ListColor { get; set; }
        [JsonIgnore]
        public string? LastModifiedBy { get; set; }
        [JsonIgnore]
        public DateTime? LastModifiedDate { get; set; }
    }
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Product>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public UpdateProductCommandHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Product> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            command.LastModifiedDate = DateTime.Now;
            var map = _mapper.Map<Product>(command);
            var check = await _repository.UpdateProduct(map, cancellationToken);
            if (check >= 0) return map;
            throw new Exception("Nothing change");
        }
    }
}
