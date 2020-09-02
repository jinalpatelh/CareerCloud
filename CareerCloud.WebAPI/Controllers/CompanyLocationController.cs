using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerCloud.ADODataAccessLayer;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/company/v1")]
    [ApiController]
    public class CompanyLocationController : ControllerBase
    {
        private CompanyLocationLogic _logic;
        public CompanyLocationController()
        {
            EFGenericRepository<CompanyLocationPoco> repo = new EFGenericRepository<CompanyLocationPoco>();
            _logic = new CompanyLocationLogic(repo);
        }

        [HttpGet]
        [Route("jobskill/{companyLocationId}")]
        [ProducesResponseType(typeof(CompanyJobSkillPoco), 200)]
        public ActionResult GetCompanyLocation(Guid companyLocationId)
        {
            CompanyLocationPoco companyLocationPoco = _logic.Get(companyLocationId);
            if (companyLocationPoco == null)
                return NotFound();
            else
                return Ok(companyLocationPoco);
        }

        [HttpGet]
        [Route("location")]
        [ProducesResponseType(typeof(List<CompanyLocationPoco>), 200)]
        public ActionResult GetCompanyLocation()
        {
            List<CompanyLocationPoco> companyLocationPocos = _logic.GetAll();
            if (companyLocationPocos == null)
                return NotFound();
            else
                return Ok(companyLocationPocos);
        }

        [HttpPost]
        [Route("location")]
        public ActionResult PostCompanyLocation([FromBody] CompanyLocationPoco[] companyLocationPocos)
        {
            _logic.Add(companyLocationPocos);
            return Ok();
        }

        [HttpPut]
        [Route("location")]
        public ActionResult PutCompanyLocation([FromBody] CompanyLocationPoco[] companyLocationPocos)
        {
            _logic.Update(companyLocationPocos);
            return Ok();
        }

        [HttpDelete]
        [Route("location")]
        public ActionResult DeleteCompanyLocation([FromBody] CompanyLocationPoco[] companyLocationPocos)
        {
            _logic.Delete(companyLocationPocos);
            return Ok();
        }


    }
}