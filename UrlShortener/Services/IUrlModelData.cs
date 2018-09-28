using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortener.Models;

namespace UrlShortener.Services
{
    public interface IUrlModelData
    {
        IEnumerable<UrlModel> GetAll();
        UrlModel Get(int id);
        UrlModel Get(string shortUrl);
        UrlModel Add(UrlModel urlModel);
        UrlModel Update(UrlModel urlModel);
        UrlModel GetLast();
    }
}
