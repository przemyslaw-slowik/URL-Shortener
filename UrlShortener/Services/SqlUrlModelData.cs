using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortener.Data;
using UrlShortener.Models;

namespace UrlShortener.Services
{
    public class SqlUrlModelData : IUrlModelData
    {
        private UrlShortenerDbContext _context;

        public SqlUrlModelData(UrlShortenerDbContext context)
        {
            _context = context;
        }

        public UrlModel Add(UrlModel urlModel)
        {
            urlModel.Time = DateTime.UtcNow;
            _context.Add(urlModel);
            _context.SaveChanges();
            return urlModel;
        }

        public UrlModel GetLast()
        {
            return _context.Urls.LastOrDefault();
        }

        public UrlModel Get(int id)
        {
            return _context.Urls.FirstOrDefault(x => x.Id == id);
        }

        public UrlModel Get(string shortUrl)
        {
            return _context.Urls.FirstOrDefault(x => x.ShortUrl == shortUrl);
        }

        public IQueryable<UrlModel> GetAll()
        {
            return _context.Urls;
        }

        public UrlModel Update(UrlModel urlModel)
        {
            _context.Attach(urlModel).State = EntityState.Modified;
            _context.SaveChanges();
            return urlModel;
        }
    }
}
