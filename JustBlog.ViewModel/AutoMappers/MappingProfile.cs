using AutoMapper;
using JustBlog.Model.Entities;
using JustBlog.ViewModel.Accounts;
using JustBlog.ViewModel.Categories;
using JustBlog.ViewModel.Comments;
using JustBlog.ViewModel.Posts;
using JustBlog.ViewModel.Tags;

namespace JustBlog.ViewModel.AutoMappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Post, PostViewModel>().ReverseMap();

            CreateMap<Post, CreatePostVm>().ReverseMap();

            CreateMap<Post, UpdatePostVm>().ReverseMap();

            CreateMap<Tag, TagViewModel>().ReverseMap();

            CreateMap<Category, CreateCategoryVm>().ReverseMap();

            CreateMap<Category, UpdateCategoryVm>().ReverseMap();

            CreateMap<Category, CategoryViewModel>().ReverseMap();

            CreateMap<Comment, CommentVm>().ReverseMap();

            CreateMap<Comment, CreateCommentVm>().ReverseMap();

            CreateMap<Comment, UpdateCommentVm>().ReverseMap();

            CreateMap<AppUser, UpdateUserVm>().ReverseMap();

            CreateMap<AppUser, UserVm>().ReverseMap();
            
            CreateMap<AppUser, CreateUserVm>().ReverseMap();
        }
    }
}