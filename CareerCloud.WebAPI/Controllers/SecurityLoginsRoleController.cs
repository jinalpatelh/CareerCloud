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
    public class SecurityLoginsRoleController : ControllerBase
    {
        private SecurityLoginsRoleLogic _logic;

        public SecurityLoginsRoleController()
        {
            EFGenericRepository<SecurityLoginsRolePoco> repo = new EFGenericRepository<SecurityLoginsRolePoco>();
            _logic = new SecurityLoginsRoleLogic(repo);
        }

        [HttpGet]
        [Route("loginsrole/{securityLoginsRoleId}")]
        [ProducesResponseType(typeof(SecurityLoginsRolePoco), 200)]
        public ActionResult GetSecurityLoginsRole(Guid securityLoginsRoleId)
        {
            SecurityLoginsRolePoco securityLoginsRolePoco = _logic.Get(securityLoginsRoleId);
            if (securityLoginsRolePoco == null)
                return NotFound();
            else
                return Ok(securityLoginsRolePoco);
        }

        [HttpGet]
        [Route("loginsrole")]
        [ProducesResponseType(typeof(List<SecurityLoginsRolePoco>), 200)]
        public ActionResult GetSecurityLoginsRole()
        {
            List<SecurityLoginsRolePoco> securityLoginsRolePocos = _logic.GetAll();
            if (securityLoginsRolePocos == null)
                return NotFound();
            else
                return Ok(securityLoginsRolePocos);
        }

        [HttpPost]
        [Route("loginsrole")]
        public ActionResult PostSecurityLoginRole([FromBody] SecurityLoginsRolePoco[] securityLoginsRolePocos)
        {
            _logic.Add(securityLoginsRolePocos);
            return Ok();
        }

        [HttpPut]
        [Route("loginsrole")]
        public ActionResult PutSecurityLoginsRole([FromBody] SecurityLoginsRolePoco[] securityLoginsRolePocos)
        {
            _logic.Update(securityLoginsRolePocos);
            return Ok();
        }

        [HttpDelete]
        [Route("loginsrole")]
        public ActionResult DeleteSecurityLoginRole([FromBody] SecurityLoginsRolePoco[] securityLoginsRolePocos)
        {
            _logic.Delete(securityLoginsRolePocos);
            return Ok();
        }

    }
}