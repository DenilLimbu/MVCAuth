using System.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCAuthentication.Models;
using MVCAuthentication.DataLayer;

namespace MVCAuthentication.BusinessLayer
{
    class BusinessAuthentication : IBusinessAuthentication
    {
        IRepository _irep = null;
        public BusinessAuthentication():this(new Repository())
        {
            //_irep = new Repository()
        }

        public BusinessAuthentication(IRepository irep)
        {
            _irep = irep;
        }

        public List<EPL> GetTable(string tableName)
        {
            return _irep.GetTable(tableName);
        }

        public DataTable ShowStudent(int Department)
        {
            return _irep.ShowStudent(Department);
        }


        public int DropCourse(string stNum, string courseNum)
        {
            return _irep.DropCourse(stNum, courseNum);
        }

        public bool IsUserExist(string stNum)
        {
            return _irep.IsUserExist(stNum);
        }

    }
}
