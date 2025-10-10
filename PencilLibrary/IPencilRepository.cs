
namespace PencilLibrary
{
	public interface IPencilRepository
	{
		int Count { get; }

		Pencil Add(Pencil pencil);
		Pencil Delete(int id);
		IEnumerable<Pencil> Get(string? type, string? brand, double? thickness, double? length, double? price, string? sortBy);
		List<Pencil> GetAll();
		Pencil GetById(int id);
		Pencil Update(int id, Pencil pencilData);
	}
}