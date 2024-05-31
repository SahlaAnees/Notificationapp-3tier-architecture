using BOL.DatabaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.LogicServices.Contract
{
    public interface IStudentLogic
    {
        public List<Student> GetStudentListLogic();

        public string SaveStudentRecordLogic(Student FormData);
    }
}
