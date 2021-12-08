using AutoMapper;
using JustBlog.Infrastructure.Infrastructures;
using JustBlog.Model.Entities;
using JustBlog.ViewModel.Comments;
using System.Collections.Generic;
using System.Linq;

namespace JustBlog.Application.Services.Comments
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public bool Create(CreateCommentVm commentVm)
        {
            var comment = _mapper.Map<Comment>(commentVm);
            _unitOfWork.CommentRepository.Add(comment);
            return _unitOfWork.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            _unitOfWork.CommentRepository.Delete(id, true);
            return _unitOfWork.SaveChanges() > 0;
        }

        public CommentVm FindById(int id)
        {
            var comment = _unitOfWork.CommentRepository.GetById(id);
            return _mapper.Map<CommentVm>(comment);
        }

        public IEnumerable<CommentVm> GetAll()
        {
            var comments = _unitOfWork.CommentRepository.GetAll();
            return _mapper.Map<IEnumerable<CommentVm>>(comments);
        }

        public IEnumerable<CommentVm> GetByPostId(int postId)
        {
            var comments = _unitOfWork.CommentRepository.GetAll().Where(x => x.PostId == postId);
            return _mapper.Map<IEnumerable<CommentVm>>(comments);
        }

        public bool Update(UpdateCommentVm commentVm)
        {
            var commentExist = _unitOfWork.CommentRepository.GetById(commentVm.Id);
            if (commentExist != null)
            {
                commentExist.Name = commentVm.Name;
                commentExist.CommentText = commentVm.CommentText;
                commentExist.PostId = commentVm.PostId;

                _unitOfWork.CommentRepository.Update(commentExist);
            }
            return _unitOfWork.SaveChanges() > 0;
        }
    }
}