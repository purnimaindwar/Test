using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Config;
using log4net;

namespace ADO.NETJoins
{
    class ADOJoin
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static SqlConnection con;
        static SqlCommand com;
        /// <summary>
        /// sql connection
        /// </summary>
        public static void connection()
        {
            con = new SqlConnection(@"Data Source = ADMIN\PURVISOL; Initial Catalog = School; Integrated Security = True");
            con.Open();
        }
        /// <summary>
        /// LeftJoin Operation
        /// </summary>
        public static void LeftJion()
        {
            String sql = "SELECT Student1.Name, Teacher2.Subject FROM Student1 LEFT JOIN Teacher2 on Student1.Name = Teacher2.Subject ORDER BY Teacher2.Subject";
            com = new SqlCommand(sql, con);
            SqlDataReader sdr = com.ExecuteReader();
            for (int i = 0; i < sdr.FieldCount; i++)
            {
                Console.Write(sdr.GetName(i) + "\t" + "\t");
            }
            Console.WriteLine();
            Console.WriteLine("=================================");
            while (sdr.Read())
            {
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    Console.Write(sdr[sdr.GetName(i)] + "\t" + "\t");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// RightJoin
        /// </summary>
        public static void RightJion()
        {
            String sql = "SELECT Student1.Name, Teacher2.Subject FROM Student1 RIGHT JOIN Teacher2 on Student1.Name = Teacher2.Subject ORDER BY Teacher2.Subject";
            com = new SqlCommand(sql, con);
            SqlDataReader sdr = com.ExecuteReader();
            for (int i = 0; i < sdr.FieldCount; i++)
            {
                Console.Write(sdr.GetName(i) + "\t" + "\t");
            }
            Console.WriteLine();
            while (sdr.Read())
            {
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    Console.Write(sdr[sdr.GetName(i)] + "\t" + "\t");
                }
                Console.WriteLine();
            }
        }
        public static void FullJion()
        {
            String sql = "SELECT Student1.Name, Teacher2.Subject FROM Student1 FULL OUTER JOIN Teacher2 on Student1.Name =Teacher2.Subject ORDER BY Teacher2.Subject";
            com = new SqlCommand(sql, con);
            SqlDataReader sdr = com.ExecuteReader();
            for (int i = 0; i < sdr.FieldCount; i++)
            {
                Console.Write(sdr.GetName(i) + "\t" + "\t");
            }
            Console.WriteLine();
            Console.WriteLine("=================================");
            while (sdr.Read())
            {
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    Console.Write(sdr[sdr.GetName(i)] + "\t" + "\t");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            connection();
            FullJion();
            //LeftJion();
            //RightJion();
            Console.ReadLine();
        }
    }
}