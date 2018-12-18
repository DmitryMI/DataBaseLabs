using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
using System.Reflection;

namespace LINQLab.LinqToSql
{
    class UserDataContext : DataContext
    {
        public UserDataContext(string connectionString)
            : base(connectionString)
        {

        }

        [Function(Name = "sp_GetRichestCompany")]
        public int GetRichestCompany
            (
            [Parameter(Name = "ownerName", DbType = "NVarchar(100)")] string ownerName,
             [Parameter(Name = "companyname", DbType = "NVarchar(100)")] ref string companyName
            )
        {
            IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), ownerName, companyName);

            companyName = (string) result.GetParameterValue(1);

            return (int)result.ReturnValue;
        }
    }
}
