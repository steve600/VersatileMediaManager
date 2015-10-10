using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using VersatileMediaManager.Base.Prism;
using VersatileMediaManager.Communication.Interfaces;
using VersatileMediaManager.Communication.JsonRpc;
using VersatileMediaManager.Infrastructure.Contracts.Constants;
using VersatileMediaManager.Infrastructure.Contracts.Interfaces;
using VersatileMediaManager.KodiManagement.Contracts.Interfaces;
using VersatileMediaManager.KodiManagement.Contracts.Model;
using VersatileMediaManager.KodiManagement.Contracts.Model.JsonResults;
using VersatileMediaManager.KodiManagement.Contracts.Model.List;
using VersatileMediaManager.KodiManagement.Contracts.Model.Video;
using VersatileMediaManager.KodiManagement.Contracts.Model.Video.Details;

namespace VersatileMediaManager.KodiManagement.Services
{
    public class KodiMovieLibraryManagementJsonService : PrismBaseService, IKodiMovieLibraryManagementService
    {
        public JsonRpcApiVersion GetVersion()
        {
            JsonRpcApiVersion result = null;

            // Get connection manager with active connection
            IConnectionManager connectionManager = UnityContainer.Resolve<IConnectionManager>(GlobalConstants.ConnectionManager);

            if (connectionManager != null && connectionManager.ActiveConnection != null)
            {
                JsonRpcRequest request = new JsonRpcRequest()
                {
                    Method = "JSONRPC.Version"
                };

                var da = new JsonRpcDataAdapter<JsonRpcApiVersion>(connectionManager.ActiveConnection);
                var r = da.Execute(request);
            }

            return result;
        }

        /// <summary>
        /// Get list with start and endpoint
        /// </summary>
        /// <param name="start">Start-Index</param>
        /// <param name="end">End-Index</param>
        /// <returns>List with the selected movies</returns>
        public IList<Movie> GetMovies(int start = 0, int end = 1)
        {
            IList<Movie> result = null;

            try
            {
                // Get connection manager with active connection
                IConnectionManager connectionManager = UnityContainer.Resolve<IConnectionManager>(GlobalConstants.ConnectionManager);

                if (connectionManager != null && connectionManager.ActiveConnection != null)
                {
                    JsonRpcRequest request = new JsonRpcRequest()
                    {
                        Method = "VideoLibrary.GetMovies",
                        Params = new
                        {
                            properties = Fields.Movie,
                            limits = new Limits(start, end),
                            sort = new Sort() { Order = "ascending", IgnoreArticle = false, Method = "title" }
                        }
                    };

                    var da = new JsonRpcDataAdapter<MovieResult>(connectionManager.ActiveConnection);
                    var r = da.Execute(request);

                    if (r != null)
                        result = r.Movies.ToList();
                }
            }
            catch (Exception ex)
            {
                // Log-Exception
                this.UnityContainer.Resolve<ILoggingService>(ServiceNames.LoggingService).Write(ex, new List<string>() { LoggingCategories.Errors, LoggingCategories.KodiManagementModule });
                // TODO: Show-Exeption
            }

            return result;
        }

        /// <summary>
        /// Get list with all movies
        /// </summary>
        /// <returns></returns>
        public IList<Movie> GetAllMovies()
        {
            IList<Movie> movies = null;

            try
            {
                // Get connection manager with active connection
                IConnectionManager connectionManager = UnityContainer.Resolve<IConnectionManager>(GlobalConstants.ConnectionManager);

                if (connectionManager != null && connectionManager.ActiveConnection != null)
                {
                    JsonRpcRequest request = new JsonRpcRequest()
                    {
                        Method = "VideoLibrary.GetMovies",
                        Params = new
                        {
                            properties = Fields.Movie,
                            limits = new Limits(0, 1)
                        }
                    };

                    var da = new JsonRpcDataAdapter<MovieResult>(connectionManager.ActiveConnection);
                    var r = da.Execute(request);

                    if (r != null)
                    {
                        movies = this.GetMovies(0, r.Limits.Total);
                    }
                }
            }
            catch (Exception ex)
            {
                // Log-Exception
                this.UnityContainer.Resolve<ILoggingService>(ServiceNames.LoggingService).Write(ex, new List<string>() { LoggingCategories.Errors, LoggingCategories.KodiManagementModule });
                // TODO: Show-Exeption
            }

            return movies;
        }

        /// <summary>
        /// Retrieve details about a specific movie
        /// </summary>
        /// <param name="movieId">The movie id.</param>
        /// <returns></returns>
        public Movie GetMovieDetails(int movieId)
        {
            Movie result = null;

            try
            {
                // Get connection manager with active connection
                IConnectionManager connectionManager = UnityContainer.Resolve<IConnectionManager>(GlobalConstants.ConnectionManager);

                if (connectionManager != null && connectionManager.ActiveConnection != null)
                {
                    JsonRpcRequest request = new JsonRpcRequest()
                    {
                        Method = "VideoLibrary.GetMovieDetails",
                        Params = new
                        {
                            movieid = movieId,
                            properties = Fields.Movie
                        }
                    };

                    var da = new JsonRpcDataAdapter<JsonRpcResponse<Movie>>(connectionManager.ActiveConnection);
                    var r = da.Execute(request);

                    if (r != null)
                        result = r.Result;
                }
            }
            catch (Exception ex)
            {
                // Log-Exception
                this.UnityContainer.Resolve<ILoggingService>(ServiceNames.LoggingService).Write(ex, new List<string>() { LoggingCategories.Errors, LoggingCategories.KodiManagementModule });
                // TODO: Show-Exeption
            }

            return result;
        }
    }
}