using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CareerCloud.ADODataAccessLayer
{
    public class SecurityRoleRepository : IDataRepository<SecurityRolePoco>
    {
        public void Add(params SecurityRolePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(BaseAdo.connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                foreach (SecurityRolePoco poco in items)
                {
                    cmd.CommandText = @"INSERT INTO [dbo].[Security_Logins_Log]
                                                       ([Id]
                                                       ,[Role]
                                                       ,[Is_Inactive]
                                                 VALUES
                                                       (@Id
                                                       ,@Role
                                                       ,@Is_Inactive)";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Role", poco.Role);
                    cmd.Parameters.AddWithValue("@Is_Inactive", poco.IsInactive);
   
                    cmd.ExecuteNonQuery();
                }
                conn.Close();

            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SecurityRolePoco> GetAll(params Expression<Func<SecurityRolePoco, object>>[] navigationProperties)
        {
            SecurityRolePoco[] pocos = new SecurityRolePoco[1000];

            using (SqlConnection conn = new SqlConnection(BaseAdo.connectionString))
            {
                SqlCommand cmd = new SqlCommand(@"SELECT * FROM[dbo].[Security_Roles]", conn);
                int position = 0;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SecurityRolePoco poco = new SecurityRolePoco();

                    poco.Id = reader.GetGuid(0);
                    poco.Role = reader.GetString(1);
                    poco.IsInactive = reader.GetBoolean(2);

                    pocos[position] = poco;
                    position++;
                }
                reader.Close();
                conn.Close();
            }
            return pocos;
        }

        public IList<SecurityRolePoco> GetList(Expression<Func<SecurityRolePoco, bool>> where, params Expression<Func<SecurityRolePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityRolePoco GetSingle(Expression<Func<SecurityRolePoco, bool>> where, params Expression<Func<SecurityRolePoco, object>>[] navigationProperties)
        {
            IQueryable<SecurityRolePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SecurityRolePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(BaseAdo.connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                foreach (SecurityRolePoco poco in items)
                {
                    cmd.CommandText = @"DELETE FROM[dbo].[Security_Roles]
                        WHERE [Id] = @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);

                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public void Update(params SecurityRolePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(BaseAdo.connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                foreach (SecurityRolePoco poco in items)
                {
                    cmd.CommandText = @"UPDATE [dbo].[Security_Roles]
                                               SET [Role] = @Role
                                                  ,[Is_Inactive] = @Is_Inactive
                                                  ,[Logon_Date] = @Logon_Date
                                                  ,[Is_Succesful] = @Is_Succesful
                                             WHERE [Id] = @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Role", poco.Role);
                    cmd.Parameters.AddWithValue("@Is_Inactive", poco.IsInactive);

                    cmd.ExecuteNonQuery();
                }
                conn.Close();

            }
        }
    }
}
