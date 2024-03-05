//using AutoMapper;
//using MediatR;
//using SportSvc.Application.Contracts;
//using SportSvc.Domain.Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SportSvc.Application.Queries.StadiumNam
//{
//    public class GetAllStadiumQuery : IRequest<List<Product>>
//    {

//    }
//    public class GetAllStadiumQueryHandler : IRequestHandler<GetAllStadiumQuery, List<Product>>
//    {
//        private readonly IStadiumRepository _stadiumRepository;
//        private readonly IMapper _mapper;
//        public GetAllStadiumQueryHandler(IStadiumRepository stadiumRepository, IMapper mapper)
//        {
//            _stadiumRepository = stadiumRepository;
//            _mapper = mapper;
//        }
//        public async Task<List<Product>> Handle(GetAllStadiumQuery query, CancellationToken cancellationToken)
//        {
//            return await _stadiumRepository.GetAllStadium(cancellationToken);
//        }
//    }
//}
using AutoMapper;
using Jhipster.Service.Utilities;
using MediatR;
using SportSvc.Application.Commands.ProductsC;
using SportSvc.Application.Contracts;
using SportSvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSvc.Application.Queries.Products
{
    public class GetAllStadiumQuery : IRequest<PagedList<Product>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllStadiumQueryHandler : IRequestHandler<GetAllStadiumQuery, PagedList<Product>>
    {
        private readonly IStadiumRepository _repository;
        private readonly IMapper _mapper;
        public GetAllStadiumQueryHandler(IStadiumRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PagedList<Product>> Handle(GetAllStadiumQuery rq, CancellationToken cancellationToken)
        {
            return await _repository.GetAllStadium(rq.Page, rq.PageSize, cancellationToken);
        }
    }


}