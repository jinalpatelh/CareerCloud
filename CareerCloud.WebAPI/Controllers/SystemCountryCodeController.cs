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
    [Route("api/careercloud/system/v1")]
    [ApiController]
    public class SystemCountryCodeController : ControllerBase
    {
        private SystemCountryCodeLogic _logic;
        public SystemCountryCodeController()
        {
            EFGenericRepository<SystemCountryCodePoco> repo = new EFGenericRepository<SystemCountryCodePoco>();
            _logic = new SystemCountryCodeLogic(repo);
        }

        [HttpGet]
        [Route("countrycode/{systemCountryCodeId}")]
        [ProducesResponseType(typeof(SystemCountryCodePoco), 200)]
        public ActionResult GetSystemCountryCode(string systemCountryCodeId)
        {
            SystemCountryCodePoco systemCountryCodePoco = _logic.Get(systemCountryCodeId);
            if (systemCountryCodePoco == null)
                return NotFound();
            else
                return Ok(systemCountryCodePoco);
        }

        [HttpGet]
        [Route("countrycode")]
        [ProducesResponseType(typeof(List<SystemCountryCodePoco>), 200)]
        public ActionResult GetSystemCountryCode()
        {
            List<SystemCountryCodePoco> systemCountryCodePocos = _logic.GetAll();
            if (systemCountryCodePocos == null)
                return NotFound();
            else
                return Ok(systemCountryCodePocos);
        }

        [HttpPost]
        [Route("countrycode")]
        public ActionResult PostSystemCountryCode([FromBody] SystemCountryCodePoco[] systemCountryCodePocos)
        {
            _logic.Add(systemCountryCodePocos);
            return Ok();
        }

        [HttpPut]
        [Route("countrycode")]
        public ActionResult PutSystemCountryCode([FromBody] SystemCountryCodePoco[] systemCountryCodePocos)
        {
            _logic.Update(systemCountryCodePocos);
            return Ok();
        }

        [HttpDelete]
        [Route("countrycode")]
        public ActionResult DeleteSystemCountryCode([FromBody] SystemCountryCodePoco[] systemCountryCodePocos)
        {
            _logic.Delete(systemCountryCodePocos);
            return Ok();
        }

    }
}