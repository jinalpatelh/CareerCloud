using System;
using System.Collections.Generic;
using System.Text;
using CareerCloud.Pocos;
using CareerCloud.DataAccessLayer;

namespace CareerCloud.BusinessLogicLayer
{
    public class ApplicantEducationLogic : BaseLogic<ApplicantEducationPoco>
    {
        public ApplicantEducationLogic(IDataRepository<ApplicantEducationPoco> repository) : base(repository)
        {

        }

        protected override void Verify(ApplicantEducationPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();

            foreach (var poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.Major) || poco.Major.Length < 3)
                {
                    exceptions.Add(new ValidationException(107, $"Major field for {poco.Id} can't be empty or less than 3 character!"));
                } 
                else if(poco.StartDate > DateTime.Today)
                {
                    exceptions.Add(new ValidationException(108, $"Startdate of Education for {poco.Id} can not be greater than today!"));
                }
                else if(poco.CompletionDate < poco.StartDate)
                {
                    exceptions.Add(new ValidationException(109, $"Completion date for {poco.Id} can't be earlier than startdate!"));
                }

            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }

        
        public override void Update(ApplicantEducationPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        public override void Add(ApplicantEducationPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }
    }
}
