using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PencilLibrary
{
	public class PencilRepository : IPencilRepository
	{
		#region Instance Fields
		private List<Pencil> _pencils;
		#endregion

		#region Properties
		public int Count { get { return _pencils.Count; } }
		#endregion

		#region Constructor
		public PencilRepository()
		{
			_pencils = new List<Pencil>();
		}

		#endregion

		#region Methods
		public Pencil Add(Pencil pencil)
		{
			pencil.PencilId = _pencils.Count + 1;
			_pencils.Add(pencil);
			return pencil;
		}

		public Pencil Delete(int id)
		{
			Pencil pencil = GetById(id);
			if (pencil != null)
			{
				_pencils.Remove(pencil);
			}
			return pencil;
		}

		public Pencil Update(int id, Pencil pencilData)
		{
			Pencil item = GetById(id);
			if (item != null)
			{
				item.Type = pencilData.Type;
				item.Thickness = pencilData.Thickness;
				item.Brand = pencilData.Brand;
				item.Length = pencilData.Length;
				item.Price = pencilData.Price;
				_pencils[_pencils.IndexOf(item)] = item;
				return pencilData;
			}
			return null;
		}

		public Pencil GetById(int id)
		{
			Pencil item = null;
			foreach (Pencil pencil in _pencils)
			{
				if (pencil.PencilId == id)
				{
					item = pencil;
				}
			}
			return item;
		}

		public List<Pencil> GetAll()
		{
			return _pencils;
		}

		public IEnumerable<Pencil> Get(string? type, string? brand, double? thickness, double? length, double? price, string? sortBy)
		{
			if (type != null)
			{
				_pencils = _pencils.Where(x => x.Type != null && x.Type.StartsWith(type, StringComparison.OrdinalIgnoreCase)).ToList();
			}
			if (brand != null)
			{
				_pencils = _pencils.Where(x => x.Brand != null && x.Brand.StartsWith(brand, StringComparison.OrdinalIgnoreCase)).ToList();
			}
			if (price != null)
			{
				_pencils = _pencils.Where(x => x.Price <= price).ToList();
			}
			if (sortBy != null)
			{
				if (sortBy.Equals("brand", StringComparison.OrdinalIgnoreCase))
				{
					_pencils = _pencils.OrderBy(x => x.Brand).ToList();
				}
				else if (sortBy.Equals("price", StringComparison.OrdinalIgnoreCase))
				{
					_pencils = _pencils.OrderBy(x => x.Price).ToList();
				}
				else if (sortBy.Equals("thickness", StringComparison.OrdinalIgnoreCase))
				{
					_pencils = _pencils.OrderBy(x => x.Thickness).ToList();
				}
				else if (sortBy.Equals("length", StringComparison.OrdinalIgnoreCase))
				{
					_pencils = _pencils.OrderBy(x => x.Length).ToList();
				}
			}
			return _pencils;
		}
		#endregion
	}
}
