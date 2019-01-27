//-----------------------------------------------------------------------
// <copyright file="CustomerModel.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace OopsPrograms
{
    public class CustomerModel
    {
        private string name;
        private int id;   
        private int valuation;

        public string Name { get => name; set => name = value; }

        public int Id { get => id; set => id = value; }

        public int Valuation { get => valuation; set => valuation = value; }
    }
}
