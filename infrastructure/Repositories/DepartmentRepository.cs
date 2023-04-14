using Infrastructure.Contracts.Repositories;
using Infrastructure.Entities;
using Dapper;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class DepartmentRepository : IRepository<Departments>
    {
        private readonly DapperDbContext _dbContext;
        public DepartmentRepository(DapperDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public int DeleteById(int id)
        {
            using (IDbConnection conn = _dbContext.GetConnection())
            {
                return conn.Execute("Delete From Departments Where Id = @Id", new {Id = id});
            }
        }

        public IEnumerable<Departments> GetAll()
        {
            using (IDbConnection conn = _dbContext.GetConnection())
            {
                return conn.Query<Departments>("Select Id, DeptName, Location From Departments");
            }
        }

        public Departments GetById(int id)
        {
            using (IDbConnection conn = _dbContext.GetConnection())
            {
                return conn.QuerySingleOrDefault<Departments>("Select Id, DeptName, Location From Departments Where Id = @Id",new { Id = id });
            }
        }

        public int Insert(Departments obj)
        {
            //var DeptName = "IT; Drop Database MarchBatch2023";
            using (IDbConnection conn = _dbContext.GetConnection())
            {
                DynamicParameters paramters = new DynamicParameters();
                return conn.Execute("Insert Into Departments Values(@DeptName, @Location)", obj);
            }
            
        }

        public int Update(Departments obj)
        {
            using (IDbConnection conn = _dbContext.GetConnection())
            {
                return conn.Execute("Update Departments set DeptName = @DeptName, Location = @Location Where Id = @Id", obj);
            }
        }
    }
}
