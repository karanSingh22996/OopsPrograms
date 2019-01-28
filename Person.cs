//-----------------------------------------------------------------------
// <copyright file="Person.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace OopsPrograms
{
    /// <summary>
    /// Person class have all the attributes of a person
    /// </summary>
    public class Person
    {
        /// <summary>
        /// The first name
        /// </summary>
        private string firstName;

        /// <summary>
        /// The last name
        /// </summary>
        private string lastName;

        /// <summary>
        /// The add
        /// </summary>
        private Address add;

        /// <summary>
        /// The phone number
        /// </summary>
        private string phoneNum;

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        public Person()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="add">The add.</param>
        /// <param name="phoneNum">The phone number.</param>
        public Person(string firstName, string lastName, Address add, string phoneNum)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.add = add;
            this.phoneNum = phoneNum;
        }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get => this.firstName; set => this.firstName = value; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get => this.lastName; set => this.lastName = value; }

        /// <summary>
        /// Gets or sets the add.
        /// </summary>
        /// <value>
        /// The add.
        /// </value>
        public Address Add { get => this.add; set => this.add = value; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        public string PhoneNum { get => this.phoneNum; set => this.phoneNum = value; }
    }
}
