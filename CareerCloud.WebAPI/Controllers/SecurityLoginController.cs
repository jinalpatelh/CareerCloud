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
    public class SecurityLoginController : ControllerBase
    {
        private SecurityLoginLogic _logic;

        public SecurityLoginController()
        {
            EFGenericRepository<SecurityLoginPoco> repo = new EFGenericRepository<SecurityLoginPoco>();
            _logic = new SecurityLoginLogic(repo);
        }

        [HttpGet]
        [Route("login/{securityLoginId}")]
        [ProducesResponseType(typeof(SecurityLoginPoco), 200)]
        public ActionResult GetSecurityLogin(Guid securityLoginId)
        {
            SecurityLoginPoco securityLoginPoco = _logic.Get(securityLoginId);
            if (securityLoginPoco == null)
                return NotFound();
            else
                return Ok(securityLoginPoco);
        }

        [HttpGet]
        [Route("login")]
        [ProducesResponseType(typeof(List<SecurityLoginPoco>), 200)]
        public ActionResult GetSecurityLogin()
        {
            List<SecurityLoginPoco> securityLoginPocos = _logic.GetAll();
            if (securityLoginPocos == null)
                return NotFound();
            else
                return Ok(securityLoginPocos);
        }

        [HttpPost]
        [Route("login")]
        public ActionResult PostSecurityLogin([FromBody] SecurityLoginPoco[] securityLoginPocos)
        {
            _logic.Add(securityLoginPocos);
            return Ok();
        }

        [HttpPut]
        [Route("login")]
        public ActionResult PutSecurityLogin([FromBody] SecurityLoginPoco[] securityLoginPocos)
        {
            _logic.Update(securityLoginPocos);
            return Ok();
        }

        [HttpDelete]
        [Route("login")]
        public ActionResult DeleteSecurityLogin([FromBody] SecurityLoginPoco[] securityLoginPocos)
        {
            _logic.Delete(securityLoginPocos);
            return Ok();
        }

    }
}