//-----------------------------------------------------------------------
// <copyright file="StockModel5.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace OopsPrograms
{
    /// <summary>
    /// Stock model5 class have all the private member and to access them get set methods are used
    /// </summary>
    public class StockModel5
    {
        /// <summary>
        /// The identifier
        /// </summary>
        private int id;

        /// <summary>
        /// The name
        /// </summary>
        private string name;

        /// <summary>
        /// The number of share
        /// </summary>
        private int numberOfShare;

        /// <summary>
        /// The price per share
        /// </summary>
        private int pricePerShare;

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get => this.id; set => this.id = value; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get => this.name; set => this.name = value; }

        /// <summary>
        /// Gets or sets the price per share.
        /// </summary>
        /// <value>
        /// The price per share.
        /// </value>
        public int PricePerShare { get => this.pricePerShare; set => this.pricePerShare = value; }

        /// <summary>
        /// Gets or sets the number of share.
        /// </summary>
        /// <value>
        /// The number of share.
        /// </value>
        public int NumberOfShare { get => this.numberOfShare; set => this.numberOfShare = value; }
    }
}
