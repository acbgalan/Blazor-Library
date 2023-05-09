using Microsoft.EntityFrameworkCore;

namespace Library.Server.Data
{
    public class ApplicationSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var accionAventura = new Category { Id = 1, Name = "Acción y Aventura" };
            var clasicos = new Category { Id = 2, Name = "Clásicos" };
            var comicNovelaGrafica = new Category { Id = 3, Name = "Cómic o novela gráfica" };
            var misterio = new Category { Id = 4, Name = "Detective y misterio" };
            var fantasia = new Category { Id = 5, Name = "Fantasía" };
            var ficcionHistorica = new Category { Id = 6, Name = "Ficción histórica" };
            var horror = new Category { Id = 7, Name = "Horror" };
            var romance = new Category { Id = 8, Name = "Romance" };
            var cienciaFiccion = new Category { Id = 9, Name = "Ciencia ficción" };
            var suspenseThriller = new Category { Id = 10, Name = "Suspense y Thriller" };
            var ficcionMujeres = new Category { Id = 11, Name = "Ficción de mujeres" };
            var biografías = new Category { Id = 12, Name = "Biografías y autobiografías" };
            var consultas = new Category { Id = 13, Name = "Libros de consultas" };
            var historia = new Category { Id = 14, Name = "Historia" };
            var poesia = new Category { Id = 15, Name = "Poesía" };

            modelBuilder.Entity<Category>().HasData(
                accionAventura,
                clasicos,
                comicNovelaGrafica,
                misterio,
                fantasia,
                ficcionHistorica,
                horror,
                romance,
                cienciaFiccion,
                suspenseThriller,
                ficcionMujeres,
                biografías,
                consultas,
                historia,
                poesia
                );

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "1984", Author = "George Orwell", Year = 1949, Prize = 7.95M, CategoryId = 2 },
                new Book { Id = 2, Title = "Un mundo feliz", Author = "Aldous Huxley", Year = 1932, Prize = 7.95M, CategoryId = 2 },
                new Book { Id = 3, Title = "Rebelión en la granja", Author = "George Orwell", Year = 1945, Prize = 8.50M, CategoryId = 2 }
                );
        }
    }
}
