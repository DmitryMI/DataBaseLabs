using System;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

namespace Module1
{
    public class UserDefinedFunctions
    {
        [SqlFunction]

        static public SqlInt32 GetRandomNumber()
        {
            Random rnd = new Random();
            return rnd.Next();
        }
    }
}
