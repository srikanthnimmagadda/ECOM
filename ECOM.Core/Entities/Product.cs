using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECOM.Core.Entities
{
    public class Product : BaseEntity<int>
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PictureUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ProductType ProductType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ProductTypeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ProductBrand ProductBrand { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ProductBrandId { get; set; }
    }
}
