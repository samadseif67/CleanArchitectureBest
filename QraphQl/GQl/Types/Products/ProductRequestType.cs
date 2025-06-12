using GraphQL.Types;

namespace QraphQl_App.GQl.Types.Products
{
    public class ProductRequestType:InputObjectGraphType
    {
        public ProductRequestType()
        {
            Name=nameof(ProductRequestType);
            Field<IdGraphType>("id");
            Field<StringGraphType>("name");
        }

    }
}
