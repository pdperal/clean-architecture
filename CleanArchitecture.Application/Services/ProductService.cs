using AutoMapper;
using CleanArchitecture.Application.DTOS;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Products.Commands;
using CleanArchitecture.Application.Products.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProductService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task CreateAsync(ProductDTO productDTO)
        {
            var entity = _mapper.Map<ProductCreateCommand>(productDTO);

            await _mediator.Send(entity);
        }

        public async Task<ProductDTO> GetByIdAsync(int? id)
        {
            var data = await _mediator.Send(new GetProductByIdQuery(id.Value));

            return _mapper.Map<ProductDTO>(data);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            var data = await _mediator.Send(new GetProductsQuery());

            return _mapper.Map<IEnumerable<ProductDTO>>(data);
        }

        public async Task RemoveAsync(int? id)
        {
            var entity = await _mediator.Send(new GetProductByIdQuery(id.Value));

            await _mediator.Send(new ProductRemoveCommand(entity.Id));
        }

        public async Task UpdateAsync(ProductDTO productDTO)
        {
            var entity = _mapper.Map<ProductUpdateCommand>(productDTO);

            await _mediator.Send(entity);
        }
    }
}
