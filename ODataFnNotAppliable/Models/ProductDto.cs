using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODataFnNotAppliable.Models
{
    /// <summary>
    /// Represents an hypothetical product
    /// </summary>
    public class ProductDto
    {
        /// <summary>
        /// Gets/Sets the product's identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets/Sets the product's localized names
        /// </summary>
        public virtual ODataNamedValueDictionary<string> Name { get; set; }

        /// <summary>
        /// Gets/Sets the list of tags
        /// </summary>
        public virtual List<string> Tags { get; set; }
    }
}
