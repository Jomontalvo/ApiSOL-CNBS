using System;
using Microsoft.EntityFrameworkCore;

namespace SolCnbs.Data.Context;

public class SolDbContext(DbContextOptions<SolDbContext> options) : DbContext( options )
{

}
