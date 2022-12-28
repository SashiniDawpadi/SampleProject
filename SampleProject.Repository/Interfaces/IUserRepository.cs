using SampleProject.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<BaseResponse> SelectValidUser(string UserName, string NICNo);
    }
}
