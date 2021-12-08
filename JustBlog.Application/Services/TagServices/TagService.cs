using AutoMapper;
using JustBlog.Infrastructure.Infrastructures;
using JustBlog.ViewModel.Tags;
using System.Collections.Generic;

namespace JustBlog.Application.Services.TagServices
{
    public class TagService : ITagService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TagService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public TagViewModel FindById(int tagId)
        {
            var tag = _unitOfWork.TagRepository.GetById(tagId);
            return _mapper.Map<TagViewModel>(tag);
        }

        public IEnumerable<TagViewModel> FindTagsByPostId(int postId)
        {
            var tags = _unitOfWork.TagRepository.FindTagsByPostId(postId);
            return _mapper.Map<IEnumerable<TagViewModel>>(tags);
        }

        public IEnumerable<TagViewModel> GetTagAvailable()
        {
            var tags = _unitOfWork.TagRepository.GetTagAvailable();
            return _mapper.Map<IEnumerable<TagViewModel>>(tags);
        }
    }
}