using BOL.DatabaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataServices
{
    public interface IStudentDataDAL
    {
        public List<Student> GetStudentListDAL();
        public string SaveStudentRecordDAL(Student FormData);
    }
}
