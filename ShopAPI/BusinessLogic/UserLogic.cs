using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Data.SqlClient;
using ShopAPI.DataAccess;
using System.Data;
using ShopAPI.Model;

namespace ShopAPI.BusinessLogic
{
    public class UserLogic
    {
        
            private readonly SQLHelper _dBHelper;
            public UserLogic(SQLHelper sql)
            {
                _dBHelper = sql;
            }


            public int Registration(StudentReg student)
            {
                string sqlQuery = $"INSERT INTO Registration(EmpType,FullName,EmailId,Password,cpassword,Qualification,Yearofpassedout,Experience,phoneno,Address,AddressProof,Dateofbirth,Age) VALUES(@EmpType,@FullName,@EmailId,@Password,@cpassword,@Qualification,@Yearofpassedout,@Experience,@phoneno,@Address,@AddressProof,@Dateofbirth,@Age)";
                SqlParameter[] parameters =
                    {
                new SqlParameter("@EmpType", student.Employeetype),
                new SqlParameter("@FullName",student.Fullname),
                new SqlParameter("@EmailId",  student.EmailID),
                new SqlParameter("@Password", student.password),

                new SqlParameter("@cpassword", student.Cpassword),
                new SqlParameter("@Qualification", student.Qualification),
                new SqlParameter("@Yearofpassedout", student.Yearofpassedout),
                new SqlParameter("@Experience", student.Experiences),

                 new SqlParameter("@phoneno",student.Phoneno),
                new SqlParameter("@Address", student.Address),
                new SqlParameter("@AddressProof", student.Addressproof),
                new SqlParameter("@Dateofbirth", student.Dateofbirth),
                new SqlParameter("@Age", student.Age)

                };
                return _dBHelper.sqlExcuteNonQuery(sqlQuery, parameters);
            }

            public object LoginCheck(StudentReg student)
            {

                string sqlQuery = "select count(*) from Registration where EmailId = @EmailId and Password = @Password  and EmpType = @EmpType";
                SqlParameter[] parameters =
                    {
                new SqlParameter("@EmpType", student.Employeetype),
                new SqlParameter("@EmailId",  student.EmailID),
                new SqlParameter("@Password", student.password)
                };
                return _dBHelper.SqlExcuteScaller(sqlQuery, parameters);
            }
        
    }
}
