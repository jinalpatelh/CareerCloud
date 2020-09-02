using System;
using System.Collections.Generic;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/applicant/v1")]
    [ApiController]
    public class ApplicantEducationController : ControllerBase
    {
        private ApplicantEducationLogic _logic;
        public ApplicantEducationController()
        {
            EFGenericRepository<ApplicantEducationPoco> repo = new EFGenericRepository<ApplicantEducationPoco>();
            _logic = new ApplicantEducationLogic(repo);
        }

        [HttpGet]
        [Route("education")]
        [ProducesResponseType(typeof(List<ApplicantEducationPoco>),200)]
        public ActionResult GetApplicantEducation()
        {
            List<ApplicantEducationPoco> applicantEducations = _logic.GetAll();
            if (applicantEducations == null)
                return NotFound();
            else
                return Ok(applicantEducations);
        }

        [HttpGet]
        [Route("education/{applicantEducationId}")]
        [ProducesResponseType(typeof(ApplicantEducationPoco),200)]
        public ActionResult GetApplicantEducation(Guid applicantEducationId)
        {
            ApplicantEducationPoco applicantEducation = _logic.Get(applicantEducationId);
            if (applicantEducation == null)
                return NotFound();
            else
                return Ok(applicantEducation);
        }

        [HttpPost]
        [Route("education")]
        public ActionResult PostApplicantEducation([FromBody] ApplicantEducationPoco[] applicantEducationPocos)
        {
            _logic.Add(applicantEducationPocos);
            return Ok();
        }

        [HttpPut]
        [Route("education")]
        public ActionResult PutApplicantEducation([FromBody] ApplicantEducationPoco[] applicantEducationPocos)
        {
            _logic.Update(applicantEducationPocos);
            return Ok();
        }

        [HttpDelete]
        [Route("education")]
        public ActionResult DeleteApplicantEducation([FromBody] ApplicantEducationPoco[] applicantEducationPocos)
        {
            _logic.Delete(applicantEducationPocos);
            return Ok();
        }
    }
}