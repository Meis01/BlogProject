using BlogProject.CORE.Entity.Service;
using BlogProject.MODEL.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.WEBUI.Controllers
{
    public class PostController : Controller
    {
        private readonly ICoreService<Post> _ps;
        private readonly ICoreService<Category> _cs;
        private readonly ICoreService<User> _us;
        private readonly ICoreService<Comment> _cms;

        public PostController(ICoreService<Post> ps, ICoreService<Category> cs, ICoreService<User> us, ICoreService<Comment> cms)
        {
            _ps = ps;
            _cs = cs;
            _cms = cms;
            _us = us;
        }
        public IActionResult Index()
        {
            ViewBag.SonYazilar = _ps.GetActive().OrderByDescending(x => x.CreatedDate.Value.Year == DateTime.Now.Year).Take(3); // Geçerli tarihin yılı ile aynı yılda yazılmış Post'lardan ilk ikisini almak için
            ViewBag.Kategoriler = _cs.GetActive();
            return View(_ps.GetAll());
        }
       
    }
}
