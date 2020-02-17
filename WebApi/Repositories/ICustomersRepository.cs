using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repositories
{
    public interface ICustomersRepository
    {
        bool CheckLogin(string email, string password);
        bool ChangePassword(string email,string newPassword);
        bool ForgotPassword(string email);
        Customer GetCustomer(int Id);
        bool CreateCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
    }
}
