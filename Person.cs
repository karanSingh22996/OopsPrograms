//-----------------------------------------------------------------------
// <copyright file="Person.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace OopsPrograms
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private Address add;
        private string phoneNum;
        public Person()
        {
        }

        public Person(string firstName, string lastName, Address add, string phoneNum)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.add = add;
            this.add = add;
        }

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public Address Add { get => add; set => add = value; }
        public string PhoneNum { get => phoneNum; set => phoneNum = value; }
    }
}
