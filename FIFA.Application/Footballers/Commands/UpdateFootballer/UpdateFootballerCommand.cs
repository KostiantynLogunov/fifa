using MediatR;

namespace FIFA.Application.Footballers.Commands.UpdateFootballer
{
    public class UpdateFootballerCommand : IRequest
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
