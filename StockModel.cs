//-----------------------------------------------------------------------
// <copyright file="StockModel.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace OopsPrograms
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// stock model class have all the private member and to access them get set method is used
    /// </summary>
    public class StockModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Range(1, 10, ErrorMessage = "id must be in range 1 to 10")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the available share.
        /// </summary>
        /// <value>
        /// The available share.
        /// </value>
        [Range(1, 1000, ErrorMessage = "availableShare must be in range 1 to 1000")]
        public int AvailableShares { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        [Range(1, 1000, ErrorMessage = "price must be in range 1 to 1000")]
        public int Price { get; set; }
    }
}
