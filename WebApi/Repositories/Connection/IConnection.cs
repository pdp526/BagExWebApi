using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Repositories.Connection
{
    public interface IConnection
    {
        IDbConnection GetConnection { get; }
        string SetConnection(); 
    }
}
