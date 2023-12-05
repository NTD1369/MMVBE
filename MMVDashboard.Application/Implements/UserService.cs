

using AutoMapper;
using Dapper;
using MMVDashboard.Application.Helpers;
using MMVDashboard.Application.Interfaces;
using MMVDashboard.Data.Entities;
using MMVDashboard.Data.Repositories;
using MMVDashboard.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMVDashboard.Application.Implements
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<MUser> _UserRepository;

        private readonly IMapper _mapper;
        public UserService(IMapper mapper,IGenericRepository<MUser> UserRepository /*, IHubContext<RequestHub> hubContext*/
         )//: base(hubContext)
        {
            _UserRepository = UserRepository;
            _mapper = mapper;

        } 
    public async Task<GenericResult> Login(string userName, string passWord)
        {
            GenericResult result = new GenericResult();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@userName", userName);
                parameters.Add("@passWord", passWord);
                var data = await _UserRepository.GetAllAsync($"USP_S_USER", parameters, commandType: CommandType.StoredProcedure);
                //if (userName == "test" && passWord == "123")
                if(data == null || data.Count == 0)
                {
                    result.Success = false;
                    result.Message = "Tên tài khoản không đúng !!!";
                    return result;
                }
                result.Success = true;
                result.UserName = userName;
                result.PassWord = passWord;
                result.Data = data;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
               

            }
            return result;
        }

        public Task<GenericResult> Delete(MUser model)
        {
            throw new NotImplementedException();
        }

        public Task<GenericResult> GetAll(string CompanyCode, string StoreId, string DailyId)
        {
            throw new NotImplementedException();
        }

        public Task<GenericResult> GetByCode(string CompanyCode, string StoreId, string DailyId, string Id)
        {
            throw new NotImplementedException();
        }

        public Task<GenericResult> Update(MUser model)
        {
            throw new NotImplementedException();
        }
    }

}
