using AutoMapper;
using CleanArchitecture.Application.DTOS;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }
        public async Task CreateAsync(ProductDTO productDTO)
        {
            var entity = _mapper.Map<Product>(productDTO);

            await _productRepository.CreateAsync(entity);
        }

        public async Task<ProductDTO> GetByIdAsync(int? id)
        {
            var data = await _productRepository.GetByIdAsync(id);

            return _mapper.Map<ProductDTO>(data);
        }

        public async Task<ProductDTO> GetProductCategorie(int? id)
        {
            var entity = await _productRepository.GetProductCategoryAsync(id);

            return _mapper.Map<ProductDTO>(entity);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            var data = await _productRepository.GetProductsAsync();

            return _mapper.Map<IEnumerable<ProductDTO>>(data);
        }

        public async Task RemoveAsync(int? id)
        {
            var entity = await _productRepository.GetByIdAsync(id);
            await _productRepository.RemoveAsync(entity);
        }

        public async Task UpdateAsync(ProductDTO productDTO)
        {
            var entity = _mapper.Map<Product>(productDTO);

            await _productRepository.UpdateAsync(entity);
        }
    }
}
