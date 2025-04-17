namespace auth_api.Model
{
    public interface IUserRepository
    {
        void Add(User user);
        List<User> Get();

    }
}
