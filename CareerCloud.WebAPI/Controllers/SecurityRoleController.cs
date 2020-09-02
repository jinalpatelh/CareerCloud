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
    public class SecurityRoleController : ControllerBase
    {
        private SecurityRoleLogic _logic;

        public SecurityRoleController()
        {
            EFGenericRepository<SecurityRolePoco> repo = new EFGenericRepository<SecurityRolePoco>();
            _logic = new SecurityRoleLogic(repo);
        }

        [HttpGet]
        [Route("role/{securityRoleId}")]
        [ProducesResponseType(typeof(SecurityRolePoco), 200)]
        public ActionResult GetSecurityRole(Guid securityRoleId)
        {
            SecurityRolePoco securityRolePoco = _logic.Get(securityRoleId);
            if (securityRolePoco == null)
                return NotFound();
            else
                return Ok(securityRolePoco);
        }

        [HttpGet]
        [Route("role")]
        [ProducesResponseType(typeof(List<SecurityRolePoco>), 200)]
        public ActionResult GetSecurityRole()
        {
            List<SecurityRolePoco> securityRolePocos = _logic.GetAll();
            if (securityRolePocos == null)
                return NotFound();
            else
                return Ok(securityRolePocos);
        }

        [HttpPost]
        [Route("role")]
        public ActionResult PostSecurityRole([FromBody] SecurityRolePoco[] securityRolePocos)
        {
            _logic.Add(securityRolePocos);
            return Ok();
        }

        [HttpPut]
        [Route("role")]
        public ActionResult PutSecurityRole([FromBody] SecurityRolePoco[] securityRolePocos)
        {
            _logic.Update(securityRolePocos);
            return Ok();
        }

        [HttpDelete]
        [Route("role")]
        public ActionResult DeleteSecurityRole([FromBody] SecurityRolePoco[] securityRolePocos)
        {
            _logic.Delete(securityRolePocos);
            return Ok();
        }

    }
}