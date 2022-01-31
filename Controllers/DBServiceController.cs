using DBApi.Attributes;
using DBApi.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBApi.Controllers
{
    //[ApiKey]
    [ApiController]
    [Route("[controller]")]
    public class DBServiceController : ControllerBase
    {
        private IDBApiService _dbService;
        public DBServiceController(IDBApiService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("getMaxAmout/{year}")]
        public IActionResult getMaxAmout(int year)
        {
            try
            {
                return Ok(_dbService.GetHighestByYear(year));
            }
            catch(Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpGet("getDataByCodeAndRowNum/{lstCode}/{rowNum}")]
        public IActionResult getDataByCodeAndRowNum(string lstCode, int rowNum)
        {
            try
            {
                return Ok(_dbService.GetData(lstCode,rowNum));
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpGet("getAgentByYear/{amountOrder}/{year}")]
        public IActionResult getAgentByYear(int amountOrder, int year)
        {
            try
            {
                return Ok(_dbService.GetAgentsByYear(amountOrder, year));
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
    }
}
