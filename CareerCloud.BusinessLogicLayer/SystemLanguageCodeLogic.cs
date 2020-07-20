using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
    public class SystemLanguageCodeLogic
    {
        protected IDataRepository<SystemLanguageCodePoco> _repository;

        public SystemLanguageCodeLogic(IDataRepository<SystemLanguageCodePoco> repository)
        {
            _repository = repository;
        }

        protected void Verify(SystemLanguageCodePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (var poco in pocos)
            {
                if(string.IsNullOrEmpty(poco.LanguageID))
                    exceptions.Add(new ValidationException(1000, $"LanguageId can not be empty."));
                
                if(string.IsNullOrEmpty(poco.Name))
                    exceptions.Add(new ValidationException(1001, $"LanguageName can not be empty."));
                
                if(string.IsNullOrEmpty(poco.NativeName))
                    exceptions.Add(new ValidationException(1002, $"NativeName can not be empty."));
            }
            if(exceptions.Count > 0)
                throw new AggregateException(exceptions);

        }

        public void Add(SystemLanguageCodePoco[] pocos)
        {
            Verify(pocos);
            _repository.Add(pocos);
        }
        public void Update(SystemLanguageCodePoco[] pocos)
        {
            Verify(pocos);
            _repository.Update(pocos);
        }

        public void Delete(SystemLanguageCodePoco[] pocos)
        {
            _repository.Remove(pocos);
        }

        public List<SystemLanguageCodePoco> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public SystemLanguageCodePoco Get(string language_Id)
        {
            return _repository.GetSingle(c => c.LanguageID == language_Id);
        }

    }
}
