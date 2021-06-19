
using ModelsLayer;

namespace DTO
{
    public class UserDTO
    {
        public string Id { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public static implicit operator UserDTO (User user)
        {
            return new UserDTO {Id=user.Id, UserName=user.UserName, Email=user.Email, PhoneNumber=user.PhoneNumber };
        } 
        public static implicit operator User (UserDTO user)
        {
            return new User {Id=user.Id, UserName=user.UserName, Email=user.Email, PhoneNumber=user.PhoneNumber };
        }
    }
}
