using PencilLibrary;

namespace PencilTests
{
	[TestClass]
	public sealed class PencilConstructorTests
	{
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void TestBrandName()
		{
			Pencil pencil = new Pencil("HB", "Faber-Castell XXLL", 1.5, 10, 20);

			Assert.Fail();

		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void TestThickness()
		{
			Pencil pencil = new Pencil("HB", "Crayola", 2.5, 10, 20);

			Assert.Fail();

		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void TestLength()
		{
			Pencil pencil = new Pencil("HB", "Crayola", 1.5, 20, 20);

			Assert.Fail();

		}
	}
}
