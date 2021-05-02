using CleanArchitecture.Application.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategoriesAsync();
        Task<CategoryDTO> GetByIdAsync(int? id);
        Task CreateAsync(CategoryDTO categoryDTO);
        Task UpdateAsync(CategoryDTO categoryDTO);
        Task RemoveAsync(int? id);
    }
}
