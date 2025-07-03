using MyCSharpProject.Model;

namespace MyCSharpProject.Repository;

public interface IUserRepository
{
    public Task<List<User>> GetUsers();
    public Task<User> GetUser(Guid userId);
    public Task<Guid> AddUser(User user);
    public Task<Guid> UpdateUser(User user);
    public Task<Guid> DeleteUser(Guid id);
}