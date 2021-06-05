using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Activities
{
   public class ADelete
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _datacontext;
            

            public Handler(DataContext datacontext)
            {
                _datacontext = datacontext;
            }


            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _datacontext.Activities.FindAsync(request.Id);

                _datacontext.Remove(activity);

                await _datacontext.SaveChangesAsync();

                return Unit.Value;

            }
        }
    }
}
