using PencilLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PencilTests
{
	[TestClass]
	public sealed class PencilRepositoryTests
	{
		[TestMethod]
		public void TestAddPencil()
		{
			// Arrange
			PencilRepository repo1 = new PencilRepository();
			Pencil pencil1 = new Pencil("HB", "Crayola", 1.8, 12.5, 25);

			// Act
			int countBefore = repo1.Count;
			repo1.Add(pencil1);
			int countAfter = repo1.Count;

			// Assert
			Assert.AreEqual(countBefore + 1, countAfter);

		}

		[TestMethod]
		public void TestUpdatePencil()
		{
			// Arrange
			PencilRepository repo2 = new PencilRepository();
			Pencil pencil2 = new Pencil("HB", "Crayola", 1.8, 12.5, 25);
			Pencil newPencil2 = new Pencil("B", "Crayola", 1.8, 12.5, 25);

			// Act
			Pencil p1 = repo2.Add(pencil2);
			Pencil p2 = repo2.Update(pencil2.PencilId, newPencil2);

			// Assert
			Assert.AreNotEqual(p1.Type, p2.Type);

		}

		[TestMethod]
		public void TestDeletePencil()
		{
			// Arrange
			PencilRepository repo3 = new PencilRepository();
			Pencil pencil3 = new Pencil("HB", "Crayola", 1.8, 12.5, 25);

			// Act
			repo3.Add(pencil3);
			int countBefore = repo3.Count;
			repo3.Delete(1);
			int countAfter = repo3.Count;

			// Assert
			Assert.AreEqual(countBefore, countAfter + 1);

		}
	}
}
