using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Movies;

namespace WebApp.Controllers
{
    public class MovieController : Controller
    {
        private readonly MoviesContext _context;

        public MovieController(MoviesContext context)
        {
            _context = context;
        }

        // GET: Movie
        public async Task<IActionResult> Index(int page = 1, int size = 10)
        {
            IQueryable<Movie> query = _context.Movies;

            var movies = await query
                .OrderBy(m => m.Title)
                .Skip((page - 1) * size)
                .Take(size)
                .AsNoTracking()
                .ToListAsync();

            int totalMovies = await query.CountAsync();
            ViewBag.TotalPages = (int)Math.Ceiling(totalMovies / (double)size);
            ViewBag.CurrentPage = page;

            return View(movies);
        }

        // GET: Movie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .Include(m => m.MovieGenres)
                .ThenInclude(mg => mg.Genre)
                .Include(m => m.MovieKeywords)
                .ThenInclude(mk => mk.Keyword)
                .Include(m => m.MovieCasts)
                .ThenInclude(mc => mc.Person)
                .Include(m => m.MovieCasts)
                .ThenInclude(mc => mc.Gender)
                .Include(m => m.MovieLanguages)
                .ThenInclude(ml => ml.Language)
                .Include(m => m.MovieCompanies)
                .ThenInclude(mc => mc.Company)
                .Include(m => m.ProductionCountries)
                .ThenInclude(pc => pc.Country)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.MovieId == id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movie/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        public async Task<IActionResult> Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }


        // GET: Movie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movie/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Budget,Homepage,Overview,Popularity,ReleaseDate,Revenue,Runtime,MovieStatus,Tagline,VoteAverage,VoteCount")] Movie movie)
        {
            if (id != movie.MovieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.MovieId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult AddCast(int id)
        {
            ViewBag.People = _context.People.ToList();
            var movieCast = new MovieCast { MovieId = id };
            return View(movieCast);
        }

        [HttpPost]
        public async Task<IActionResult> AddCast(MovieCast movieCast)
        {
            if (ModelState.IsValid)
            {
                _context.MovieCasts.Add(movieCast);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", new { id = movieCast.MovieId });
            }
            ViewBag.People = _context.People.ToList();
            return View(movieCast);
        }



        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.MovieId == id);
        }
    }
}
