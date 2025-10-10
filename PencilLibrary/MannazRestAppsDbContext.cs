using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PencilLibrary
{
	public class MannazRestAppsDbContext : DbContext
	{
		// Install this: NuGet package Microsoft.EntityFrameworkCore.SqlServer

		public MannazRestAppsDbContext(DbContextOptions<MannazRestAppsDbContext> options) : base(options)
		{
			
		}

		public DbSet<Pencil> Pencils { get; set; }
	}
}
