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
    [Route("api/careercloud/applicant/v1/")]
    [ApiController]
    public class ApplicantProfileController : ControllerBase
    {
        private ApplicantProfileLogic _logic;
        public ApplicantProfileController()
        {
            EFGenericRepository<ApplicantProfilePoco> repo = new EFGenericRepository<ApplicantProfilePoco>();
            _logic = new ApplicantProfileLogic(repo);
        }

        [HttpGet]
        [Route("profile/{applicantProfileId}")]
        [ProducesResponseType(typeof(ApplicantProfilePoco),200)]
        public ActionResult GetApplicantProfile(Guid applicantProfileId)
        {
            ApplicantProfilePoco applicantProfile = _logic.Get(applicantProfileId);
            if (applicantProfile == null)
                return NotFound();
            else
                return Ok(applicantProfile);
        }
        [HttpGet]
        [Route("profile")]
        [ProducesResponseType(typeof(List<ApplicantJobApplicationPoco>),200)]
        public ActionResult GetApplicantProfile()
        {
            List<ApplicantProfilePoco> applicantProfiles = _logic.GetAll();
            if (applicantProfiles == null)
                return NotFound();
            else
                return Ok(applicantProfiles);
        }

        [HttpPost]
        [Route("profile")]
        public ActionResult PostApplicantProfile([FromBody] ApplicantProfilePoco[] applicantProfilePocos)
        {
            _logic.Add(applicantProfilePocos);
            return Ok();
        }

        [HttpPut]
        [Route("profile")]
        public ActionResult PutApplicantProfile([FromBody] ApplicantProfilePoco[] applicantProfilePocos)
        {
            _logic.Update(applicantProfilePocos);
            return Ok();
        }

        [HttpDelete]
        [Route("profile")]
        public ActionResult DeleteApplicantProfile([FromBody] ApplicantProfilePoco[] applicantProfilePocos)
        {
            _logic.Delete(applicantProfilePocos);
            return Ok();
        }
    }
}