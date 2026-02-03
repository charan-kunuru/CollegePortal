using Microsoft.EntityFrameworkCore;
using EmployeeAPI.Data;
using EmployeeAPI.Models;

namespace EmployeeAPI.Repositories.Interface;
public interface IStudentRepository
{
    Task AddASync(Student student);
}
