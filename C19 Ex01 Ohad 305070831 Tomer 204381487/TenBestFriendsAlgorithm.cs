using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;


namespace C19_Ex01_Ohad_305070831_Tomer_204381487
{
    public static class TenBestFriendsAlgorithm
    {
        private static bool s_WasAlgorithmActivated = false;

        public static List<UserRating> BestFriendsAlgorithm(User i_LoggedInUser)
        {
            Dictionary<string, UserRating> friendsRatingDictionary = initializeUserRatingList(i_LoggedInUser);
            calculateFriendsRatingAndUpdate(friendsRatingDictionary, i_LoggedInUser);
            List<UserRating> usersRatingSortedList = convertDictionaryToList(friendsRatingDictionary);
            usersRatingSortedList.Sort((T1, T2) => T1.Rating.CompareTo(T2.Rating));
            usersRatingSortedList.Reverse();
            s_WasAlgorithmActivated = true;

            return usersRatingSortedList;
        }

        public static bool WasAlgorithmActivated
        {
            get { return s_WasAlgorithmActivated; }
        }

        private static List<UserRating> convertDictionaryToList(Dictionary<string, UserRating> i_FriendsRatingDictionary)
        {
            List<UserRating> o_UsersRatingSortedList = new List<UserRating>();
            o_UsersRatingSortedList.Capacity = i_FriendsRatingDictionary.Count;

            foreach (KeyValuePair<string, UserRating> userRating in i_FriendsRatingDictionary)
            {
                o_UsersRatingSortedList.Add(userRating.Value);
            }

            return o_UsersRatingSortedList;
        }

        private static void calculateFriendsRatingAndUpdate(Dictionary<string, UserRating> i_FriendsRatingDictionary, User i_LoggedInUser)
        {
            updateFriendsRatingUsingLikes(i_FriendsRatingDictionary, i_LoggedInUser);
            updateFriendsRatingUsingComments(i_FriendsRatingDictionary, i_LoggedInUser);
        }

        private static void updateFriendsRatingUsingLikes(Dictionary<string, UserRating> io_FriendsRatingDictionary, User i_LoggedInUser)
        {
            updateUserRatingLikedPosts(io_FriendsRatingDictionary, i_LoggedInUser.WallPosts, i_LoggedInUser);
            updateUserRatingLikedPosts(io_FriendsRatingDictionary, i_LoggedInUser.Posts, i_LoggedInUser);
        }

        private static void updateUserRatingLikedPosts(Dictionary<string, UserRating> io_FriendsRatingDictionary, FacebookObjectCollection<Post> i_Posts, User i_LoggedInUser)
        {
            foreach (Post post in i_Posts)
            {
                FacebookObjectCollection<User> LikedByUsers = post.LikedBy;

                foreach (User user in LikedByUsers)
                {
                    if (user.Id != i_LoggedInUser.Id)
                    {
                        io_FriendsRatingDictionary[user.Id].Rating += 1;
                    }
                }
            }
        }

        private static void updateFriendsRatingUsingComments(Dictionary<string, UserRating> io_FriendsRatingDictionary, User i_LoggedInUser)
        {
            updateUserRatingCommentsOnPosts(io_FriendsRatingDictionary, i_LoggedInUser.WallPosts, i_LoggedInUser);
            updateUserRatingCommentsOnPosts(io_FriendsRatingDictionary, i_LoggedInUser.Posts, i_LoggedInUser);
        }

        private static void updateUserRatingCommentsOnPosts(Dictionary<string, UserRating> io_FriendsRatingDictionary, FacebookObjectCollection<Post> i_Posts, User i_LoggedInUser)
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

        private static Dictionary<string, UserRating> initializeUserRatingList(User i_LoggedInUser)
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