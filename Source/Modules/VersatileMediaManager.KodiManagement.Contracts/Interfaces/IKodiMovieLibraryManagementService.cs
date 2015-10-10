using System.Collections.Generic;
using VersatileMediaManager.KodiManagement.Contracts.Model.Video.Details;

namespace VersatileMediaManager.KodiManagement.Contracts.Interfaces
{
    public interface IKodiMovieLibraryManagementService
    {
        /// <summary>
        /// Get list with start and endpoint
        /// </summary>
        /// <param name="start">Start-Index</param>
        /// <param name="end">End-Index</param>
        /// <returns>List with the selected movies</returns>
        IList<Movie> GetMovies(int start = 0, int end = 1);

        /// <summary>
        /// Get list with all movies
        /// </summary>
        /// <returns>List with the selected movies</returns>
        IList<Movie> GetAllMovies();

        /// <summary>
        /// Retrieve details about a specific movie
        /// </summary>
        /// <param name="movieId">The movie id.</param>
        /// <returns></returns>
        Movie GetMovieDetails(int movieId);
    }
}