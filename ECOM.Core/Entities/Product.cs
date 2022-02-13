using System.ComponentModel.DataAnnotations;

namespace ECOM.Core.Entities
{
    public class Product
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(2000)]
        public string Description { get; set; }

        //public ProductType ProductType { get; set; }
        //public int ProductTypeId { get; set; }
        //public ProductBrand ProductBrand { get; set; }
        //public int ProductBrandId { get; set; }
    }
}
