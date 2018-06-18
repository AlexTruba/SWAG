namespace SWAG.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using SWAG.SaveService;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ILogger _logger;
        private readonly ISaveProvider _saveProvider;
        public ValuesController(ILogger<ValuesController> logger, ISaveProvider saveProvider)
        {
            _logger = logger;
            _saveProvider = saveProvider;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            _logger.LogInformation("Send get request with id: {0}", id);
            double? result;
            try
            {
                result = _saveProvider.GetResult(id);
                if (result.HasValue)
                {
                    _logger.LogInformation("Find value {1} for id: {0}", id, result.Value);
                    return Ok(result.Value);
                }
                else
                {
                    _logger.LogInformation("Value not found for id: {0}", id);
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                _logger.LogError(message: "Failed in ValuesController. method: Get", exception: e);
                return BadRequest(e.Message);
            }

        }

        // POST api/values
        [HttpPost("calc")]
        public async Task<ActionResult> Calc([FromBody]OperationDTO data)
        {
            _logger.LogInformation("Start calc for data: {0}", data);
            Guid id;
            try
            {

                id = await _saveProvider.Save(data);
                _logger.LogInformation("Finish calc for data: {0}, operation id {1}", data, id);
                return Ok(id);

            }
            catch (Exception e)
            {
                _logger.LogError(message: "Failed in ValuesController. method: Calc", exception: e);
                return BadRequest(e.Message);
            }

        }
    }
}
