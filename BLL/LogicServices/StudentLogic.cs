using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BOL.DatabaseEntities;
using DAL.DataServices;
using BLL.LogicServices.Contract;

namespace BLL.Services
{
    public class StudentLogic : IStudentLogic
    {
        private readonly IStudentDataDAL _studentDataDAL;

        public StudentLogic(IStudentDataDAL studentDataDAL)
        {
            this._studentDataDAL = studentDataDAL;
        }
        public List<Student> GetStudentListLogic()
        {
            List<Student> result = new List<Student>();
            result = _studentDataDAL.GetStudentListDAL();

            return result;
        }


        public string SaveStudentRecordLogic(Student FormData)
        {
            string result = string.Empty;

            if (String.IsNullOrWhiteSpace(FormData.UserName) || String.IsNullOrWhiteSpace(FormData.UserEmail) || String.IsNullOrWhiteSpace(FormData.UserPhoneNo))
            {
                result = "Please fill all the fields";
                return result;
            }

            result =  _studentDataDAL.SaveStudentRecordDAL(FormData);
            if (result == "Saved Successfully!")
            {
                return "Saved Successfully!";
            }
            else {
                result = "Error! Try again..";
                return result;
            }

     
        }
    }

}