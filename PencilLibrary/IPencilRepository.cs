
namespace PencilLibrary
{
	public interface IPencilRepository
	{
		Pencil Add(Pencil pencil);
		Pencil Delete(int id);
		IEnumerable<Pencil> Get(string type, string brand, double? thickness = null, double? length = null, double? price = null, string? sortBy = null);
		List<Pencil> GetAll();
		Pencil GetById(int id);
		Pencil Update(int id, Pencil pencilData);
	}
}