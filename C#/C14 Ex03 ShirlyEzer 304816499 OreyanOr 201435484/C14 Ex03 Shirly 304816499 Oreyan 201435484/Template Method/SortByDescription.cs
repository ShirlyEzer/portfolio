using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facebook;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace C14_Ex03_Shirly_304816499_Oreyan_201435484
{
    public class SortByDescription : FeedSorter
    {
        public override string SortFeedOnRequest(Post i_Post)
        {
            return i_Post.Description;
        }
    }
}
