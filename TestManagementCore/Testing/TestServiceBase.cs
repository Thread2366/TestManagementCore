using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using TestManagementCore.Entities;

namespace TestManagementCore.Testing
{
    public abstract class TestServiceBase<T> where T : class, ITestEntity, new()
    {
        public ServiceSettings Settings { get; }

        protected string _tableName = typeof(T).GetCustomAttribute<TableAttribute>()?.Name
            ?? typeof(T).Name;

        protected TestServiceBase(ServiceSettings settings)
        {
            Settings = settings;
        }

        public T GetById(int id)
        {
            using (var conn = new SqlConnection(Settings.ConnectionString))
            {
                return conn.QueryFirstOrDefault<T>($"SELECT * FROM {_tableName} WHERE Id = @Id",
                    new { Id = id });
            }
        }

        public long Create(T obj)
        {
            using (var conn = new SqlConnection(Settings.ConnectionString))
            {
                return conn.Insert(obj);
            }
        }

        public bool Edit(T obj)
        {
            using (var conn = new SqlConnection(Settings.ConnectionString))
            {
                return conn.Update(obj);
            }
        }

        public int Delete(int id)
        {
            using (var conn = new SqlConnection(Settings.ConnectionString))
            {
                return conn.Execute($"DELETE FROM {_tableName} WHERE Id = @Id",
                    new { Id = id });
            }
        }
    }
}
