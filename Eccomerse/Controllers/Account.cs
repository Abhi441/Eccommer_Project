using Eccomerse.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Eccomerse.Controllers
{
   // [Route("api/Account")]
    [ApiController]
    public class Account : ControllerBase
    {
        private readonly IConfiguration _configuration;


        public Account(IConfiguration config)
        {
            _configuration = config;
        }

        [HttpGet]
        [Route("GetAllRegistration")]
        public List<Registration> GetAllProduct()
        {
            List<Registration> Lst = new List<Registration>();
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Default"));
            SqlCommand cmd = new SqlCommand("Select * from Registration", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Registration obj = new Registration();
                obj.MobileNumber = dt.Rows[i]["MobileNumber"].ToString();
                obj.FirstName = dt.Rows[i]["FirstName"].ToString();
                obj.LastName = dt.Rows[i]["LastName"].ToString();
                obj.Email = dt.Rows[i]["Email"].ToString();
                obj.Gender = dt.Rows[i]["Gender"].ToString();
                obj.Passwoed = long.Parse(dt.Rows[i]["Passwoed"].ToString());
                obj.Re_Password = long.Parse(dt.Rows[i]["Re_Password"].ToString());

                Lst.Add(obj);
            }
            return Lst;
        }
        //       MobileNumber,
        //   FirstName,
        //   LastName ,
        //Email,
        //   Gender,
        //Passwoed,
        //Re_Password

        //[HttpPost]
        //[Route("SaveRegistration")]
        //public string SaveProduct(Registration obj)
        //{
        //    SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Default"));
        //    SqlCommand cmd = new SqlCommand("Insert Into Registration(MobileNumber,FirstName, LastName ,Email, Gender,Passwoed,Re_Password) Values (@MobileNumber,@FirstName, @LastName ,@Email, @Gender, @Passwoed, @Re_Password)", con);
        //    con.Open();
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //    return "Product Saved successfully";
        //}
        [HttpPost]
        [Route("SaveRegistration")]
        public string SaveRegistration(Registration obj)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Default"));
            SqlCommand cmd = new SqlCommand("INSERT INTO Registration (MobileNumber, FirstName, LastName, Email, Gender, Passwoed, Re_Password) VALUES (@MobileNumber, @FirstName, @LastName, @Email, @Gender, @Passwoed, @Re_Password)", con);

            cmd.Parameters.AddWithValue("@MobileNumber", obj.MobileNumber);
            cmd.Parameters.AddWithValue("@FirstName", obj.FirstName);
            cmd.Parameters.AddWithValue("@LastName", obj.LastName);
            cmd.Parameters.AddWithValue("@Email", obj.Email);
            cmd.Parameters.AddWithValue("@Gender", obj.Gender);
            cmd.Parameters.AddWithValue("@Passwoed", obj.Passwoed);
            cmd.Parameters.AddWithValue("Re_Password", obj.Re_Password);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            return "Registration Saved successfully";
        }

    }
}

