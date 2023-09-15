using AutoMapper;
using FIFA.Application.Footballers.Commands.CreateFootballer;
using FIFA.Application.Footballers.Commands.DeleteFootballer;
using FIFA.Application.Footballers.Commands.UpdateFootballer;
using FIFA.Application.Footballers.Queries.GetFootballer;
using FIFA.Application.Footballers.Queries.GetFootballersList;
using FIFA.WebApi.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FIFA.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class FootballerController : BaseController
    {
        private readonly IMapper _mapper;

        public FootballerController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<FootballersListVm>> GetAll()
        {
            var query = new GetFootballersListQuery();

            var vm = await Mediator.Send(query);

            return Ok(vm);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FootballerVm>> Get(Guid id)
        {
            var query = new GetFootballerQuery
            {
                Id = id
            };

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateFootballerDto createFootballerDto)
        {
            var command = _mapper.Map<CreateFootballerCommand>(createFootballerDto);

            var footballerId = await Mediator.Send(command);

            return Ok(footballerId);
        }

        [HttpPut]
        public async Task<IActionResult> Updare([FromBody] UpdateFootballerDto updateFootballerDto)
        {
            var command = _mapper.Map<UpdateFootballerCommand>(updateFootballerDto);

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteFootballerCommand
            {
                Id= id  
            };

            await Mediator.Send(command);

            return NoContent();
        }
    }
}
