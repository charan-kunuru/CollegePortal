using Microsoft.EntityFrameworkCore;
using CollegeAPI.Data;
using CollegeAPI.Modules.Students.Models;

namespace CollegeAPI.Modules.Students.Repositories.Interface;
public interface IStudentRepository
{
    Task AddASync(Student student);
}
