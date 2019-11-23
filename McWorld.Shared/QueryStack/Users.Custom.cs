using McWorld.Shared.Dtos;

namespace McWorld.Shared.QueryStack
{
    public partial class Users
    {
        public UserDto AsDto()
        {
            return new UserDto()
            {
                UserID = UserId,
                Username = Username,
                Birthdate = Birthdate,
                Created = Created,
                Email = Email,
                Password = null,
            };
        }
    }
}
