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
    public class SystemLanguageCodeController : ControllerBase
    {
        private SystemLanguageCodeLogic _logic;
        public SystemLanguageCodeController()
        {
            EFGenericRepository<SystemLanguageCodePoco> repo = new EFGenericRepository<SystemLanguageCodePoco>();
            _logic = new SystemLanguageCodeLogic(repo);
        }

        [HttpGet]
        [Route("languagecode/{systemLanguageCodeId}")]
        [ProducesResponseType(typeof(SystemLanguageCodePoco), 200)]
        public ActionResult GetSystemLanguageCode(string systemLanguageCodeId)
        {
            SystemLanguageCodePoco systemLanguageCodePoco = _logic.Get(systemLanguageCodeId);
            if (systemLanguageCodePoco == null)
                return NotFound();
            else
                return Ok(systemLanguageCodePoco);
        }

        [HttpGet]
        [Route("languagecode")]
        [ProducesResponseType(typeof(List<SystemLanguageCodePoco>), 200)]
        public ActionResult GetSystemLanguageCode()
        {
            List<SystemLanguageCodePoco> systemLanguageCodePocos = _logic.GetAll();
            if (systemLanguageCodePocos == null)
                return NotFound();
            else
                return Ok(systemLanguageCodePocos);
        }

        [HttpPost]
        [Route("languagecode")]
        public ActionResult PostSystemLanguageCode([FromBody] SystemLanguageCodePoco[] systemLanguageCodePocos)
        {
            _logic.Add(systemLanguageCodePocos);
            return Ok();
        }

        [HttpPut]
        [Route("languagecode")]
        public ActionResult PutSystemLanguageCode([FromBody] SystemLanguageCodePoco[] systemLanguageCodePocos)
        {
            _logic.Update(systemLanguageCodePocos);
            return Ok();
        }

        [HttpDelete]
        [Route("languagecode")]
        public ActionResult DeleteSystemLanguageCode([FromBody] SystemLanguageCodePoco[] systemLanguageCodePocos)
        {
            _logic.Delete(systemLanguageCodePocos);
            return Ok();
        }

    }
}