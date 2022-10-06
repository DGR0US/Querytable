using Dapper;
using Npgsql;
using Querytable.Data;

namespace Querytable.Services
{
    public interface ICustomerService
    {
        List<customer> GetAllCustomer();
    }
    public class CustomerService : ICustomerService
    {
        public List<customer> GetAllCustomer()
        {
            List<customer> Res = new List<customer>();
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(GbVer.Connectionstring))
                {
                    con.Open();
                    string SQL = "SELECT * FROM customer ORDER BY id";
                    Res = con.Query<customer>(SQL).ToList();
                }
            }
            catch (Exception ex)
            {}
            return Res;
        }
    }
}
