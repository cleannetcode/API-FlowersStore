using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using API_FlowersStore.Core.CoreModels;
using API_FlowersStore.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API_FlowersStore.DataAccess.MSSQL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly APIFlowersStoreDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(APIFlowersStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<User[]> GetAll()
        {
            var users = await _context.Users
                       .AsNoTracking()
                       .ToArrayAsync();

            return _mapper.Map<Entities.User[], Core.CoreModels.User[]>(users);
        }

        public async Task<User> GetById(int Id)
        {
            var user = await _context.Users
                      .Where(u => u.Id == Id)
                      .AsNoTracking()
                      .FirstOrDefaultAsync();

            return _mapper.Map<Entities.User, Core.CoreModels.User>(user);
        }

        public async Task<User> GetByNameAndPassword(string name, string password)
        {
            var user = await _context.Users
                      .Where(u => u.Name == name && u.Password == password)
                      .AsNoTracking()
                      .FirstOrDefaultAsync();

            return _mapper.Map<Entities.User, Core.CoreModels.User>(user);
        }
    }
}
