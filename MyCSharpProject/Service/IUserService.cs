using MyCSharpProject.Model;

namespace MyCSharpProject.Service;

public interface IUserService
{
    public Task<List<User>> GetUsers();
    public Task<User> GetUser(Guid userId);
    public Task<Guid> AddUser(User user);
    public Task<Guid> UpdateUser(User user);
    public Task<Guid> DeleteUser(Guid id);
}