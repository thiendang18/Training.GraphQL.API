using GraphQL.Types;
using GraphQL.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.GraphQL.API.GraphQL.Queries;

namespace Training.GraphQL.API.GraphQL
{
    public class AppSchema: Schema
    {
        public AppSchema(IServiceProvider provider): base(provider)
        {
            Query = provider.GetRequiredService<AppQuery>();
            Mutation = provider.GetRequiredService<AppMutation>();
        }
    }
}
