using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolCnbs.Data.Context;

public class CodesDbContext(DbContextOptions<CodesDbContext> options) : DbContext(options)
{
}
