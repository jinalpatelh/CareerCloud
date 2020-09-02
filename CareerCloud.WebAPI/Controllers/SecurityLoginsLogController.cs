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
    [Route("api/careercloud/security/v1")]
    [ApiController]
    public class SecurityLoginsLogController : ControllerBase
    {
        private SecurityLoginsLogLogic _logic;
        public SecurityLoginsLogController()
        {
            EFGenericRepository<SecurityLoginsLogPoco> repo = new EFGenericRepository<SecurityLoginsLogPoco>();
            _logic = new SecurityLoginsLogLogic(repo);
        }

        [HttpGet]
        [Route("loginslog/{securityLoginsLogId}")]
        [ProducesResponseType(typeof(SecurityLoginsLogPoco), 200)]
        public ActionResult GetSecurityLoginLog(Guid securityLoginsLogId)
        {
            SecurityLoginsLogPoco securityLoginsLogPoco = _logic.Get(securityLoginsLogId);
            if (securityLoginsLogPoco == null)
                return NotFound();
            else
                return Ok(securityLoginsLogPoco);
        }

        [HttpGet]
        [Route("loginslog")]
        [ProducesResponseType(typeof(List<SecurityLoginsLogPoco>), 200)]
        public ActionResult GetSecurityLoginLog()
        {
            List<SecurityLoginsLogPoco> securityLoginsLogPocos = _logic.GetAll();
            if (securityLoginsLogPocos == null)
                return NotFound();
            else
                return Ok(securityLoginsLogPocos);
        }

        [HttpPost]
        [Route("loginslog")]
        public ActionResult PostSecurityLoginLog([FromBody] SecurityLoginsLogPoco[] securityLoginsLogPocos)
        {
            _logic.Add(securityLoginsLogPocos);
            return Ok();
        }

        [HttpPut]
        [Route("loginslog")]
        public ActionResult PutSecurityLoginLog([FromBody] SecurityLoginsLogPoco[] securityLoginsLogPocos)
        {
            _logic.Update(securityLoginsLogPocos);
            return Ok();
        }

        [HttpDelete]
        [Route("loginslog")]
        public ActionResult DeleteSecurityLoginLog([FromBody] SecurityLoginsLogPoco[] securityLoginsLogPocos)
        {
            _logic.Delete(securityLoginsLogPocos);
            return Ok();
        }

    }
}