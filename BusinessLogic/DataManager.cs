using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;

namespace BusinessLogic
{
    // Класс, через который централизованно происходит обен данными в приложении 
    public class DataManager
    {
        private IUsersRepository usersRepository;
        private IFriendsRepository friendsRepository;
        private IFriendRequestsRepository friendRequestsRepository;
        private PrimaryMembershipProvider provider;

        public DataManager(IUsersRepository usersRepository, IFriendsRepository friendsRepository,
            IFriendRequestsRepository friendRequestsRepository, PrimaryMembershipProvider provider)
        {
            this.usersRepository = usersRepository;
            this.friendsRepository = friendsRepository;
            this.friendRequestsRepository = friendRequestsRepository;
            this.provider = provider;
        }

        public IUsersRepository Persons { get { return usersRepository; } }
        public IFriendsRepository Friends { get { return friendsRepository; } }
        public IFriendRequestsRepository FriendRequests { get { return friendRequestsRepository; } }
        public PrimaryMembershipProvider MembershipProvider { get { return provider; } }
    }
}
