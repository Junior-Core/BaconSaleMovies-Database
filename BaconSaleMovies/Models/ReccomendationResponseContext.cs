using System;
using Microsoft.EntityFrameworkCore;

//this is how migrations are used to create database!
namespace BaconSaleMovies.Models
{
    public class ReccomendationResponseContext : DbContext
    {
        public ReccomendationResponseContext(DbContextOptions<ReccomendationResponseContext> options) : base(options)
        {

        }

        public DbSet<ReccomendationResponse> Recommendations { get; set; }
    }
}
