﻿namespace Domain.Entities
{
    public class FriendRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PossibleFriendId { get; set; }
    }
}
