using System.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.SqlClient;
using SQLADO_3.Model;

namespace SQLADO_3.Services
{
    public class Employees : IEmployee
    {
        private readonly string CONNECTIONSTRING;

         public Employees(IConfiguration configuration)
        {
            CONNECTIONSTRING = configuration.GetConnectionString("DefaultConnection");
        }
        
          public List<EMPLOYMODEL> Get()
        {
             List<EMPLOYMODEL> nEMPLOYMODELs = new List<EMPLOYMODEL>();
            SqlConnection conn = new SqlConnection(CONNECTIONSTRING);

            SqlCommand cmd = new SqlCommand("SELECT * FROM  Employees;", conn);
            //cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();    
             
              SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var models = new EMPLOYMODEL()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Age = reader.GetInt32(2)
                };
                nEMPLOYMODELs.Add(models);
            }
              return nEMPLOYMODELs;
        }




       public EMPLOYMODEL CREATING(EMPLOYMODEL mPLOYMODEL)
        {
            SqlConnection con = new SqlConnection(CONNECTIONSTRING);
            SqlCommand cmd = new SqlCommand("CreateEmpploy",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Id",mPLOYMODEL.Id);
            cmd.Parameters.AddWithValue("NAME",mPLOYMODEL.Name);
            cmd.Parameters.AddWithValue("AGE", mPLOYMODEL.Age);

            con.Open();

            int AFFRO = cmd.ExecuteNonQuery();

            while (AFFRO<0)
            {
                return null;
            }
            
            return mPLOYMODEL;
        }




    }
}
