﻿using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CareerCloud.ADODataAccessLayer
{
    public class SecurityLoginsRoleRepository : IDataRepository<SecurityLoginsRolePoco>
    {
        public void Add(params SecurityLoginsRolePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(BaseAdo.connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                foreach (SecurityLoginsRolePoco poco in items)
                {
                    cmd.CommandText = @"INSERT INTO [dbo].[Security_Logins_Roles]
                                                       ([Id]
                                                       ,[Login]
                                                       ,[Role])
                                                 VALUES
                                                       (@Id
                                                       ,@Login
                                                       ,@Role)";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Login", poco.Login);
                    cmd.Parameters.AddWithValue("@Role", poco.Role);

                    cmd.ExecuteNonQuery();
                }
                conn.Close();

            }

        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SecurityLoginsRolePoco> GetAll(params Expression<Func<SecurityLoginsRolePoco, object>>[] navigationProperties)
        {
            SecurityLoginsRolePoco[] pocos = new SecurityLoginsRolePoco[1000];

            using (SqlConnection conn = new SqlConnection(BaseAdo.connectionString))
            {
                SqlCommand cmd = new SqlCommand(@"SELECT * FROM[dbo].[Security_Logins_Roles]", conn);
                int position = 0;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SecurityLoginsRolePoco poco = new SecurityLoginsRolePoco();

                    poco.Id = reader.GetGuid(0);
                    poco.Login = reader.GetGuid(1);
                    poco.Role = reader.GetGuid(2);
                    poco.TimeStamp = reader[3] as byte[];
                    
                    pocos[position] = poco;
                    position++;
                }
                reader.Close();
                conn.Close();
            }
            return pocos.Where(a=>a!=null).ToList();

        }

        public IList<SecurityLoginsRolePoco> GetList(Expression<Func<SecurityLoginsRolePoco, bool>> where, params Expression<Func<SecurityLoginsRolePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityLoginsRolePoco GetSingle(Expression<Func<SecurityLoginsRolePoco, bool>> where, params Expression<Func<SecurityLoginsRolePoco, object>>[] navigationProperties)
        {
            IQueryable<SecurityLoginsRolePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SecurityLoginsRolePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(BaseAdo.connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                foreach (SecurityLoginsRolePoco poco in items)
                {
                    cmd.CommandText = @"DELETE FROM[dbo].[Security_Logins_Roles]
                        WHERE [Id] = @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);

                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public void Update(params SecurityLoginsRolePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(BaseAdo.connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                foreach (SecurityLoginsRolePoco poco in items)
                {
                    cmd.CommandText = @"UPDATE [dbo].[Security_Logins_Roles]
                                               SET [Login] = @Login
                                                  ,[Role] = @Role
                                             WHERE [Id] = @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Login", poco.Login);
                    cmd.Parameters.AddWithValue("@Role", poco.Role);

                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
    }
}
