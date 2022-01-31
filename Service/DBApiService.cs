using DBApi.DAL;
using DBApi.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace DBApi.Service
{
    public interface IDBApiService
    {
        string GetHighestByYear(int year);
        string GetData(string listCode, int row);
        string GetAgentsByYear(int amountOrders, int year);
    }
    public class DBApiService:IDBApiService
    {
        private readonly DBApiContext _context;
        private string sql;
        public DBApiService(DBApiContext context)
        {
            _context = context;
        }

        public string GetAgentsByYear(int amountOrder, int year)
        {
            sql = "exec sp_GetAgentsByYear @OrderNum,@Year";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@OrderNum", Value = amountOrder },
                new SqlParameter { ParameterName = "@Year", Value = year }

            };
            return  JsonSerializer.Serialize(_context.AgentData.FromSqlRaw<Agent>(sql, parms.ToArray()).AsEnumerable().ToList());
        }

        public string GetData(string listCode, int row)
        {
            sql = "exec sp_GetAgentsWithOrderNum @agentCode,@rowNum";

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@agentCode", Value = listCode },
                new SqlParameter { ParameterName = "@rowNum", Value = row }
            };
            return JsonSerializer.Serialize(_context.OrderData.FromSqlRaw<Order>(sql, parms.ToArray()).AsEnumerable().ToList());
        }

        public string GetHighestByYear(int year)
        {
            sql = "EXEC sp_GetMaxAmoutByYear @year";
            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@year", Value = year }
            };
            return JsonSerializer.Serialize(_context.MaxAmountCode.FromSqlRaw<Response>(sql, parms.ToArray()).AsEnumerable().ToList());
        }
    }
}
