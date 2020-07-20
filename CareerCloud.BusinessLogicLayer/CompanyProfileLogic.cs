using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
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
            foreach (var poco in pocos)
            {
                if(string.IsNullOrEmpty(poco.ContactPhone))
                    exceptions.Add(new ValidationException(600, $"Contact Phone for {poco.Id} must correspond to valid number."));
                else if(!System.Text.RegularExpressions.Regex.IsMatch(poco.ContactPhone, @"^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$", RegexOptions.IgnoreCase))
                    exceptions.Add(new ValidationException(600, $"Contact Phone for {poco.Id} must correspond to valid number."));

                if(string.IsNullOrEmpty(poco.CompanyWebsite))
                    exceptions.Add(new ValidationException(601, $"Company website for {poco.Id} must correspond to valid web address"));
                else if(!Regex.IsMatch(poco.CompanyWebsite, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
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
