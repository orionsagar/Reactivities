using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Activities
{
    public class AList
    {
        public class Query : IRequest<List<Activity>> { }

        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext _dataContext;
            private readonly ILogger<AList> _logger;

            public Handler(DataContext dataContext, ILogger<AList> logger)
            {
                _dataContext = dataContext;
                _logger = logger;
            }
            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                //try
                //{
                //    for (var i = 0; i < 10; i++)
                //    {
                //        cancellationToken.ThrowIfCancellationRequested();
                //        await Task.Delay(1000, cancellationToken);
                //        _logger.LogInformation($"Task {i} has completed");
                //    }
                //}
                //catch (Exception ex) when (ex is TaskCanceledException)
                //{
                //    _logger.LogInformation($"Task was cancelled");
                //}
                return await _dataContext.Activities.ToListAsync(cancellationToken);
            }
        }
    }
}
