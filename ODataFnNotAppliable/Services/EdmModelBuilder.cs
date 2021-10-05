using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using ODataFnNotAppliable.Models;

namespace ODataFnNotAppliable.Services
{

    /// <summary>
    /// Represents the default implementation of the <see cref="IEdmModelBuilder"/>
    /// </summary>
    public class EdmModelBuilder
        : IEdmModelBuilder
    {
        /// <inheritdoc/>
        public virtual IEdmModel Build()
        {
            ODataConventionModelBuilder builder = new();
            builder.EnableLowerCamelCase();
            builder.EntitySet<ProductDto>("Products");
            builder.AddComplexType(typeof(ODataNamedValueDictionary<string>));
            return builder.GetEdmModel();
        }
    }
}
