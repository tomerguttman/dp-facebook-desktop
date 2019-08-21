using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace C19_Ex01_Ohad_305070831_Tomer_204381487
{
    public sealed class TenBestFriendsAlgorithm
    {
        private static TenBestFriendsAlgorithm s_Instance = null;
        private static object s_LockObj = new object();

        private TenBestFriendsAlgorithm() { }

        public static TenBestFriendsAlgorithm Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    lock (s_LockObj)
                    {
                        if (s_Instance == null)
                        {
                            s_Instance = new TenBestFriendsAlgorithm();
                        }
                    }
                }

                return s_Instance;
            }
        }

        public  List<UserRating> BestFriendsAlgorithm(User i_LoggedInUser)
        {
            Dictionary<string, UserRating> friendsRatingDictionary = initializeUserRatingDictionary(i_LoggedInUser);
            calculateFriendsRatingAndUpdate(friendsRatingDictionary, i_LoggedInUser);
            List<UserRating> usersRatingSortedList = convertDictionaryToList(friendsRatingDictionary);
            usersRatingSortedList.Sort((t1, t2) => t1.Rating.CompareTo(t2.Rating));
            usersRatingSortedList.Reverse();

            return usersRatingSortedList;
        }

        private  List<UserRating> convertDictionaryToList(Dictionary<string, UserRating> i_FriendsRatingDictionary)
        {
            List<UserRating> o_UsersRatingSortedList = new List<UserRating>();
            o_UsersRatingSortedList.Capacity = i_FriendsRatingDictionary.Count;

            foreach (KeyValuePair<string, UserRating> userRating in i_FriendsRatingDictionary)
            {
                o_UsersRatingSortedList.Add(userRating.Value);
            }

            return o_UsersRatingSortedList;
        }

        private  void calculateFriendsRatingAndUpdate(Dictionary<string, UserRating> i_FriendsRatingDictionary, User i_LoggedInUser)
        {
            updateFriendsRatingUsingLikes(i_FriendsRatingDictionary, i_LoggedInUser);
            updateFriendsRatingUsingComments(i_FriendsRatingDictionary, i_LoggedInUser);
        }

        private  void updateFriendsRatingUsingLikes(Dictionary<string, UserRating> io_FriendsRatingDictionary, User i_LoggedInUser)
        {
            updateUserRatingLikedPosts(io_FriendsRatingDictionary, i_LoggedInUser.WallPosts, i_LoggedInUser);
            updateUserRatingLikedPosts(io_FriendsRatingDictionary, i_LoggedInUser.Posts, i_LoggedInUser);
        }

        private  void updateUserRatingLikedPosts(Dictionary<string, UserRating> io_FriendsRatingDictionary, FacebookObjectCollection<Post> i_Posts, User i_LoggedInUser)
        {
            foreach (Post post in i_Posts)
            {
                FacebookObjectCollection<User> likedByUsers = post.LikedBy;

                foreach (User user in likedByUsers)
                {
                    if (user.Id != i_LoggedInUser.Id)
                    {
                        io_FriendsRatingDictionary[user.Id].Rating += 1;
                    }
                }
            }
        }

        private  void updateFriendsRatingUsingComments(Dictionary<string, UserRating> io_FriendsRatingDictionary, User i_LoggedInUser)
        {
            updateUserRatingCommentsOnPosts(io_FriendsRatingDictionary, i_LoggedInUser.WallPosts, i_LoggedInUser);
            updateUserRatingCommentsOnPosts(io_FriendsRatingDictionary, i_LoggedInUser.Posts, i_LoggedInUser);
        }

        private  void updateUserRatingCommentsOnPosts(Dictionary<string, UserRating> io_FriendsRatingDictionary, FacebookObjectCollection<Post> i_Posts, User i_LoggedInUser)
        {
            foreach (Post post in i_Posts)
            {
                FacebookObjectCollection<Comment> commentedByUsers = post.Comments;

                foreach (Comment comment in commentedByUsers)
                {
                    if (comment.From.Id != i_LoggedInUser.Id)
                    {
                        io_FriendsRatingDictionary[comment.From.Id].Rating += 1;
                    }
                }
            }
        }

        private  Dictionary<string, UserRating> initializeUserRatingDictionary(User i_LoggedInUser)
        {
            Dictionary<string, UserRating> o_InitializedUserRatingDictionary = new Dictionary<string, UserRating>();

            foreach (User user in i_LoggedInUser.Friends)
            {
                o_InitializedUserRatingDictionary.Add(user.Id, new UserRating(user));
            }

            return o_InitializedUserRatingDictionary;
        }
    }
}