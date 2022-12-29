using SampleProject.Model;
using System.Threading.Tasks;

namespace SampleProject.Repository.Interfaces
{
    public interface IStudentRepository
    {
        Task<BaseResponse> SelectById(string StudentId);

        Task<BaseResponse> SelectAllStudents();

    }
}
