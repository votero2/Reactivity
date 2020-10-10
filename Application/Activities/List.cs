using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence; // extention to get access 
using Microsoft.EntityFrameworkCore;
// to the database

namespace Application.Activities
{
    public class List {
        public class Query : IRequest<List<Activity>> {

        }

        public class Handler : IRequestHandler<Query, List<Activity>> {
            

            //inialize the dataContext access 
            private readonly DataContext _context;
            //Handler controller
            public Handler (DataContext context) {

                _context = context;
            }

            //Implementation of Request Handler 
            public async Task<List<Activity>> Handle (Query request, CancellationToken cancellationToken) {
              
                //create a list of activities 
                var activities = await _context.Activities.ToListAsync ();

                return activities; // return type 
            }
        }
    }
}