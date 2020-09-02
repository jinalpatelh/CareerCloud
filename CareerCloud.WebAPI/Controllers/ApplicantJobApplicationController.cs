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
    [Route("api/careercloud/applicant/v1")]
    [ApiController]
    public class ApplicantJobApplicationController : ControllerBase
    {
        private ApplicantJobApplicationLogic _logic;
        public ApplicantJobApplicationController()
        {
            EFGenericRepository<ApplicantJobApplicationPoco> repo = new EFGenericRepository<ApplicantJobApplicationPoco>();
            _logic = new ApplicantJobApplicationLogic(repo);
        }

        [HttpGet]
        [Route("jobapplication")]
        [ProducesResponseType(typeof(List<ApplicantJobApplicationPoco>), 200)]
        public ActionResult GetApplicantJobApplication()
        {
            List<ApplicantJobApplicationPoco> applicantJobApplications = _logic.GetAll();
            if (applicantJobApplications == null)
                return NotFound();
            else
                return Ok(applicantJobApplications);
        }

        [HttpGet]
        [Route("jobapplication/{applicationId}")]
        [ProducesResponseType(typeof(ApplicantJobApplicationPoco), 200)]
        public ActionResult GetApplicantJobApplication(Guid applicationId)
        {
            ApplicantJobApplicationPoco applicantJobApplication = _logic.Get(applicationId);
            if (applicantJobApplication == null)
                return NotFound();
            else
                return Ok(applicantJobApplication);
        }

        [HttpPost]
        [Route("jobapplication")]
        public ActionResult PostApplicantJobApplication([FromBody] ApplicantJobApplicationPoco[] applicantJobApplicationPocos)
        {
            _logic.Add(applicantJobApplicationPocos);
            return Ok();
        }

        [HttpPut]
        [Route("jobapplication")]
        public ActionResult PutApplicantJobApplication([FromBody] ApplicantJobApplicationPoco[] applicantJobApplicationPocos)
        {
            _logic.Update(applicantJobApplicationPocos);
            return Ok();
        }

        [HttpDelete]
        [Route("jobapplication")]
        public ActionResult DeleteApplicantJobApplication([FromBody] ApplicantJobApplicationPoco[] applicantJobApplicationPocos)
        {
            _logic.Delete(applicantJobApplicationPocos);
            return Ok();
        }
    }
}
