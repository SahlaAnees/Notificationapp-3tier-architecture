using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BOL.DatabaseEntities;
using DAL.DataContext.Contract;
using Dapper;
using Mysqlx.Prepare;

namespace DAL.DataServices
{
    public class StudentDataDAL : IStudentDataDAL
    {

        private readonly IDapperHelper _dapperHelper;

        public StudentDataDAL(IDapperHelper dapperHelper) {
            _dapperHelper = dapperHelper;
        }
        public List<Student> GetStudentListDAL() {
            List<Student> students = new List<Student>();

            try {
                using (IDbConnection dbConnection = _dapperHelper.GetDapperHelper()) {
                    string SqlQuery = "SELECT * FROM user";
                    students = dbConnection.Query<Student>(SqlQuery, commandType : CommandType.Text).ToList();
                }
                
            }
            catch(Exception ex) {
                String message = ex.Message;
            }

            return students;
        }

        public string SaveStudentRecordDAL(Student FormData)
        {
            string result = string.Empty;

            try
            {
                using (IDbConnection dbConnection = _dapperHelper.GetDapperHelper())
                {
                    dbConnection.Execute(@"INSERT INTO user(UserName, UserEmail, UserPhoneNo)VALUES(@UserName, @UserEmail, @UserPhoneNo)", 
                        new { 
                            UserName=FormData.UserName,
                            UserEmail = FormData.UserEmail,
                            UserPhoneNo = FormData.UserPhoneNo
                        },
                        commandType: CommandType.Text);
                    result = "Saved Successfully!";
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            return result;
        }

    }
}
