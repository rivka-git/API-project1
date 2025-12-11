using System.Text.Json;
using Repository;
using Model;
using Model;
using AutoMapper;
using Dto;
namespace Services
{


    public class UserServices : IUserServices
    {
        IUserRepository _r;
        IMapper _mapper;
        IPasswordService _passwordService;
        public UserServices(IUserRepository i, IMapper mapperr, IPasswordService passwordService)
        {
            _r = i;
            _mapper = mapperr;
            _passwordService = passwordService;
        }
        public  async Task<IEnumerable<User>> GetUsers()
        {
            return await _r.GetUsers();
        }
        public async Task<User?> GetUserById(int id)
        {
            return await _r.GetUserById(id);
        }

        public async Task<User> AddNewUser(User user)
        {
            PassWord pp=new PassWord();
            pp.Password = user.Password;
            pp.Strength = 0;
            DtoPassword_Password_Strength d = _passwordService.getStrengthByPassword(pp);
            if (d.Strength >= 2)
            {
                return await _r.AddNewUser(user);
            }
            return null;
        }

        public async Task<User?> Login(User value)
        {
            return await _r.Login(value);
        }
        public async Task<User> update(int id, User user)
        {
            PassWord pp = new PassWord();
            pp.Password = user.Password;
            pp.Strength = 0;
            DtoPassword_Password_Strength d = _passwordService.getStrengthByPassword(pp);
            if (d.Strength >= 2)
            {
                return await _r.update(id, user);
            }
            return null;
        }
        public void Delete(int id)
        {
            _r.Delete(id);
        }

    }
}
