using GraphQL.Types;
using QraphQl_App.DTO;

namespace QraphQl_App.GQl.Types.Products
{
    public class ProductResponseType:ObjectGraphType<ProductDTO>
    {
        public ProductResponseType()
        {
            Field(x => x.id, type: typeof(IdGraphType));
            Field(x => x.name, type: typeof(StringGraphType));
        }
    }
}
