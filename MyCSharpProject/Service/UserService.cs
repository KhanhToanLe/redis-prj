using MyCSharpProject.Model;
using MyCSharpProject.Repository;

namespace MyCSharpProject.Service;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<List<User>> GetUsers()
    {
        return await _userRepository.GetUsers();
    }

    public async Task<User> GetUser(Guid userId)
    {
        return await _userRepository.GetUser(userId);
    }

    public async Task<Guid> AddUser(User user)
    {
        return await _userRepository.AddUser(user);
    }

    public async Task<Guid> UpdateUser(User user)
    {
        return await _userRepository.UpdateUser(user);
    }

    public async Task<Guid> DeleteUser(Guid id)
    {
        return await _userRepository.DeleteUser(id);
    }
}