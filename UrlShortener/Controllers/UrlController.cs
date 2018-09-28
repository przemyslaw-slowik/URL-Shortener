using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Models;
using UrlShortener.Services;
using UrlShortener.ViewModels;

namespace UrlShortener.Controllers
{
    public class UrlController : Controller
    {
        private IUrlModelData _urlModelData;

        public UrlController(IUrlModelData urlModelData)
        {
            _urlModelData = urlModelData;
        }

        public IActionResult Stats()
        {
            var model = _urlModelData.GetAll();

            return View(model);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UrlEditModel model)
        {
            if (ModelState.IsValid)
            {
                var newUrl = new UrlModel
                {
                    Url = model.Url,
                    ShortUrl = model.ShortUrl
                };

                if (newUrl.ShortUrl == null)
                {
                    var lastUrl = _urlModelData.GetLast();

                    newUrl.ShortUrl = ((lastUrl != null ? lastUrl.Id : 0) + 1).ToString();
                    if (_urlModelData.Get(newUrl.ShortUrl) != null)
                    {
                        newUrl.ShortUrl += ".html";
                    }
                }
                else
                {
                    if (_urlModelData.Get(newUrl.ShortUrl) != null)
                    {
                        ModelState.AddModelError("ShortUrl", "This custom url name is already taken.");
                        return View(nameof(Index));
                    }
                }

                newUrl = _urlModelData.Add(newUrl);
                return RedirectToAction(nameof(Details), new { newUrl.Id });
            }
            else
            {
                return View(nameof(Index));
            }
        }

        public IActionResult Details(int id)
        {
            var model = _urlModelData.Get(id);
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult Forward(string shortUrl)
        {
            if (shortUrl.Length > 24)
            {
                return RedirectToAction(nameof(Index));
            }

            if (!Regex.IsMatch(shortUrl, @"^[a-zA-Z0-9]+$"))
            {
                return RedirectToAction(nameof(Index));
            }

            var model = _urlModelData.Get(shortUrl);
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }

            model.Hits += 1;
            _urlModelData.Update(model);

            return Redirect(model.Url);
        }

        public IActionResult Github()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
