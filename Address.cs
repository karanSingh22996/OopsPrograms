//-----------------------------------------------------------------------
// <copyright file="Address.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace OopsPrograms
{
    /// <summary>
    /// all fields are private
    /// </summary>
    public class Address
    {
        /// <summary>
        /// The city
        /// </summary>
        private string city;

        /// <summary>
        /// The state
        /// </summary>
        private string state;

        /// <summary>
        /// The zip
        /// </summary>
        private string zip;

        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class.
        /// </summary>
        public Address()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class.
        /// </summary>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        /// <param name="zip">The zip.</param>
        public Address(string city, string state, string zip)
        {
            this.city = city;
            this.state = state;
            this.zip = zip;
        }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        public string City { get => this.city; set => this.city = value; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public string State { get => this.state; set => this.state = value; }

        /// <summary>
        /// Gets or sets the zip1.
        /// </summary>
        /// <value>
        /// The zip1.
        /// </value>
        public string Zip1 { get => this.zip; set => this.zip = value; }
    }
}
