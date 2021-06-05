using AutoMapper;
using Domain;
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
    public class AEdit
    {
        public class Command: IRequest
        {
            public  Activity Activity { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _datacontext;
            private readonly IMapper _mapper;

            public Handler(DataContext datacontext, IMapper mapper)
            {
                _datacontext = datacontext;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _datacontext.Activities.FindAsync(request.Activity.Id);

                _mapper.Map(request.Activity, activity);

                await _datacontext.SaveChangesAsync();

                return Unit.Value;
                
            }
        }
    }
}
