using Microsoft.EntityFrameworkCore;
using Api.Models;

namespace Api.Repository
{
    public class FilmeRepository : DbContext
    {
        public FilmeRepository(DbContextOptions<FilmeRepository> opt) : base(opt)
        { 

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<EnderecoModel>()
                .HasOne(endereco => endereco.Cinema)
                .WithOne(Cinema => Cinema.Endereco)
                .HasForeignKey<CinemaModel>(Cinema => Cinema.EnderecoId);

            builder.Entity<CinemaModel>()
                .HasOne(cinema => cinema.Gerente)
                .WithMany(gerente => gerente.Cinemas)
                .HasForeignKey(cinema => cinema.GerenteId);

            builder.Entity<SessaoModel>()
                .HasOne(sessao => sessao.Filme)
                .WithMany(filme => filme.Sessoes)
                .HasForeignKey(sessao => sessao.FilmeId);

            builder.Entity<SessaoModel>()
                .HasOne(sessao => sessao.Cinema)
                .WithMany(cinema => cinema.Sessoes)
                .HasForeignKey(sessao => sessao.CinemaId);

            /*
             
            Caso não queria deletar em cascata (deletou Gerente, deleta Os cinemas vinculado a ele)
             builder.Entity<CinemaModel>()
                .HasOne(cinema => cinema.Gerente)
                .WithMany(gerente => gerente.Cinemas)
                .HasForeignKey(cinema => cinema.GerenteId).OnDelete(DeleteBehavior.Restrict);

            A criação do cinema permite gerente nulo.
            builder.Entity<CinemaModel>()
                .HasOne(cinema => cinema.Gerente)
                .WithMany(gerente => gerente.Cinemas)
                .HasForeignKey(cinema => cinema.GerenteId).IsRequired(false);
            
             */


        }
        public DbSet<FilmeModel> Filmes { get; set; }
        public DbSet<CinemaModel> Cinemas{ get; set; }
        public DbSet<EnderecoModel> Enderecos { get; set; }
        public DbSet<GerenteModel> Gerentes { get; set; }
        public DbSet<SessaoModel> Sessoes { get; set; }

}
}
