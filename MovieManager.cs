﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using MovieLibrary.Exceptions;
using MovieLibrary.Models;
using MovieLibrary.Services;

namespace MovieLibrary.Repository
{
    public class MovieManager
    {
        public static List<Movie> movies = new List<Movie>();
        public static void SerializeData()
        {
            DataSerializer.Serialize(movies);
        }
        public static void DeserializeData()
        {
            movies=DataSerializer.Deserialize();
        }
        public static void AddMovie(int id,string name,int year,string genre)
        {
            if (movies.Count == 5)
            {
                throw new CapacityOverException("Capacity Over ! You can not add New Movie ..\n");
            }
            else
            {
                movies.Add(Movie.AddNewMovie(id, name, year, genre));

            }
        }
        public static List<Movie> DisplayAllMovies()
        {
            if (movies.Count == 0)
            {
                throw new MovieListEmptyException("There is no Movie to display ! \n");
            }
            else
                return movies;
        }
        public static Movie FindMovie(int id)
        {
            Movie findID = movies.Where(item => item.Id == id).FirstOrDefault();
            if (findID != null)
                return findID;
            else
                throw new MovieNotFoundException("Movie not found\n");
        }
        public static void RemoveMovie(int id)
        {
            Movie findID = movies.Where(item => item.Id == id).FirstOrDefault();
            if (findID != null)
            {
                movies.Remove(findID);
                //Console.WriteLine("Your Account is removed successfully !\n");
            }
            else
                throw new MovieNotFoundException("Movie not found\n");
        }
        public static void ClearAllAccounts()
        {
            if (movies.Count == 0)
            {
                throw new MovieListEmptyException("There is no account to Clear ! \n");
            }
            else
                movies.Clear();
        }
    }
}
