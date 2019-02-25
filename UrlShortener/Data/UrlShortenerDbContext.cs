using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortener.Models;

namespace UrlShortener.Data
{
    public class UrlShortenerDbContext : DbContext
    {
        public DbSet<UrlModel> Urls { get; set; }

        public UrlShortenerDbContext(DbContextOptions<UrlShortenerDbContext> options) : base(options)
        {
        }
    }
}
