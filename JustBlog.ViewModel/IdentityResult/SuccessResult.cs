namespace JustBlog.ViewModel.IdentityResult
{
    public class SuccessResult : IdentityCustomResult
    {
        public SuccessResult()
        {
            IsSuccessed = true;
        }
        public SuccessResult(string message)
        {
            IsSuccessed = true;
            Message = message;
        }
    }
}