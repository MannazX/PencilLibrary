// See https://aka.ms/new-console-template for more information
using PencilLibrary;

Console.WriteLine("Hello, PencilLibrary!");

PencilRepository repo = new PencilRepository();
Pencil p1 = new Pencil("HB", "Crayola", 1.8, 12.5, 25);

repo.Add(p1);

Console.WriteLine();

foreach (Pencil pencil in repo.GetAll())
{
	Console.WriteLine(pencil);
}
Console.WriteLine();

Pencil newP = new Pencil("B", "Crayola", 1.8, 12.5, 20);

repo.Update(1, newP);

foreach (Pencil pencil in repo.GetAll())
{
	Console.WriteLine(pencil);
}
Console.WriteLine();

repo.Delete(1);

foreach (Pencil pencil in repo.GetAll())
{
	Console.WriteLine(pencil);
}
Console.WriteLine();
