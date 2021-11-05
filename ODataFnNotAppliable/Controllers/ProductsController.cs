using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using ODataFnNotAppliable.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ODataFnNotAppliable.Controllers
{

    /// <summary>
    /// Represents the <see cref="Controller"/> used to manage products
    /// </summary>
    [Route("api/[controller]")]
    public class ProductsController
        : Controller
    {

        /// <summary>
        /// Initializes a new <see cref="ProductsController"/>
        /// </summary>
        public ProductsController() 
        {
            ProductDto shoe = new()
            {
                Id=1,
                Name= new(new Dictionary<string, string>() {
                    { "en", "Shoe" },
                    { "fr", "Chaussure" },
                }),
                Tags = new List<string>() {  "Foo" }
            };
            ProductDto hat = new()
            {
                Id = 2,
                Name = new(new Dictionary<string, string>() {
                    { "en", "Hat" },
                    { "fr", "Chapeau" },
                })
            };
            ProductDto scarf = new()
            {
                Id = 3,
                Name = new(new Dictionary<string, string>() {
                    { "en", "Scarf" },
                    { "fr", "Écharpe" },
                }),
                Tags = new List<string>()
            };
            this.Products = (new List<ProductDto>() {
                shoe,
                hat,
                scarf
            }).AsEnumerable();
        }

        /// <summary>
        /// Gets the <see cref="IAsyncEnumerable{TEntity}"/> used to manage <see cref="ProductDto"/>s
        /// </summary>
        protected IEnumerable<ProductDto> Products { get; }

        /// <summary>
        /// Lists or queries products
        /// </summary>
        /// <returns>A new <see cref="IEnumerable{T}"/> of matching products</returns>
        [HttpGet, EnableQuery(PageSize = 50)]
        [ProducesResponseType(typeof(IEnumerable<ProductDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            return this.Products.ToList();
        }

    }

}
