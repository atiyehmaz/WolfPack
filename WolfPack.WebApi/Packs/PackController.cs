using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WolfPack.Application.Packs;
using WolfPack.Contract.Packs.Commands;

namespace WolfPack.WebApi.Packs
{
    [Route("api/v1/Packs")]
    [ApiController]
    public class PackController : ControllerBase
    {
        private readonly IPackApplicationService _packApplicationService;
        private readonly ILogger<PackController> _logger;

        public PackController(IPackApplicationService packApplicationService, ILogger<PackController> logger)
        {
            _packApplicationService = packApplicationService;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Create(CreatePackCommandDto createPackCommandDto)
        {
            _packApplicationService.Create(createPackCommandDto.ToCreatePackCommand());

            return Ok();
        }
        
        [HttpPut]
        [Route("{id}")]
        public IActionResult Edit(Guid id, [FromBody] EditPackCommandDto editPackommandDto)
        {
            editPackommandDto.Id = id;
            _packApplicationService.Edit(editPackommandDto.ToEditPackCommand());

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Remove(Guid id)
        {
            _packApplicationService.Remove(id);

            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {
            var wolf = _packApplicationService.Get(id);

            return Ok(new { wolf });
        }

        [HttpGet]
        [Route("GetByName/{name}")]
        public IActionResult GetByCode(string name)
        {
            var wolf = _packApplicationService.GetByName(name);

            return Ok(new { wolf });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var packs = _packApplicationService.GetAll();

            return Ok(new { packs });
        }
        
        
        [HttpPost]
        [Route("{id}/wolves")]
        public IActionResult AddWolf(Guid id, [FromBody] AddWolfToPackCommandDto addWolfToPackCommandDto)
        {
            addWolfToPackCommandDto.Id = id;
            _packApplicationService.AddWolfToPack(addWolfToPackCommandDto.ToAddPersonageToGroupCommand());

            return Ok();
        }
    }
}