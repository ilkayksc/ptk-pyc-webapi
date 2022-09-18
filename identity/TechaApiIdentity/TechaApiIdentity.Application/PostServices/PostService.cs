using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechaApiIdentity.Base;
using TechaApiIdentity.Data;
using TechaApiIdentity.EF;

namespace TechaApiIdentity.Application
{
    public class PostService : IPostService
    {
        private readonly ApplicationUserDbContext context;
        private readonly IMapper mapper;

        public PostService(ApplicationUserDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }


        public async Task<ApplicationResult<PostDto>> Get(int id, ApplicationUser applicationUser)
        {
            try
            {
                Post post = await context.Posts.Include(p => p.Category).Where(x => x.CreatedById == applicationUser.Id && x.Id == id).FirstOrDefaultAsync();
                PostDto postDto = mapper.Map<Post, PostDto>(post);
                return new ApplicationResult<PostDto>
                {
                    Succeeded = true,
                    Result = postDto
                };
            }
            catch (Exception ex)
            {
                return new ApplicationResult<PostDto> { Succeeded = false, ErrorMessage = ex.Message };
            }
        }

        public async Task<ApplicationResult<List<PostDto>>> GetAll(ApplicationUser applicationUser)
        {
            try
            {
                List<Post> listRaw = await context.Posts.Include(x => x.Category).Where(x => x.CreatedById == applicationUser.Id).ToListAsync();
                List<PostDto> list = mapper.Map<List<Post>, List<PostDto>>(listRaw);

                return new ApplicationResult<List<PostDto>>
                {
                    Succeeded = true,
                    Result = list
                };
            }
            catch (Exception e)
            {
                return new ApplicationResult<List<PostDto>> { ErrorMessage = e.Message, Succeeded = false };
            }
        }


        public async Task<ApplicationResult> Create(CreatePostDto input, ApplicationUser applicationUser)
        {
            try
            {
                Post newPost = mapper.Map<CreatePostDto, Post>(input);
                newPost.CreatedBy = applicationUser.UserName;
                newPost.CreatedById = applicationUser.Id;
                newPost.CreatedDate = DateTime.UtcNow;

                await context.Posts.AddAsync(newPost);
                await context.SaveChangesAsync();

                return new ApplicationResult { Succeeded = true };
            }
            catch (Exception ex)
            {
                return new ApplicationResult { Succeeded = false, ErrorMessage = ex.Message };
            }
        }

        public async Task<ApplicationResult> Delete(int id, ApplicationUser applicationUser)
        {
            try
            {
                Post willDeletePost = await context.Posts.FindAsync(id);
                if (willDeletePost != null)
                {
                    if (willDeletePost.CreatedById != applicationUser.Id)
                    {
                        return new ApplicationResult { Succeeded = false, ErrorMessage = "Record not found. Try Again." };
                    }

                    context.Posts.Remove(willDeletePost);
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
                return new ApplicationResult { ErrorMessage = ex.Message, Succeeded = false };
            }
        }

        public async Task<ApplicationResult> Update(UpdatePostDto input, ApplicationUser applicationUser)
        {
            try
            {
                Post getExistPost = await context.Posts.FindAsync(input.Id);
                if (getExistPost == null)
                {
                    return new ApplicationResult { Succeeded = false, ErrorMessage = "No Post Found !" };
                }

                if (getExistPost.CreatedById != applicationUser.Id)
                {
                    return new ApplicationResult { Succeeded = false, ErrorMessage = "Record not found. Try Again." };
                }

                getExistPost.ModifiedBy = applicationUser.UserName;
                getExistPost.ModifiedById = applicationUser.Id;
                getExistPost.CategoryId = input.CategoryId;
                getExistPost.Title = input.Title;
                getExistPost.Content = input.Content;
                getExistPost.UrlName = input.UrlName;
                getExistPost.ModifiedDate = DateTime.UtcNow;


                context.Update(getExistPost);
                await context.SaveChangesAsync();

                return new ApplicationResult { Succeeded = true };
            }
            catch (Exception ex)
            {
                return new ApplicationResult { Succeeded = false, ErrorMessage = ex.Message };
            }
        }

        public async Task<ApplicationResult<PostDto>> GetByUrl(string categoryUrl, string postUrl)
        {
            try
            {
                var category = await context.Categories.Where(c => c.UrlName == categoryUrl).FirstOrDefaultAsync();
                if (category != null)
                {
                    var post = await context.Posts.Where(p => p.CategoryId == category.Id && p.UrlName == postUrl).FirstOrDefaultAsync();
                    if (post != null)
                    {
                        return new ApplicationResult<PostDto>
                        {
                            Succeeded = true,
                            Result = mapper.Map<PostDto>(post)
                        };
                    }
                }
                return new ApplicationResult<PostDto> { Succeeded = false, ErrorMessage = "No Post Found!" };

            }
            catch (Exception ex)
            {
                return new ApplicationResult<PostDto> { Succeeded = false, ErrorMessage = ex.Message };
            }

        }

    }
}
