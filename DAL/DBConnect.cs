using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBConnect
    {
        protected SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-8VLMQ1U\SQLEXPRESS;Initial Catalog=SOF2051_QLBanHang1;Integrated Security=True;");
    }
}
