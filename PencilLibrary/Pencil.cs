using Microsoft.IdentityModel.Tokens;

namespace PencilLibrary
{
    public class Pencil
    {

		#region Properties
		public int PencilId { get; set; }
		public string Type { get; set; }
		public string Brand { get; set; }
		public double Thickness { get; set; }
		public double Length { get; set; }
		public double Price { get; set; }

		#endregion

		#region Constructor
		public Pencil(string type, string brand, double thickness, double length, double price)
		{
			if (type.IsNullOrEmpty())
			{
				throw new ArgumentNullException("The type cannot be null or empty");
			}
			if (type.Length > 2)
			{
				throw new ArgumentOutOfRangeException("The type cannot be more than two characters");
			}
			if (brand.IsNullOrEmpty())
			{
				throw new ArgumentNullException("The type cannot be null or empty");
			}
			if (brand.Length > 15)
			{
				throw new ArgumentOutOfRangeException("The brand name may not exceed 15 characters");
			}
			if (thickness < 0.2 || thickness > 2)
			{
				throw new ArgumentOutOfRangeException("The thickness may not be less than 0.2 cm and more than 2 cm");
			}
			if (length < 7 || length > 20)
			{
				throw new ArgumentOutOfRangeException("The length of the pencil may not be less than 7 cm or more than 20 cm");
			}
			if (price <= 0)
			{
				throw new ArgumentOutOfRangeException("The price cannot be less than or equal to null");
			}
			Type = type;
			Brand = brand;
			Thickness = thickness;
			Length = length;
			Price = price;
		}
		#endregion

		#region Methods

		public override string ToString()
		{
			return $"Type: {Type}\nBrand: {Brand}\nThickness: {Thickness}\nLength: {Length}\nPrice: {Price}";
		}

		#endregion
	}
}
