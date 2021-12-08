namespace JustBlog.ViewModel.Comments
{
    public class UpdateCommentVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CommentText { get; set; }

        public int PostId { get; set; }
    }
}