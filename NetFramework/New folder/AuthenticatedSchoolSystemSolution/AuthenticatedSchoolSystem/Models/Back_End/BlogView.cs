using System.Collections.Generic;

namespace AuthenticatedSchoolSystem.Models.Back_End
{
    public class BlogView
    {
        public BlogView()
        {
            MyPost = new Post();
            posts = new List<Post>();
        }

        public Post MyPost { get; set; }
        public List<Post> posts { get; set; }
    }
}