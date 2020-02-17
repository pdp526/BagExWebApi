using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Linq;
using WebApi.Models;
using WebApi.Repositories.Connection;

namespace WebApi.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        public readonly IDbConnection _IConnection;

        public CustomersRepository(IConnection IConnection)
        {
            _IConnection = IConnection.GetConnection;
        }

        public bool ChangePassword(string email, string newPassword)
        {
            throw new NotImplementedException();
        }

        public bool CheckLogin(string email, string password)
        {
            var query = Constant.Constant.ProcedureNames.CheckLogin;
            DynamicParameters p = new DynamicParameters();
            p.Add("@email", email);
            p.Add("@password", password);
            var customersData = SqlMapper.Query<Customer>(_IConnection, query, param: p, commandType: CommandType.StoredProcedure).ToList();
            if (customersData.Count > 0)
                return true;
            else
                return false;
        }

        public bool CreateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public bool ForgotPassword(string email)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomer(int id)
        {
            var query = Constant.Constant.ProcedureNames.GetCustomer;
            DynamicParameters p = new DynamicParameters();
            p.Add("@id", id);
            var customersData = SqlMapper.Query<Customer>(_IConnection, query, param: p, commandType: CommandType.StoredProcedure).ToList();
            if (customersData.Count > 0)
                return customersData.FirstOrDefault();
            else
                return new Customer();
        }

        public bool UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
