//-----------------------------------------------------------------------
// <copyright file="StockModel.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace OopsPrograms
{
    using System.ComponentModel.DataAnnotations;
    public class StockModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Range(1,10,ErrorMessage="id must be in range 1 to 10")]
        public int id { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Required (ErrorMessage="Name is Required")]
        public string name { get; set; }

        /// <summary>
        /// Gets or sets the available share.
        /// </summary>
        /// <value>
        /// The available share.
        /// </value>
        [Range(1, 1000, ErrorMessage = "availableShare must be in range 1 to 1000")]
        public int availableShares { get; set; }
        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        [Range(1, 1000, ErrorMessage = "price must be in range 1 to 1000")]
        public int price { get; set; }

    }
}
