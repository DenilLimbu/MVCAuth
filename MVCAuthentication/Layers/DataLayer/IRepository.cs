using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCAuthentication.Models;


namespace MVCAuthentication.DataLayer
{
    interface IRepository
    {
        DataTable ShowStudent(int Department);
        List<EPL> GetTable(string tableName);
        int DropCourse(string stNum, string courseNum);
        bool IsUserExist(string stNum);
    }
}
