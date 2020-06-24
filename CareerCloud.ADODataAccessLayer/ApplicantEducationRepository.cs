using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantEducationRepository : IDataRepository<ApplicantEducationPoco>
    {
        public void Add(params ApplicantEducationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(BaseAdo.connectionString))
            { 
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                foreach (ApplicantEducationPoco poco in items)
                {
                    cmd.CommandText = @"INSERT INTO [dbo].[Applicant_Educations]
                                           ([Id]
                                           ,[Applicant]
                                           ,[Major]
                                           ,[Certificate_Diploma]
                                           ,[Start_Date]
                                           ,[Completion_Date]
                                           ,[Completion_Percent])
                                     VALUES
                                           (@Id
                                           ,@Applicant
                                           ,@Major
                                           ,@Certificate_Diploma
                                           ,@Start_Date
                                           ,@Completion_Date
                                           ,@Completion_Percent)";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
                    cmd.Parameters.AddWithValue("@Major", poco.Major);
                    cmd.Parameters.AddWithValue("@Certificate_Diploma", poco.CertificateDiploma);
                    cmd.Parameters.AddWithValue("@Start_Date", poco.StartDate);
                    cmd.Parameters.AddWithValue("@Completion_Date", poco.CompletionDate);
                    cmd.Parameters.AddWithValue("@Completion_Percent", poco.CompletionPercent);

                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantEducationPoco> GetAll(params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {

            ApplicantEducationPoco[] pocos = new ApplicantEducationPoco[1000];

            using (SqlConnection conn = new SqlConnection(BaseAdo.connectionString))
            {
                SqlCommand cmd = new SqlCommand(@"SELECT * FROM[dbo].[Applicant_Educations]", conn);
                int position = 0;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ApplicantEducationPoco poco = new ApplicantEducationPoco();

                    poco.Id = reader.GetGuid(0);
                    poco.Applicant = reader.GetGuid(1);
                    poco.Major = reader.GetString(2);
                    poco.CertificateDiploma = reader.GetString(3);
                    poco.StartDate = reader.IsDBNull(4) ? null : reader.GetDateTime(4) as DateTime?;
                    poco.CompletionDate = reader.IsDBNull(5) ? null : reader.GetDateTime(5) as DateTime?;
                    poco.CompletionPercent = reader.IsDBNull(6) ? null : reader.GetByte(6) as byte?;
                    poco.TimeStamp = reader[7] as byte[];

                    pocos[position] = poco;
                    position++;
                }
                reader.Close();
                conn.Close();
            }
            return pocos.Where(a => a != null).ToList();
        }

        public IList<ApplicantEducationPoco> GetList(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantEducationPoco GetSingle(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantEducationPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantEducationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(BaseAdo.connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                foreach (ApplicantEducationPoco poco in items)
                {
                    cmd.CommandText = @"DELETE FROM[dbo].[Applicant_Educations]
                        WHERE [Id] = @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);

                     cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
        public void Update(params ApplicantEducationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(BaseAdo.connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                foreach (ApplicantEducationPoco poco in items)
                {
                    cmd.CommandText = @"UPDATE [dbo].[Applicant_Educations]
                                           SET [Applicant] = @Applicant
                                              ,[Major] = @Major
                                              ,[Certificate_Diploma] = @Certificate_Diploma
                                              ,[Start_Date] = @Start_Date
                                              ,[Completion_Date] = @Completion_Date
                                              ,[Completion_Percent] = @Completion_Percent
                                         WHERE [Id] = @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
                    cmd.Parameters.AddWithValue("@Major", poco.Major);
                    cmd.Parameters.AddWithValue("@Certificate_Diploma", poco.CertificateDiploma);
                    cmd.Parameters.AddWithValue("@Start_Date", poco.StartDate);
                    cmd.Parameters.AddWithValue("@Completion_Date", poco.CompletionDate);
                    cmd.Parameters.AddWithValue("@Completion_Percent", poco.CompletionPercent);

                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
    }
}
