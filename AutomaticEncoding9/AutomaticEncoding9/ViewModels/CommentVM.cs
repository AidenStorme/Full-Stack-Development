namespace AutomaticEncoding9.ViewModels
{
    public class CommentPageVM
    {
        public CommentVM NewComment { get; set; }
        public List<CommentVM> Comments { get; set; }
    }


    public class CommentVM
    {
        public String Name { get; set; }
        public String Message { get; set; }
    }
}
