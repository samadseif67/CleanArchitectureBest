using GraphQL.Types;
using QraphQl_App.GQl.Mutations;
using QraphQl_App.GQl.Queries;

namespace QraphQl_App.GQl
{
    public class AppSchema:Schema
    {
        public AppSchema(AppQueries appQueries, AppMutations appMutations)
        {
            this.Query=appQueries;
            this.Mutation=appMutations;
        }
    }
}
