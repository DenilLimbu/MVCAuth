using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCAuthentication.Models;

namespace MVCAuthentication.BusinessLayer
{
    interface IBusinessAuthentication
    {  
        DataTable ShowStudent(int Department);

        int DropCourse(string stNum, string courseNum);

        bool IsUserExist(string stNum);

        List<EPL> GetTable(string tableName);

    }
}
