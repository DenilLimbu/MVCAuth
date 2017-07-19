using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MVCAuthentication.Models;

namespace MVCAuthentication.DataLayer
{
    class Repository : IRepository
    {
        IDataAccess _idac = new DataAccess();

        public Repository() : this(new DataAccess())
        {
        }

        public Repository(IDataAccess idac)
        {
            _idac = idac;
        }

        public List<EPL> GetTable(string tableName)
        {
            List<EPL> listEPL = new List<EPL>();
            try
            {
                String sql = "select * from " + tableName;
                DataTable dt = _idac.GetManyRowsCols(sql);
                listEPL = RepositoryHelper.ConvertDataTableToList<EPL>(dt);
            }
            catch (Exception)
            {
                throw;
            }   
            return listEPL;
        }


        public DataTable ShowStudent(int Department)
        {
            DataTable dt = new DataTable();
            try
            {
                String sql = "Select s.StudentId, s.FirstName, s.LastName, s.State, s.State, s.StreetAddress, s.Telephone, d.DepartmentName "
                    + "from Students s inner join StudentMajors sm on s.StudentId = sm.StudentId " +
                    "inner join Departments d on sm.DepartmentId = d.DepartmentId where d.DepartmentId =" + Department.ToString();
                dt = _idac.GetManyRowsCols(sql);

            }
            catch (Exception)
            {
                throw;
            }
            return dt;
        }

        public int DropCourse(string stNum, string courseNum)
        {
            string sql = "delete from StudentCourses where courseNum = '" + courseNum + "' and StudentID = '" + stNum + "'";
            return _idac.InsertUpdateDelete(sql);
        }

        public bool IsUserExist(string stNum)
        {
            bool result = false;
            object obj = null;
            try
            {
                string sql = "select * from AspNetUsers where Email = '" + stNum + "'";
                obj = _idac.GetSingleAnswer(sql);

                if (obj != null)
                    result = true;
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }
    }

}
