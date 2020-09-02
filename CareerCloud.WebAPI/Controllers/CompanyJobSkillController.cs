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
    public class CompanyJobSkillController : ControllerBase
    {
        private CompanyJobSkillLogic _logic;

        public CompanyJobSkillController()
        {
            EFGenericRepository<CompanyJobSkillPoco> repo = new EFGenericRepository<CompanyJobSkillPoco>();
            _logic = new CompanyJobSkillLogic(repo);
        }

        [HttpGet]
        [Route("jobskill/{companyJobSkillId}")]
        [ProducesResponseType(typeof(CompanyJobSkillPoco),200)]
        public ActionResult GetCompanyJobSkill(Guid companyJobSkillId)
        {
            CompanyJobSkillPoco companyJobSkillPoco = _logic.Get(companyJobSkillId);
            if (companyJobSkillPoco == null)
                return NotFound();
            else
                return Ok(companyJobSkillPoco);
        }

        [HttpGet]
        [Route("jobskill")]
        [ProducesResponseType(typeof(List<CompanyJobSkillPoco>),200)]
        public ActionResult GetCompanyJobSkill()
        {
            List<CompanyJobSkillPoco> companyJobSkillPocos = _logic.GetAll();
            if (companyJobSkillPocos == null)
                return NotFound();
            else
                return Ok(companyJobSkillPocos);
        }

        [HttpPost]
        [Route("jobskill")]
        public ActionResult PostCompanyJobSkill([FromBody] CompanyJobSkillPoco[] companyJobSkillPocos)
        {
            _logic.Add(companyJobSkillPocos);
            return Ok();
        }

        [HttpPut]
        [Route("jobskill")]
        public ActionResult PutCompanyJobSkill([FromBody] CompanyJobSkillPoco[] companyJobSkillPocos)
        {
            _logic.Update(companyJobSkillPocos);
            return Ok();
        }

        [HttpDelete]
        [Route("jobskill")]
        public ActionResult DeleteCompanyJobSkill([FromBody] CompanyJobSkillPoco[] companyJobSkillPocos)
        {
            _logic.Delete(companyJobSkillPocos);
            return Ok();
        }
    }
}