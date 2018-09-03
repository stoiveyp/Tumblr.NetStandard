namespace Tumblr.NetStandard.Models
{
    public class Note<T> : Note where T:new()
    {
        public Note()
        {
            Extra = new T();
        }

        public T Extra { get; set; }
    }

    public class Note
    {
        public Note()
        {
            Common = new CommonNoteData();
        }

        public CommonNoteData Common { get; set; }
    }
}
