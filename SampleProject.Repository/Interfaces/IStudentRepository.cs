using SampleProject.Model;
using System;
using System.Threading.Tasks;

namespace SampleProject.Repository.Interfaces
{
    public interface IStudentRepository
    {
        Task<BaseResponse> SelectById(string StudentId);

        Task<BaseResponse> SelectAllStudents();

        Task<BaseResponse> DeleteStudent(string StudentId);

    }
}
