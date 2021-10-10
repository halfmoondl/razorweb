using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorWeb.Models;

namespace RazorWeb.Pages_Blog
{
    public class IndexModel : PageModel
    {
        public const int ITEMS_PER_PAGE = 10;
        [BindProperty(SupportsGet =true, Name ="p")]
        public int currentPage { set; get; }
        public int countPages { get; set; }

        private readonly RazorWeb.Models.MyBlogContext _context;

        public IndexModel(RazorWeb.Models.MyBlogContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get;set; }

        public async Task OnGetAsync(string seachstring)
        {
            //Phân trang
            int toltalitem = await _context.articles.CountAsync();
            countPages = (int) Math.Ceiling( (double) toltalitem / ITEMS_PER_PAGE);

            if (currentPage<1)
            {
                currentPage=1;
            }
            if (currentPage > countPages)
            {
                currentPage = countPages;
            }

            // Article = await _context.articles.ToListAsync();
            var qr = (from p in _context.articles orderby p.Created descending select p).Skip((currentPage-1)*ITEMS_PER_PAGE).Take(ITEMS_PER_PAGE);

            if (!string.IsNullOrEmpty(seachstring))
            {
                Article= qr.Where(a => a.Title.Contains(seachstring)).ToList();
            }
            else
            {
                Article = await qr.ToListAsync();
            }
            

        }
    }
}
