using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facebook;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace C14_Ex03_Shirly_304816499_Oreyan_201435484
{
   public abstract class FeedSorter
   {
        public User LoggedInUser { get; set; }

        public List<string> FetchNewsFeed()
        {
            List<string> list = new List<string>();
            foreach (Post post in LoggedInUser.NewsFeed)
            {
                list.Add(SortFeedOnRequest(post));
            }

            return list;
        }

        public abstract string SortFeedOnRequest(Post i_Post);
    }
}
