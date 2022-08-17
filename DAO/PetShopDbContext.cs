using Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DAO
{
    //Install-Package Microsoft.EntityFrameworkCore.SqlServer - DAO
    //Install-Package Microsoft.EntityFrameworkCore.Tools  -  DAO 
    //Install-Package Microsoft.EntityFrameworkCore.Design - PRESENTATION LAYER
    public class PetShopDbContext : DbContext
    {
        //DbSets funcionam como se fossem o DAO do Pet, permitindo realizar todas as operações
        //SQL para a tabela PET mexendo nessa propriedade.
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Cliente> Clientes { get; set; }


        public PetShopDbContext(DbContextOptions<PetShopDbContext> ctx):base(ctx)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Assembly no contexto do .NET
            //Carrega os map config que tão criado dentro do projeto (assembly) DAO 
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }


    }
}