using System;
using Microsoft.EntityFrameworkCore;
using SolCnbs.Common.Models.Entities;

namespace SolCnbs.Data.Context;

public class SolDbContext(DbContextOptions<SolDbContext> options) : DbContext( options )
{
    public virtual DbSet<TemplateOption> TemplateOptions { get; set; }
    public virtual DbSet<Template> Templates { get; set; }
    public virtual DbSet<Procedure> Procedures { get; set; }
    public virtual DbSet<ProcedureType> ProcedureTypes { get; set; }
    public virtual DbSet<AdditionalData> AdditionalData { get; set; }
    
}
