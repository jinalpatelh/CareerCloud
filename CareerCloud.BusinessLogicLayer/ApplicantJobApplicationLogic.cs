using System;
using System.Collections.Generic;
using System.Text;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
    public class ApplicantJobApplicationLogic : BaseLogic<ApplicantJobApplicationPoco>
    {
        public ApplicantJobApplicationLogic(IDataRepository<ApplicantJobApplicationPoco> repository) : base(repository)
        {

        }

        protected override void Verify(ApplicantJobApplicationPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach(var poco in pocos)
            {
                if(poco.ApplicationDate > DateTime.Today)
                {
                    exceptions.Add(new ValidationException(110, $"Application Date for {poco.Id} can't be greater than today!"));
                }
                
                if(exceptions.Count>0)
                {
                    throw new AggregateException(exceptions);
                }
            }

        }

        public override void Add(ApplicantJobApplicationPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos)
        }

        public override void Update(ApplicantJobApplicationPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }
    }
}
