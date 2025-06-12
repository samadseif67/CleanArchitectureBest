using GraphQL;
using GraphQL.Types;
using QraphQl_App.GQl.Types.Products;

namespace QraphQl_App.GQl.Mutations
{
    public static class ProductMutations
    {
        public static void ProductMutation(this ObjectGraphType schema)
        {
            schema.FieldAsync<ProductResponseType>(
               name: "AddProduct",
               description: "in use database",
               arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ProductRequestType>> { Name = "Product", Description = "Product input parameter" }),
               resolve: async context =>
               {
                  // var addProduct= context.GetArgument<>
                   return null;
               }
                 
                );
        }

    }
}
