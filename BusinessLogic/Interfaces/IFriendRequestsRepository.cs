using System.Collections.Generic;
using Domain.Entities;

namespace BusinessLogic.Interfaces
{
    public interface IFriendRequestsRepository
    {
        IEnumerable<FriendRequest> GetFriendRequests();
        // Проверяем, отправил ли пользователь1 пользователю2 запросна дружбу
        bool RequestIsSent(int userFromId, int userToId);
        void AddFriendRequest(FriendRequest friendRequest);
        void DeleteFriendRequest(FriendRequest friendRequest);
    }
}
