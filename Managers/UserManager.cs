using Funix.HannahAssistant.Api.Common;
using Funix.HannahAssistant.Api.Entities;
using Funix.HannahAssistant.Api.IManagers;
using Funix.HannahAssistant.Api.IRepository;
using Funix.HannahAssistant.Api.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Funix.HannahAssistant.Api.Managers
{
    public class UserManager : IUserManager
    {
        private IConfiguration Configuration { get; set; }
        private IUnitOfWork UnitOfWork { get; set; }
        private IUserRepository UserRepository { get; set; }
        private IHannahRepository HannahRepository { get; set; }
        public UserManager(IUserRepository userRepository, 
            IUnitOfWork unitOfWork,
            IHannahRepository hannahRepository,
            IConfiguration configuration) 
        {
            UserRepository = userRepository;
            UnitOfWork = unitOfWork;
            HannahRepository = hannahRepository;
            Configuration = configuration;
        }

        public async Task<ApiStatusModel<AuthModel>> Auth(string UserName, string Password)
        {
            if (string.IsNullOrEmpty(UserName) && string.IsNullOrEmpty(Password))
                return new ApiStatusModel<AuthModel>() { 
                    ReturnData = null, ApiMessage = "Vui lòng nhập Tên đăng nhập hoặc Mật khẩu.", ApiStatusCode = ApiStatusCode.Warning
                };

            var user = await UserRepository.Auth(UserName, Password.ToSHA512HashString());
            if (user != null)
            {
                user.LoginDate = DateTime.UtcNow;
                //Update
                UserRepository.Update(user);
                //Commit
                await UnitOfWork.CommitAsync();
                var userProfile = await UserRepository.Get(UserName);
                if (userProfile != null)
                {
                    string UserToken = GetUserToken(userProfile.UserId, userProfile.UserName);
                    return new ApiStatusModel<AuthModel>()
                    {
                        ReturnData = new AuthModel() { Token = UserToken, User = userProfile },
                        ApiMessage = "Xác thực người dùng thành công.",
                        ApiStatusCode = ApiStatusCode.OK
                    };
                }
                return new ApiStatusModel<AuthModel>() { ReturnData = null, ApiStatusCode = ApiStatusCode.Warning, ApiMessage = "Không tìm thấy người dùng." };
            }
            return new ApiStatusModel<AuthModel>() { ReturnData = null, ApiMessage = "Tài khoản hoặc mật khẩu không chính xác. Vui lòng thử lại sau.", ApiStatusCode = ApiStatusCode.Warning };
        }

        private string GetUserToken(Guid UserId, string UserName)
        {
            var issuer = Configuration["Jwt:Issuer"];
            var audience = Configuration["Jwt:Audience"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]));
            var claims = new[] {
                new Claim("UserId", UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, UserName),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer, audience, claims, expires: DateTime.UtcNow.AddDays(7), signingCredentials: signIn);
            return new JwtSecurityTokenHandler().WriteToken(token);
            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Subject = new ClaimsIdentity(new[]
            //    {
            //    new Claim("Id", UserId.ToString()),
            //    new Claim(JwtRegisteredClaimNames.Sub, UserName),
            //    new Claim(JwtRegisteredClaimNames.Email, UserName),
            //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            // }),
            //    Expires = DateTime.UtcNow.AddDays(7),
            //    Issuer = issuer,
            //    Audience = audience,
            //    SigningCredentials = new SigningCredentials (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            //};
            //var tokenHandler = new JwtSecurityTokenHandler();
            //var token = tokenHandler.CreateToken(tokenDescriptor);
            //var jwtToken = tokenHandler.WriteToken(token);
            //var stringToken = tokenHandler.WriteToken(token);
            //return stringToken;
        }

        public async Task<ApiStatusModel<List<User>>> GetAll()
        {
            var users = await UserRepository.GetAll();
            if (users != null && users.Count > 0)
            {
                return new ApiStatusModel<List<User>>()
                {
                    ReturnData = users,
                    ApiMessage = $"Lấy danh sách người dùng thành công. Tổng cộng {users.Count()}",
                    ApiStatusCode = ApiStatusCode.OK
                };
            }
            return new ApiStatusModel<List<User>>() {
                ReturnData = null,
                ApiMessage = "Không tìm thấy dữ liệu.",
                ApiStatusCode = ApiStatusCode.Empty
            };
        }

        public async Task<ApiStatusModel<User>> GetById(Guid UserId)
        {
            var user = await UserRepository.Get(UserId);
            if (user != null)
            {
                return new ApiStatusModel<User>() { 
                    ReturnData = user,
                    ApiMessage = "Tìm kiếm người dùng thành công.",
                    ApiStatusCode = ApiStatusCode.OK
                };
            }
            return new ApiStatusModel<User>() {
                ReturnData = null,
                ApiStatusCode = ApiStatusCode.Empty,
                ApiMessage = "Không tìm thấy người dùng."
            };
        }

        public async Task<ApiStatusModel<bool>> Delete(List<Guid> Ids)
        {
            var users = await UserRepository.Get(Ids);
            if (users != null)
            {
                users.ForEach(x => x.IsDeleted = true);
                UserRepository.Update(users);
                await UnitOfWork.CommitAsync();
            }
            return new ApiStatusModel<bool>() { 
                ReturnData = true,
                ApiStatusCode = ApiStatusCode.OK,
                ApiMessage = "Xóa người dùng thành công."
            };
        }

        public async Task<ApiStatusModel<List<User>>> GetUserNotAssign()
        {
            var userAssign = await HannahRepository.GetUserId();
            if (userAssign != null && userAssign.Count > 0)
            {
                var userNotYetAssign = await UserRepository.GetUserNotAssign(userAssign);
                return new ApiStatusModel<List<User>>() { 
                    ReturnData = userNotYetAssign,
                    ApiStatusCode = ApiStatusCode.OK,
                    ApiMessage = "Tìm kiếm danh sách người dùng chưa được gán Hannah thành công."
                };
            }
            var users = await UserRepository.GetAll();
            return new ApiStatusModel<List<User>>()
            {
                ReturnData = users,
                ApiStatusCode = ApiStatusCode.OK,
                ApiMessage = "Không tìm thấy bất kỳ người dùng nào."
            };
        }

        public async Task<ApiStatusModel<bool>> AddEdit(UserModel model)
        {
            if (model.UserId.Equals(Guid.Empty))
            {
                var entity = new User()
                {
                    UserId = Guid.NewGuid(),
                    UserName = model.UserName,
                    Password = model.Password.ToSHA512HashString(),
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    IsDeleted = false,
                    LoginDate = DateTime.UtcNow,
                    FunixEmail = model.FunixEmail,
                    FunixId = model.FunixId,
                    Hannah = null
                };
                //Add
                await UserRepository.Add(entity);
            }
            else
            {
                var entity = await UserRepository.Get(model.UserId);
                if (entity != null)
                {
                    entity.FunixEmail = model.FunixEmail;
                    entity.FunixId = model.FunixId;
                    entity.UpdatedDate = DateTime.UtcNow;
                    entity.Password = model.Password.ToSHA512HashString();
                    //Update
                    UserRepository.Update(entity);
                }
                else
                {
                    return new ApiStatusModel<bool>()
                    {
                        ReturnData = false,
                        ApiStatusCode = ApiStatusCode.Empty,
                        ApiMessage = "Không tìm thấy người dùng."
                    };
                }
            }
            //Commit
            await UnitOfWork.CommitAsync();
            return new ApiStatusModel<bool>()
            {
                ReturnData = true,
                ApiStatusCode = ApiStatusCode.OK,
                ApiMessage = model.UserId.Equals(Guid.Empty) ? "Thêm người dùng thành công." : "Chỉnh sửa người dùng thất bại."
            };
        }
    }
}
