using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportSvc.Domain.Entities;
using SportSvc.Application.Contracts;
using AutoMapper;
using SportSvc.Application.DTO;
using System.Text.Json.Serialization;

namespace SportSvc.Application.Commands.ProductsC
{
    public class CreateProductCommand : IRequest<Product>
    {
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
        public string? PhoneNumber { get; set; } //stadium
        public string? Address { get; set; } //stadium
        [JsonIgnore]
        public string? CreatedBy { get; set; }
        [JsonIgnore]
        public string? LastModifiedBy { get; set; }

    }
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public CreateProductCommandHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Product> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var map = _mapper.Map<Product>(command);
            map.Id = Guid.NewGuid().ToString();
            map.CreatedDate = DateTime.Now;
            map.LastModifiedDate = DateTime.Now;
            map.NumberSold = 0;
            var check = await _repository.CreateProduct(map, cancellationToken);
            if (check >= 0) return map;
            throw new Exception("Faild");
        }
    }
}