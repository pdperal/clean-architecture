using CleanArchitecture.Application.DTOS;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProductsAsync();
        Task<ProductDTO> GetByIdAsync(int? id);
        Task<ProductDTO> GetProductCategorie(int? id);
        Task CreateAsync(ProductDTO productDTO);
        Task UpdateAsync(ProductDTO productDTO);
        Task RemoveAsync(int? id);
    }
}
