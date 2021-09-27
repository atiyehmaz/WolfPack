using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WolfPack.Application.Wolves;
using WolfPack.Contract.Wolves.Commands;

namespace WolfPack.WebApi.Wolves
{
    [Route("api/v1/Wolves")]
    [ApiController]
    public class WolfController : ControllerBase
    {
        private readonly IWolfApplicationService _wolfApplicationService;
        private readonly ILogger<WolfController> _logger;

        public WolfController(IWolfApplicationService wolfApplicationService, ILogger<WolfController> logger)
        {
            _wolfApplicationService = wolfApplicationService;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Create(CreateWolfCommandDto createWolfCommandDto)
        {
            _wolfApplicationService.Create(createWolfCommandDto.ToCreateWolfCommand());

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Remove(Guid id)
        {
            _wolfApplicationService.Remove(id);

            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {
            var wolf = _wolfApplicationService.Get(id);

            return Ok(new { wolf });
        }

        [HttpGet]
        [Route("GetByCode/{code}")]
        public IActionResult GetByCode(string code)
        {
            var wolf = _wolfApplicationService.GetByCode(code);

            return Ok(new { wolf });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var wolves = _wolfApplicationService.GetAll();

            return Ok(new { wolves });
        }
    }
}