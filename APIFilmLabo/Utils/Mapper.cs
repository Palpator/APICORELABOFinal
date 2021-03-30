using Api.Labo.DAL.Entities;
using APIFilmLabo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIFilmLabo.Utils
{
    public static class Mapper
    {
        public static FullMovieById ToApi(this MoviesEntity movies)
        {
            return new FullMovieById
            {
                IdMovie = movies.Id,
                Title = movies.Title,
                Synopsis = movies.Synopsis,
                YearRelease = movies.YearRelease
            };
        }
        public static FullPerson ToApi(this PersonEntity movies)
        {
            return new FullPerson
            {
                Id=movies.Id,
                FirstName=movies.FirstName,
                LastName=movies.LastName
            };
        }
    }
}
