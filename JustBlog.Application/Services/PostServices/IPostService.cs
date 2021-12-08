using JustBlog.Common.Constraints;
using JustBlog.Model.Entities;
using JustBlog.ViewModel.BaseEntity;
using JustBlog.ViewModel.Posts;
using System;
using System.Collections.Generic;

namespace JustBlog.Application.Services.PostServices
{
    public interface IPostService
    {
        IEnumerable<PostViewModel> GetAll(bool isDeleted = false);

        PostViewModel FindById(int id);

        UpdatePostVm FinByIdUpdate(int id);

        IEnumerable<PostViewModel> GetTopFiveMostView(bool isDeleted = false);

        IEnumerable<PostViewModel> GetTopFiveLatestPosts(bool isDeleted = false);

        IEnumerable<PostViewModel> FindByCategoryId(int categoryId, bool isDeleted = false);

        IEnumerable<PostViewModel> FindByDateAndUrlSlug(int year, int month, string urlSlug, bool isDeleted = false);

        bool Create(CreatePostVm createPostVm);

        bool Update(UpdatePostVm updatePostVm);

        bool UpdateIsDeleted(int id);

        bool Delete(int id);

        IEnumerable<PostViewModel> FindByTagId(int id);

        PagingVm<PostViewModel> GetPaging(Func<Post, bool> filter, string searchBy = Searching.CreatedOn,
           bool isDeleted = true, int pageSize = 10, int pageIndex = 1,
           string typeOfSoft = Sorting.ASC);
    }
}