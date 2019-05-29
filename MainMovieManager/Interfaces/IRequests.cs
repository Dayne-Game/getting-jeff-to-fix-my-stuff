using System;
using MainMovieManager.Database_Models;

namespace MainMovieManager.Interfaces
{
    public interface IRequests
    {
        string UserPutRequest(string json, User_Model u1);
        string PostWishlistItem(string json, Wishlist_Model w1);
        string RemoveWishlistItem(string json, string index, Wishlist_Model w1);
    }
}
