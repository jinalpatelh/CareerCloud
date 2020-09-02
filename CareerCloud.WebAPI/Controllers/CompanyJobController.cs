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
    public class CompanyJobController : ControllerBase
    {
        private CompanyJobLogic _logic;

        public CompanyJobController()
        {
            EFGenericRepository<CompanyJobPoco> repo = new EFGenericRepository<CompanyJobPoco>();
            _logic = new CompanyJobLogic(repo);
        }

        [HttpGet]
        [Route("job/{companyJobId}")]
        [ProducesResponseType(typeof(CompanyJobPoco),200)]
        public ActionResult GetCompanyJob(Guid companyJobId)
        {
            CompanyJobPoco companyJobPoco = _logic.Get(companyJobId);
            if (companyJobPoco == null)
                return NotFound();
            else
                return Ok(companyJobPoco);
        }

        [HttpGet]
        [Route("job")]
        [ProducesResponseType(typeof(List<CompanyJobPoco>),200)]
        public ActionResult GetCompanyJob()
        {
            List<CompanyJobPoco> companyJobPocos = _logic.GetAll();
            if (companyJobPocos == null)
                return NotFound();
            else
                return Ok(companyJobPocos);
        }

        [HttpPost]
        [Route("job")]
        public ActionResult PostCompanyJob([FromBody] CompanyJobPoco[] companyJobPocos)
        {
            _logic.Add(companyJobPocos);
            return Ok();
        }

        [HttpPut]
        [Route("job")]
        public ActionResult PutCompanyJob([FromBody] CompanyJobPoco[] companyJobPocos)
        {
            _logic.Update(companyJobPocos);
            return Ok();
        }

        [HttpDelete]
        [Route("job")]
        public ActionResult DeleteCompanyJob([FromBody] CompanyJobPoco[] companyJobPocos)
        {
            _logic.Delete(companyJobPocos);
            return Ok();
        }
    }
}