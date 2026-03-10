using System;
using System.Collections.Generic;
using System.Linq;


namespace Interface
{
    // ==========================
    // Film Contract
    // ==========================
    public interface IFilm
    {
        string Title { get; set; }
        string Director { get; set; }
        int Year { get; set; }
    }

    // ==========================
    // Film Library Contract
    // ==========================
    public interface IFilmLibrary
    {
        void AddFilm(IFilm film);
        void RemoveFilm(string title);
        List<IFilm> GetFilms();
        List<IFilm> SearchFilms(string query);
        int GetTotalFilmCount();
    }

    // ==========================
    // Film Implementation
    // ==========================
    public class Film : IFilm
    {
        public string Title { set; get; }
        public string Director { set; get; }
        public int Year { set; get; }

        public Film(string title, string director, int year)
        {
            Title = title;
            Director = director;
            Year = year;
        }
    }

    // ==========================
    // Film Library Implementation
    // ==========================
    public class FilmLibrary : IFilmLibrary
    {
        List<IFilm> _films = new List<IFilm>();
        public void AddFilm(IFilm film)
        {
            _films.Add(film);
        }
        public void RemoveFilm(string title)
        {
            _films.RemoveAll(f => f.Title == title);
        }
        public List<IFilm> GetFilms()
        {
            return _films;
        }

        public List<IFilm> SearchFilms(string query)
        {
            return _films.Where(f => f.Title.Contains(query) || f.Director.Contains(query)).ToList();
        }
        public int GetTotalFilmCount()
        {
            return _films.Count;
        }

    }

    // ==========================
    // Program
    // ==========================
    internal class Program
    {
        static void Main(string[] args)
        {
            IFilmLibrary library = new FilmLibrary();

            // Add films
            library.AddFilm(new Film("Inception", "Christopher Nolan", 2010));
            library.AddFilm(new Film("Interstellar", "Christopher Nolan", 2014));
            library.AddFilm(new Film("The Dark Knight", "Christopher Nolan", 2008));
            library.AddFilm(new Film("Avatar", "James Cameron", 2009));

            Console.WriteLine("All Films:");
            foreach (var film in library.GetFilms())
            {
                Console.WriteLine($"{film.Title} - {film.Director} ({film.Year})");
            }

            Console.WriteLine("\nSearch Result (Nolan):");
            var results = library.SearchFilms("Nolan");
            foreach (var film in results)
            {
                Console.WriteLine($"{film.Title} - {film.Director}");
            }

            Console.WriteLine("\nRemoving Avatar...");
            library.RemoveFilm("Avatar");

            Console.WriteLine("\nTotal Films: " + library.GetTotalFilmCount());

            Console.ReadLine();
        }
    }
}