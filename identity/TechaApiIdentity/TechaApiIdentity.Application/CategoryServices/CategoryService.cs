using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechaApiIdentity.Base;
using TechaApiIdentity.Data;
using TechaApiIdentity.EF;

namespace TechaApiIdentity.Application
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationUserDbContext context;
        private readonly IMapper mapper;

        public CategoryService(ApplicationUserDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }


        public async Task<ApplicationResult> Create(CreateCategoryDto input, ApplicationUser applicationUser)
        {
            try
            {
                Category mapCat = mapper.Map<Category>(input);
                mapCat.CreatedById = applicationUser.Id;
                mapCat.CreatedBy = applicationUser.UserName;
                mapCat.CreatedDate = DateTime.UtcNow;

                context.Categories.Add(mapCat);
                await context.SaveChangesAsync();

                return new ApplicationResult { Succeeded = true };
            }
            catch (Exception ex)
            {
                return new ApplicationResult { Succeeded = false, ErrorMessage = ex.Message };
            }
        }

        public async Task<ApplicationResult> Delete(int Id, ApplicationUser applicationUser)
        {
            try
            {
                Category willDelete = await context.Categories.FindAsync(Id);
                if (willDelete != null)
                {
                    context.Categories.Remove(willDelete);
                    await context.SaveChangesAsync();

                    return new ApplicationResult { Succeeded = true };
                }
                else
                {
                    return new ApplicationResult { Succeeded = false, ErrorMessage = "Record not found. Try Again." };

                }
            }
            catch (Exception ex)
            {
                return new ApplicationResult { Succeeded = false, ErrorMessage = ex.Message };
            }
        }

        public async Task<ApplicationResult<CategoryDto>> Get(int Id, ApplicationUser applicationUser)
        {
            try
            {
                Category category = await context.Categories.FindAsync(Id);
                CategoryDto dto = mapper.Map<Category, CategoryDto>(category);
                return new ApplicationResult<CategoryDto>
                {
                    Result = dto,
                    Succeeded = true
                };
            }
            catch (Exception ex)
            {
                return new ApplicationResult<CategoryDto> { Succeeded = false, ErrorMessage = ex.Message };
            }

        }

        public async Task<ApplicationResult<List<CategoryDto>>> GetAll(ApplicationUser applicationUser)
        {
            try
            {
                List<Category> result = await context.Categories.ToListAsync();
                List<CategoryDto> mapResult = mapper.Map<List<Category>, List<CategoryDto>>(result);

                return new ApplicationResult<List<CategoryDto>>
                {
                    Result = mapResult,
                    Succeeded = true
                };

            }
            catch (Exception ex)
            {
                return new ApplicationResult<List<CategoryDto>> { Succeeded = false, ErrorMessage = ex.Message };
            }
        }

        public async Task<ApplicationResult> Update(UpdateCategoryDto input, ApplicationUser applicationUser)
        {
            try
            {
                Category getExistCategory = await context.Categories.FindAsync(input.Id);
                getExistCategory.Name = input.Name;
                getExistCategory.UrlName = input.UrlName;
                getExistCategory.ModifiedBy = applicationUser.UserName;
                getExistCategory.ModifiedById = applicationUser.Id;
                getExistCategory.ModifiedDate = DateTime.UtcNow;

                context.Update(getExistCategory);
                await context.SaveChangesAsync();

                return new ApplicationResult
                {
                    Succeeded = true,
                };
            }
            catch (Exception ex)
            {
                return new ApplicationResult { Succeeded = false, ErrorMessage = ex.Message };
            }

        }

    }
}
