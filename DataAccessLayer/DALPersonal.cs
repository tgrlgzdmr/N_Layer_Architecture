using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EntityLayer;
using System.Data;

namespace DataAccessLayer
{
    public class DALPersonal
    {
        public static List<EntityPersonal> PersonalList()
        { 
            List<EntityPersonal> values = new List<EntityPersonal>();
            SqlCommand cmd1 = new SqlCommand("Select * From Tbl_Information",Connection1.conn);
            if (cmd1.Connection.State!= ConnectionState.Open)
            {
                cmd1.Connection.Open();
            }
            SqlDataReader dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                EntityPersonal ent = new EntityPersonal();
                ent.Id= int.Parse(dr["Perconalid"].ToString());
                ent.Name=dr["Name"].ToString();
                ent.Surname=dr["Surname"].ToString();
                ent.City=dr["City"].ToString() ;
                ent.Duty = dr["Duty"].ToString();
                ent.Salary = short.Parse(dr["Salary"].ToString()) ;
                values.Add(ent);
            }
            dr.Close();
            return values;

        }
        public static int AddPersonal(EntityPersonal p)
        {
            SqlCommand cmd2 = new SqlCommand("insert into Tbl_Information (Name,Surname,City,Duty,Salary) VALUES (@P1,@P2,@P3,@P4,@P5)", Connection1.conn);
            if (cmd2.Connection.State != ConnectionState.Open)
            {
                cmd2.Connection.Open();
            }
            cmd2.Parameters.AddWithValue("@P1", p.Name);
            cmd2.Parameters.AddWithValue("@P2", p.Surname);
            cmd2.Parameters.AddWithValue("@P3", p.City);
            cmd2.Parameters.AddWithValue("@P4", p.Duty);
            cmd2.Parameters.AddWithValue("@P5", p.Salary);
            return cmd2.ExecuteNonQuery();
        }
        
        public static bool DelPersonal(int d)
        {
            SqlCommand cmd3 = new SqlCommand("Delete From Tbl_Information where Perconalid=@p1",Connection1.conn);
            if (cmd3.Connection.State != ConnectionState.Open)
            {
                cmd3.Connection.Open();
            }
            cmd3.Parameters.AddWithValue("@p1", d);
            return cmd3.ExecuteNonQuery()>0;
        }
        
        public static bool UpdPersonal(EntityPersonal u)
        {
            SqlCommand cmd4 = new SqlCommand("Update Tbl_Information set Name=@p1,Surname=@p2,City=@p3,Duty=@p4,Salary=@p5 where Perconalid=@p6", Connection1.conn);
            if (cmd4.Connection.State != ConnectionState.Open)
            {
                cmd4.Connection.Open();  
            }
            cmd4.Parameters.AddWithValue("@p1", u.Name);
            cmd4.Parameters.AddWithValue("@p2", u.Surname);
            cmd4.Parameters.AddWithValue("@p3", u.City);
            cmd4.Parameters.AddWithValue("@p4", u.Duty);
            cmd4.Parameters.AddWithValue("@p5", u.Salary);
            cmd4.Parameters.AddWithValue("@p6", u.Id);
            return cmd4.ExecuteNonQuery() > 0;

        }
    }
}
