using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCAuthentication.DataLayer
{
    interface IDataAccess
    {
        Object GetSingleAnswer(string sql);
        DataTable GetManyRowsCols(string sql);
        int InsertUpdateDelete(string sql);

    }
}
