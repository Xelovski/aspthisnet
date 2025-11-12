using Common.DTO;

namespace WebApplication2.Models
{
    public class cREATEuSERModel
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public static implicit operator cREATEuSERModel(UserDTO v)
        {
            throw new NotImplementedException();
        }
    }
}
