using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PencilLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PencilTests
{
	[TestClass]
	[DoNotParallelize]
	public class PencilRepositoryTests
	{
		private const bool useDB = true;
		private static IPencilRepository _repo;

		[TestInitialize]
		public void init()
		{
			if (useDB)
			{
				var optionsBuilder = new DbContextOptionsBuilder<MannazRestAppsDbContext>();
				optionsBuilder.UseSqlServer(SecretDB.ConnectionStringSimply);
				MannazRestAppsDbContext _dbContext = new(optionsBuilder.Options);
				_dbContext.Database.ExecuteSqlRaw("TRUNCATE TABLE dbo.Pencils");
				_repo = new PencilRepositoryDB(_dbContext);
			}
			else
			{
				_repo = new PencilRepository();
			}
		}

		[TestMethod, Priority(1)]
		[DoNotParallelize]
		public void TestAddPencil()
		{
			Pencil crayolaH = _repo.Add(new Pencil("H", "Crayola", 1.6, 10.5, 20));
			Assert.IsTrue(crayolaH.PencilId > 0);
			IEnumerable<Pencil> allPencils = _repo.GetAll();
			Assert.AreEqual(1, allPencils.Count());

			Assert.ThrowsException<ArgumentNullException>(
				() => _repo.Add(new Pencil(null, "Crayola", 1.8, 10.5, 20)));
			Assert.ThrowsException<ArgumentNullException>(
				() => _repo.Add(new Pencil("", "Crayola", 1.8, 10.5, 20)));
			Assert.ThrowsException<ArgumentOutOfRangeException>(
				() => _repo.Add(new Pencil("HBB", "Crayola", 1.8, 10.5, 20)));
			Assert.ThrowsException<ArgumentNullException>(
				() => _repo.Add(new Pencil("H", null, 1.8, 10.5, 20)));
			Assert.ThrowsException<ArgumentNullException>(
				() => _repo.Add(new Pencil("H", "", 1.8, 10.5, 20)));
			Assert.ThrowsException<ArgumentOutOfRangeException>(
				() => _repo.Add(new Pencil("H", "Faber-Castell XXLL", 1.6, 10.5, 20)));
			Assert.ThrowsException<ArgumentOutOfRangeException>(
				() => _repo.Add(new Pencil("H", "Blackwing", 0.1, 10.5, 20)));
			Assert.ThrowsException<ArgumentOutOfRangeException>(
				() => _repo.Add(new Pencil("H", "Blackwing", 2.1, 10.5, 20)));
			Assert.ThrowsException<ArgumentOutOfRangeException>(
				() => _repo.Add(new Pencil("H", "Blackwing", 1.6, 21, 20)));
			Assert.ThrowsException<ArgumentOutOfRangeException>(
				() => _repo.Add(new Pencil("H", "Blackwing", 1.6, 6, 20)));
			Assert.ThrowsException<ArgumentOutOfRangeException>(
				() => _repo.Add(new Pencil("H", "Blackwing", 1.6, 21, 20)));
		}

		[TestMethod, Priority(2)]
		[DoNotParallelize]
		public void TestGetPencil()
		{
			_repo.Add(new Pencil("B", "Blackwing", 1.2, 18, 25));

			IEnumerable<Pencil> pencils = _repo.Get("B", "Blackwing", sortBy: "type");
			Assert.AreEqual(pencils.First().Type, "B");

			pencils = _repo.Get("B", "Blackwing", sortBy: "brand");
			Assert.AreEqual(pencils.First().Brand, "Blackwing");

			_repo.Add(new Pencil("B", "Blackwing", 0.5, 18, 20));

			pencils = _repo.Get("B", "Blackwing", sortBy: "thickness");
			Assert.AreEqual(pencils.First().Thickness, 0.5);

			_repo.Add(new Pencil("B", "Blackwing", 1.2, 8, 20));

			pencils = _repo.Get("B", "Blackwing", sortBy: "length");
			Assert.AreEqual(pencils.First().Length, 8);

			_repo.Add(new Pencil("B", "Blackwing", 1.2, 18, 5));

			pencils = _repo.Get("B", "Blackwing", sortBy: "price");
			Assert.AreEqual(pencils.First().Price, 5);

		}

		[TestMethod, Priority(3)]
		[DoNotParallelize]
		public void TestUpdatePencil()
		{
			Pencil pencil = _repo.Add(new Pencil("B", "Crayola", 1.8, 12.5, 25));
			Pencil? update = _repo.Update(pencil.PencilId, new Pencil("B", "Blackwing", 1.8, 14.5, 35));
			Assert.IsNotNull(update);

			Assert.AreEqual("Blackwing", update.Brand);
			Pencil? pencil2 = _repo.GetById(pencil.PencilId);
			Assert.AreEqual("Blackwing", pencil2.Brand);

			Assert.IsNull(_repo.Update(-1, new Pencil("B", "Crayola", 1.0, 10, 15)));
			Assert.ThrowsException<ArgumentNullException>(
				() => _repo.Update(pencil.PencilId, new Pencil("", "Blackwing", 1.8, 14.5, 35))
			);


		}

		[TestMethod]
		[DoNotParallelize]
		public void TestDeletePencil()
		{
			Pencil pencil = new Pencil("B", "Faber-Castell", 1.6, 18.5, 30);
			_repo.Add(pencil);
			int count1 = _repo.GetAll().Count;
			Pencil? removed = _repo.Delete(pencil.PencilId);
			int count2 = _repo.GetAll().Count;

			Assert.IsNotNull(removed);
			Assert.AreEqual("B", removed.Type);
			Assert.AreEqual(count1, count2 + 1);

		}
	}
}
