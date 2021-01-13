using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Delete
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Command>
        {
            public DataContext _Context { get; set; }
            public Handler(DataContext context)
            {
                _Context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                //Handler Logic
                var activity = await _Context.Activities.FindAsync(request.Id);
                if (activity == null)
                    throw new Exception("Could not Find Activity");

                _Context.Remove(activity);

                var success = await _Context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;
                throw new Exception("Problem Saving Changes");
            }
        }
    }
}