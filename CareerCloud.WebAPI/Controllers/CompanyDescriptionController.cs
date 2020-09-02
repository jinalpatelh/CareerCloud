using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/company/v1")]
    [ApiController]
    public class CompanyDescriptionController : ControllerBase
    {
        private CompanyDescriptionLogic _logic;

        public CompanyDescriptionController()
        {
            EFGenericRepository<CompanyDescriptionPoco> repo = new EFGenericRepository<CompanyDescriptionPoco>();
            _logic = new CompanyDescriptionLogic(repo);
        }
        [HttpGet]
        [Route("description/{companyDescriptionId}")]
        [ProducesResponseType(typeof(CompanyDescriptionPoco),200)]
        public ActionResult GetCompanyDescription(Guid companyDescriptionId)
        {
            CompanyDescriptionPoco companyDescription = _logic.Get(companyDescriptionId);
            if (companyDescription == null)
                return NotFound();
            else
                return Ok(companyDescription);
        }

        [HttpGet]
        [Route("description")]
        [ProducesResponseType(typeof(List<CompanyDescriptionPoco>),200)]
        public ActionResult GetCompanyDescription()
        {
            List<CompanyDescriptionPoco> companyDescriptions = _logic.GetAll();
            if (companyDescriptions == null)
                return NotFound();
            else
                return Ok(companyDescriptions);
        }

        [HttpPost]
        [Route("description")]
        public ActionResult PostCompanyDescription([FromBody] CompanyDescriptionPoco[] companyDescriptionPocos)
        {
            _logic.Add(companyDescriptionPocos);
            return Ok();
        }

        [HttpPut]
        [Route("description")]
        public ActionResult PutCompanyDescription([FromBody] CompanyDescriptionPoco[] companyDescriptionPocos)
        {
            _logic.Update(companyDescriptionPocos);
            return Ok();
        }

        [HttpDelete]
        [Route("description")]
        public ActionResult DeleteCompanyDescription([FromBody] CompanyDescriptionPoco[] companyDescriptionPocos)
        {
            _logic.Delete(companyDescriptionPocos);
            return Ok();
        }
    }
}