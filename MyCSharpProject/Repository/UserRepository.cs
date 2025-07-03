using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using MyCSharpProject.Model;

namespace MyCSharpProject.Repository;

public class UserRepository : IUserRepository
{
    private readonly IDistributedCache _cache;
    private readonly DistributedCacheEntryOptions _options;
    private readonly string _keyname = "User";

    public UserRepository(IDistributedCache distributedCache)
    {
        _cache = distributedCache;
        _options = new DistributedCacheEntryOptions()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(15)
        };
    }

    //TODO: Fix this shit
    public async Task<List<User>> GetUsers()
    {
        string key = $"{_keyname}:*";
        var serializedData = await _cache.GetStringAsync(key);
        try
        {
            var data = JsonSerializer.Deserialize<List<User>>(serializedData);
            return data;
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<User> GetUser(Guid userId)
    {
        string key = $"{_keyname}:{userId}";
        string serializeData = await _cache.GetStringAsync(key);
        if (serializeData == null) return null;
        var user = JsonSerializer.Deserialize<User>(serializeData);
        return user;
    }

    public async Task<Guid> AddUser(User user)
    {
        string key = $"{_keyname}:{user.UserId.ToString()}";
        var serializedData = JsonSerializer.Serialize(user);
        await _cache.SetStringAsync(key, serializedData, _options);
        return user.UserId;
    }

    public async Task<Guid> UpdateUser(User user)
    {
        string key = $"{_keyname}:{user.UserId}";
        var value = await _cache.GetStringAsync(key);
        if (string.IsNullOrEmpty(value)) return Guid.Empty;
        await _cache.SetStringAsync(key, JsonSerializer.Serialize(user));
        return user.UserId;
    }

    public async Task<Guid> DeleteUser(Guid id)
    {
        string key = $"{_keyname}:{id}";
        var value = await _cache.GetStringAsync(key);
        if(string.IsNullOrEmpty(value)) return Guid.Empty;
        await _cache.RemoveAsync(key);
        return id;
    }
}