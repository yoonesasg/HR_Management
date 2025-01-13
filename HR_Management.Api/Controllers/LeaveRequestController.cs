 using HR_Management.Application.DTOs.LeaveRequest;
 using HR_Management.Application.Features.LeaveRequests.Requests.Commands;
 using HR_Management.Application.Features.LeaveRequests.Requests.Queries;
 using MediatR;
 using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR_Management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LeaveRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<LeaveRequestController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveRequestListDTO>>> Get()
        {
            var leaveRequests = await _mediator.Send(new GetLeaveRequestsListRequest());
            return Ok(leaveRequests);
        }

        // GET api/<LeaveRequestController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequestDTO>> Get(int id)
        {
            var leaveRequest = await _mediator.Send(new GetLeaveRequestDetailRequest{Id = id});
            return Ok(leaveRequest);
        }

        // POST api/<LeaveRequestController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateLeaveRequestDTO leaveRequest)
        {
            var command = new CreateLeaveRequestCommand { CreateLeaveRequestDTO = leaveRequest };
            var responce = await _mediator.Send(command);
            return Ok(responce);
        }

        // PUT api/<LeaveRequestController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateLeaveRequestDTO leaveRequest)
        {
            var command = new UpdateLeaveRequestCommand { UpdateLeaveRequestDTO = leaveRequest };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<LeaveRequestController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveRequestCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
