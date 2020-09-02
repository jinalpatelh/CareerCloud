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
    public class CompanyJobsDescriptionController : ControllerBase
    {
        private CompanyJobDescriptionLogic _logic;

        public CompanyJobsDescriptionController()
        {
            EFGenericRepository<CompanyJobDescriptionPoco> repo = new EFGenericRepository<CompanyJobDescriptionPoco>();
            _logic = new CompanyJobDescriptionLogic(repo);
        }

        [HttpGet]
        [Route("jobdescription/{companyJobDescriptionId}")]
        [ProducesResponseType(typeof(CompanyJobDescriptionPoco),200)]
        public ActionResult GetCompanyJobsDescription(Guid companyJobDescriptionId)
        {
            CompanyJobDescriptionPoco companyJobDescription = _logic.Get(companyJobDescriptionId);
            if (companyJobDescription == null)
                return NotFound();
            else
                return Ok(companyJobDescription);
        }

        [HttpGet]
        [Route("jobdescription")]
        [ProducesResponseType(typeof(List<CompanyJobDescriptionPoco>),200)]
        public ActionResult GetCompanyJobsDescription()
        {
            List<CompanyJobDescriptionPoco> companyJobDescriptions = _logic.GetAll();
            if (companyJobDescriptions == null)
                return NotFound();
            else
                return Ok(companyJobDescriptions);
        }

        [HttpPost]
        [Route("jobdescription")]
        public ActionResult PostCompanyJobsDescription([FromBody] CompanyJobDescriptionPoco[] companyJobDescriptionPocos)
        {
            _logic.Add(companyJobDescriptionPocos);
            return Ok();
        }

        [HttpPut]
        [Route("jobdescription")]
        public ActionResult PutCompanyJobsDescription([FromBody] CompanyJobDescriptionPoco[] companyJobDescriptionPocos)
        {
            _logic.Update(companyJobDescriptionPocos);
            return Ok();
        }

        [HttpDelete]
        [Route("jobdescription")]
        public ActionResult DeleteCompanyJobsDescription([FromBody] CompanyJobDescriptionPoco[] companyJobDescriptionPocos)
        {
            _logic.Delete(companyJobDescriptionPocos);
            return Ok();
        }
    }
}