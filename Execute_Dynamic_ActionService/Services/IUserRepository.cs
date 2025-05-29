namespace Execute_Dynamic_ActionService.Services
{
    public interface IUserRepository
    {
        string GetName();
        string GetFullname(Person person);
    }

    public class UserRepository : IUserRepository
    {
        public string GetFullname(Person person)
        {
            return (person.FirstName+" "+ person.LastName);
        }

        public string GetName()
        {
            return "name one two";
        }
    }
}
