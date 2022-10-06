using Dapper;
using Npgsql;
using Querytable.Data;

namespace Querytable.Services
{
    public interface IProductService
    {
        List<product> GetAllProduct();
    }
    public class ProductService : IProductService
    {
        public List<product> GetAllProduct()
        {
            List<product> Res = new List<product>();
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(GbVer.Connectionstring))
                {
                    con.Open();
                    string SQL = "SELECT * FROM product ORDER BY code";
                    Res = con.Query<product>(SQL).ToList();
                }
            }
            catch (Exception ex)
            {}
            return Res;
        }

    }
}
