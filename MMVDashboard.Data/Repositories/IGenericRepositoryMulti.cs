﻿using Dapper;
using MMVDashboard.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MMVDashboard.Data.Repositories
{
    public interface IGenericRepositoryMulti<T, C> where T : class 
    {
        IDbConnection GetConnection(GConnection gConnection);
        string GetScalar(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, GConnection gConnection = default);
        T Get(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, GConnection gConnection = default);
        Task<T> GetAsync(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, GConnection gConnection = default);
        Task<List<T>> GetAllAsync(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, GConnection gConnection = default);
        List<T> GetAll(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, GConnection gConnection = default);
        int Execute(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, GConnection gConnection = default);
        T Insert(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, GConnection gConnection = default);
        T Update(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, GConnection gConnection = default);


    }
}
