using AutoMapper;
using JustBlog.Common.Constraints;
using JustBlog.Infrastructure.Infrastructures;
using JustBlog.Model.Entities;
using JustBlog.ViewModel.BaseEntity;
using JustBlog.ViewModel.Posts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JustBlog.Application.Services.PostServices
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PostService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public bool Create(CreatePostVm createPostVm)
        {
            var postTagMaps = new List<PostTagMap>();
            // cần phải có tag => add tag.
            if (!string.IsNullOrEmpty(createPostVm.Tags))
            {
                var tagIds = _unitOfWork.TagRepository.AddTagByString(createPostVm.Tags);

                foreach (var tagId in tagIds)
                {
                    var postTagMap = new PostTagMap()
                    {
                        TagId = tagId
                    };
                    postTagMaps.Add(postTagMap);
                }
            }
            // tạo PostTagMaps
            var post = new Post()
            {
                Title = createPostVm.Title,
                CategoryId = createPostVm.CategoryId,
                ShortDescription = createPostVm.ShortDescription,
                PostContent = createPostVm.PostContent,
                UrlSlug = createPostVm.UrlSlug,
                PostTagMaps = postTagMaps,
                RateCount = 1
             
            };
            _unitOfWork.PostRepository.Add(post);
            return _unitOfWork.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            _unitOfWork.PostRepository.Delete(id, true);
            return _unitOfWork.SaveChanges() > 0;
        }

        public UpdatePostVm FinByIdUpdate(int id)
        {
            var post = _unitOfWork.PostRepository.GetById(id);
            return _mapper.Map<UpdatePostVm>(post);
        }

        public IEnumerable<PostViewModel> FindByCategoryId(int categoryId, bool isDeleted = false)
        {
            var posts = _unitOfWork.PostRepository.Find(x => x.CategoryId.Equals(categoryId), isDeleted);
            return _mapper.Map<IEnumerable<PostViewModel>>(posts);
        }

        public IEnumerable<PostViewModel> FindByDateAndUrlSlug(int year, int month, string urlSlug, bool isDeleted = false)
        {
            var posts = _unitOfWork.PostRepository.Find(x => x.CreatedOn.Month.Equals(month) && x.CreatedOn.Year.Equals(year) && x.UrlSlug.Equals(urlSlug), isDeleted);
            return _mapper.Map<IEnumerable<PostViewModel>>(posts);
        }

        public PostViewModel FindById(int id)
        {
            var post = _unitOfWork.PostRepository.GetById(id);
            return _mapper.Map<PostViewModel>(post);
        }

        public IEnumerable<PostViewModel> FindByTagId(int id)
        {
            var postTags = _unitOfWork.JustBlogDbContext.PostTagMaps.Where(pt => pt.TagId == id);
            var postIds = postTags.Select(x => x.PostId).ToList();
            var posts = _unitOfWork.PostRepository.GetById(postIds.ToArray());

            return _mapper.Map<IEnumerable<PostViewModel>>(posts);
        }

        public IEnumerable<PostViewModel> GetAll(bool isDeleted = false)
        {
            var posts = _unitOfWork.PostRepository.GetAll(isDeleted);
            return _mapper.Map<IEnumerable<PostViewModel>>(posts);
        }

        public PagingVm<PostViewModel> GetPaging(Func<Post, bool> filter, string searchBy = Searching.CreatedOn, bool isDeleted = true, int pageSize = 10, int pageIndex = 1, string typeOfSoft = Sorting.ASC)
        {
            Func<IEnumerable<Post>, IOrderedEnumerable<Post>> order = x => x.OrderByDescending(x => x.CreatedOn);

            if (typeOfSoft == Sorting.ASC)
            {
                switch (searchBy)
                {
                    case Searching.CreatedOn:
                        order = x => x.OrderByDescending(x => x.CreatedOn);
                        break;

                    case Searching.Title:
                        order = x => x.OrderBy(x => x.Title);
                        break;

                    case Searching.Content:
                        order = x => x.OrderBy(x => x.PostContent);
                        break;
                }
            }
            else
            {
                switch (searchBy)
                {
                    case Searching.CreatedOn:
                        order = x => x.OrderBy(x => x.CreatedOn);
                        break;

                    case Searching.Title:
                        order = x => x.OrderByDescending(x => x.Title);
                        break;

                    case Searching.Content:
                        order = x => x.OrderByDescending(x => x.PostContent);
                        break;
                }
            }

            var posts = _unitOfWork.PostRepository
                      .GetPaging(filter: filter, orderBy: order, isDeleted: isDeleted, pageSize: pageSize, pageIndex: pageIndex);

            var postVms = _mapper.Map<IEnumerable<PostViewModel>>(posts.Data);

            return new PagingVm<PostViewModel>(postVms, pageIndex, pageSize, posts.TotalPage);
        }

        public IEnumerable<PostViewModel> GetTopFiveLatestPosts(bool isDeleted = false)
        {
            int top = 5;
            var posts = _unitOfWork.PostRepository.GetTopLatestPosts(top, isDeleted);
            return _mapper.Map<IEnumerable<PostViewModel>>(posts);
        }

        public IEnumerable<PostViewModel> GetTopFiveMostView(bool isDeleted = false)
        {
            int top = 5;
            var posts = _unitOfWork.PostRepository.GetTopMostViews(top, isDeleted);
            return _mapper.Map<IEnumerable<PostViewModel>>(posts);
        }

        public bool Update(UpdatePostVm updatePostVm)
        {
            //delete PostTagMap references Post
            var postTags = _unitOfWork.JustBlogDbContext
                                   .PostTagMaps.Where(pt => pt.PostId == updatePostVm.Id);
            _unitOfWork.JustBlogDbContext.PostTagMaps.RemoveRange(postTags);
            _unitOfWork.SaveChanges();

            // get existing post
            var postExisting = _unitOfWork.PostRepository.GetById(updatePostVm.Id);

            //create new PostTagMaps
            var postTagMaps = new List<PostTagMap>();
            var tagIds = _unitOfWork.TagRepository.AddTagByString(updatePostVm.Tags);
            foreach (var tagId in tagIds)
            {
                var postTagMap = new PostTagMap()
                {
                    TagId = tagId
                };
                postTagMaps.Add(postTagMap);
            }

            postExisting.PostTagMaps = postTagMaps;
            postExisting.Title = updatePostVm.Title;
            postExisting.UrlSlug = updatePostVm.UrlSlug;
            postExisting.PostContent = updatePostVm.PostContent;
            postExisting.ShortDescription = updatePostVm.ShortDescription;
            _unitOfWork.PostRepository.Update(postExisting);
            return _unitOfWork.SaveChanges() > 0;
        }

        public bool UpdateIsDeleted(int id)
        {
            var post = _unitOfWork.PostRepository.GetById(id);
            if (post.IsDeleted)
                post.IsDeleted = false;
            else
                post.IsDeleted = true;
            _unitOfWork.PostRepository.Update(post);

            return _unitOfWork.SaveChanges() > 0;
        }
    }
}