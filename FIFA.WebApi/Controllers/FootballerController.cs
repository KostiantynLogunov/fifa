using AutoMapper;
using FIFA.Application.Footballers.Commands.CreateFootballer;
using FIFA.Application.Footballers.Commands.DeleteFootballer;
using FIFA.Application.Footballers.Commands.UpdateFootballer;
using FIFA.Application.Footballers.Queries.GetFootballer;
using FIFA.Application.Footballers.Queries.GetFootballersList;
using FIFA.WebApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FIFA.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class FootballerController : BaseController
    {
        private readonly IMapper _mapper;

        public FootballerController(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Get the list of footballers
        /// </summary>
        /// <remarks>
        /// Simple request
        /// GET /footballer
        /// </remarks>
        /// <returns>
        /// Returns FootballersListVm
        /// </returns>
        /// <response code="200">Success</response>
        /// <response code="401">if the user is unauthorized</response>
        /// 
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<FootballersListVm>> GetAll()
        {
            var query = new GetFootballersListQuery();

            var vm = await Mediator.Send(query);

            return Ok(vm);

        }

        /// <summary>
        /// Get the footballer by Id
        /// </summary>
        /// <remarks>
        /// Simple request
        /// GET /footballer/C25E0231-5330-4398-B576-184D1C2EC255
        /// </remarks>
        /// <param name="id">Footballer id (guid)</param>
        /// <returns>Returns FootballerVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">if the user is unauthorized</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<FootballerVm>> Get(Guid id)
        {
            var query = new GetFootballerQuery
            {
                Id = id
            };

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        /// <summary>
        /// Create the footballer
        /// </summary>
        /// <remarks>
        /// POST /footbaler
        /// {
        ///     FirstName: "kos",
        ///     LastName: "bro"
        /// }
        /// </remarks>
        /// <param name="createFootballerDto">CreateFootballerDto object</param>
        /// <returns>returns id (guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">if the user is unauthorized</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateFootballerDto createFootballerDto)
        {
            var command = _mapper.Map<CreateFootballerCommand>(createFootballerDto);

            var footballerId = await Mediator.Send(command);

            return Ok(footballerId);
        }

        /// <summary>
        /// Update the footballer
        /// </summary>
        /// POST /footbaler
        /// {
        ///     Id: "C25E0231-5330-4398-B576-184D1C2EC255",
        ///     FirstName: "ko2s",
        ///     LastName: "bro2"
        /// }
        /// <param name="updateFootballerDto">UpdateFootballerDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">if the user is unauthorized</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut]
        public async Task<IActionResult> Updare([FromBody] UpdateFootballerDto updateFootballerDto)
        {
            var command = _mapper.Map<UpdateFootballerCommand>(updateFootballerDto);

            await Mediator.Send(command);

            return NoContent();
        }

        /// <summary>
        /// delete the footballer by Id
        /// </summary>
        /// <remarks>
        /// Simple request
        /// DELETE /footballer/C25E0231-5330-4398-B576-184D1C2EC255
        /// </remarks>
        /// <param name="id">id of the footballer (guid)</param>
        /// <returns></returns>
        /// <response code="204">Success</response>
        /// <response code="401">if the user is unauthorized</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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
