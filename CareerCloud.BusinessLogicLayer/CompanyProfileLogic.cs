using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyProfileLogic : BaseLogic<CompanyProfilePoco>
    {
        public CompanyProfileLogic(IDataRepository<CompanyProfilePoco> repository) : base(repository)
        {

        }

        protected override void Verify(CompanyProfilePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            
            string[] validDomains = { ".ca", ".com", ".biz" };
            
            foreach (CompanyProfilePoco poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.ContactPhone))
                    exceptions.Add(new ValidationException(600, $"Contact Phone for {poco.Id} must correspond to valid number."));
                else
                {
                    string[] phoneComponents = poco.ContactPhone.Split('-');
                    if (phoneComponents.Length < 3)
                    {
                        exceptions.Add(new ValidationException(601, $"ContactPhone for CompanyProfile {poco.ContactPhone} is not in the required format."));
                    }
                    else
                    {
                        if (phoneComponents[0].Length < 3)
                        {
                            exceptions.Add(new ValidationException(601, $"ContactPhone for {poco.Id} CompanyProfile {poco.ContactPhone} is not in the required format."));
                        }
                        else if (phoneComponents[1].Length < 3)
                        {
                            exceptions.Add(new ValidationException(601, $"ContactPhone for {poco.Id} CompanyProfile {poco.ContactPhone} is not in the required format."));
                        }
                        else if (phoneComponents[2].Length < 4)
                        {
                            exceptions.Add(new ValidationException(601, $"ContactPhone for {poco.Id} CompanyProfile {poco.ContactPhone} is not in the required format."));
                        }
                    }
                }

                if(string.IsNullOrEmpty(poco.CompanyWebsite))
                    exceptions.Add(new ValidationException(601, $"Company website for {poco.Id} must correspond to valid web address"));
                else if(!validDomains.Any(d => poco.CompanyWebsite.EndsWith(d)))
                    exceptions.Add(new ValidationException(601, $"Company website for {poco.Id} must correspond to valid web address"));
            }
            
            if (exceptions.Count > 0)
                throw new AggregateException(exceptions);
        }

        public override void Add(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }
    }
}
