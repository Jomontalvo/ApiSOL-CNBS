using System;
using Microsoft.EntityFrameworkCore;
using SolCnbs.Common.Models.Entities;

namespace SolCnbs.Data.Context;

public class SolDbContext(DbContextOptions<SolDbContext> options) : DbContext( options )
{
    public virtual DbSet<TemplateOption> TemplateOption { get; set; }
    public virtual DbSet<Template> Template { get; set; }
    public virtual DbSet<ProcedureType> ProcedureType { get; set; }
}
