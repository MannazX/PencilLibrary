using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PencilLibrary
{
	public class PencilRepositoryDB : IPencilRepository
	{
		private readonly MannazRestAppsDbContext _context;
		public int Count { get { return _context.Pencils.ToList().Count; } }

		public PencilRepositoryDB(MannazRestAppsDbContext dbContext)
		{
			_context = dbContext;
		}

		public Pencil Add(Pencil pencil)
		{
			pencil.Validate();
			pencil.PencilId = 0;
			_context.Pencils.Add(pencil);
			_context.SaveChanges();
			return pencil;
		}

		public Pencil? Delete(int id)
		{
			Pencil? pencil = GetById(id);
			if (pencil == null)
			{
				return null;
			}
			_context.Pencils.Remove(pencil);
			return pencil;
		}

		public IEnumerable<Pencil> Get(string? type, string? brand, double? thickness, double? length, double? price, string? sortBy)
		{
			IQueryable<Pencil> query = _context.Pencils.ToList().AsQueryable();
			if (type != null)
			{
				query = query.Where(x => x.Type.StartsWith(type));
			}
			if (brand != null)
			{
				query = query.Where(x => x.Brand.StartsWith(brand));
			}
			if (price != null)
			{
				query = query.Where(x => x.Price <= price);
			}
			if (sortBy != null)
			{
				sortBy = sortBy.ToLower();
				switch (sortBy)
				{
					case "brand":
					case "brand_asc":
						query = query.OrderBy(x => x.Brand);
						break;
					case "brand_desc":
						query = query.OrderByDescending(x => x.Brand);
						break;
					case "thickness":
					case "thickness_asc":
						query = query.OrderBy(x => x.Thickness);
						break;
					case "thickness_desc":
						query = query.OrderByDescending(x => x.Thickness);
						break;
					case "length":
					case "length_asc":
						query = query.OrderBy(x => x.Length);
						break;
					case "length_desc":
						query = query.OrderByDescending(x => x.Length);
						break;
					case "price":
					case "price_asc":
						query = query.OrderBy(x => x.Price);
						break;
					case "price_desc":
						query = query.OrderByDescending(x => x.Price);
						break;
				}
			}
			return query;
		}

		public List<Pencil> GetAll()
		{
			return _context.Pencils.ToList();
		}

		public Pencil? GetById(int id)
		{
			return _context.Pencils.FirstOrDefault(x => x.PencilId == id);
		}

		public Pencil? Update(int id, Pencil pencilData)
		{
			pencilData.Validate();
			Pencil? pencil = GetById(id);
			if (pencil == null)
			{
				return null;
			}
			pencil.Type = pencilData.Type;
			pencil.Brand = pencilData.Brand;
			pencil.Thickness = pencilData.Thickness;
			pencil.Length = pencilData.Length;
			pencil.Price = pencilData.Length;
			_context.SaveChanges();
			return pencil;
		}
	}
}
