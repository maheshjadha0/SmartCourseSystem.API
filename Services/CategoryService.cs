using SmartCourseSystem.API.DTOs.Category;
using SmartCourseSystem.API.Models;
using SmartCourseSystem.API.Repositories.Interfaces;
using SmartCourseSystem.API.Services.Interfaces;

namespace SmartCourseSystem.API.Services
{
    public class CategoryService
   : ICategoryService
    {
        private readonly
            ICategoryRepository _repository;

        public CategoryService(
            ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CategoryResponseDto>>
            GetAllAsync()
        {
            var categories =
                await _repository.GetAllAsync();

            return categories.Select(x =>
                new CategoryResponseDto
                {
                    ID = x.ID,
                    Name = x.Name,
                  
                });
        }

        public async Task<CategoryResponseDto?>
            GetByIdAsync(int id)
        {
            var category =
                await _repository.GetByIdAsync(id);

            if (category == null)
                return null;

            return new CategoryResponseDto
            {
                ID = category.ID,
                Name = category.Name,
            };
        }

        public async Task<CategoryResponseDto>
            CreateAsync(CreateCategoryDto dto)
        {
            var category = new Category
            {
                Name = dto.Name,
            };

            await _repository.AddAsync(category);

            await _repository.SaveChangesAsync();

            return new CategoryResponseDto
            {
                ID = category.ID,
                Name = category.Name,
            };
        }

        public async Task<bool>
            UpdateAsync(
                int id,
                UpdateCategoryDto dto)
        {
            var category =
                await _repository.GetByIdAsync(id);

            if (category == null)
                return false;

            category.Name = dto.Name;

            _repository.Update(category);

            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool>
            DeleteAsync(int id)
        {
            var category =
                await _repository.GetByIdAsync(id);

            if (category == null)
                return false;

            _repository.Delete(category);

            await _repository.SaveChangesAsync();

            return true;
        }
    }
}

