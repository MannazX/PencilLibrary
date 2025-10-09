namespace PencilLibrary
{
    public class Pencil
    {
		#region
		private static int _counter = 0;
		private int _pencilId;
		#endregion

		#region Properties
		public int PencilId { get { return _pencilId; } }
		public string Type { get; set; }
		public string Brand { get; set; }
		public double Thickness { get; set; }
		public double Length { get; set; }
		public double Price { get; set; }

		#endregion

		#region Constructor
		public Pencil(string type, string brand, double thickness, double length, double price)
		{
			if (brand.Length > 15)
			{
				throw new ArgumentException("The brand name may not exceed 15 characters");
			}
			if (thickness > 2)
			{
				throw new ArgumentException("The thickness may not exceed 2 cm");
			}
			if (length > 15)
			{
				throw new ArgumentException("The length of the pencil may not exceed 15 cm");
			}
			_counter++;
			_pencilId = _counter;
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
