using PriceBuddy.Data.Models;

namespace PriceBuddy.Data.Repositories;

public class UserRepository
{
    private PriceBuddyDbContext _context;
    public UserRepository(PriceBuddyDbContext context)
    {
        this._context = context;
    }
    public User GetByLogin(string login, string password)
    {
        return this._context.Users.FirstOrDefault(u=> u.Login == login && u.Password == password);
    }
}
