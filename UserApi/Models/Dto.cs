namespace UserApi.Models
{
    public class Dto //data transfer obj
    {
        public record CreateUserDto(string Name,int Age,bool License);
        
        public record UpdateUserDto(string Name,int Age,bool License);

        public record DeleteUserDto(string Name, int Age, bool License);
    }
}
