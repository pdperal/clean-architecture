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
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }
        public async Task CreateAsync(CategoryDTO categoryDTO)
        {
            var entity = _mapper.Map<Category>(categoryDTO);

            await _categoryRepository.CreateAsync(entity);
        }

        public async Task<CategoryDTO> GetByIdAsync(int? id)
        {
            var data = await _categoryRepository.GetByIdAsync(id);

            return _mapper.Map<CategoryDTO>(data);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
        {
            var data = await _categoryRepository.GetCategoriesAsync();

            return _mapper.Map<IEnumerable<CategoryDTO>>(data);
        }

        public async Task RemoveAsync(int? id)
        {
            var entity = await _categoryRepository.GetByIdAsync(id);
            await _categoryRepository.RemoveAsync(entity);
        }

        public async Task UpdateAsync(CategoryDTO categoryDTO)
        {
            var entity = _mapper.Map<Category>(categoryDTO);
            
            await _categoryRepository.UpdateAsync(entity);
        }
    }
}
