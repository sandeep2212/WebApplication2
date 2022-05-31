using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication2.Model;
using WebApplication2.Services;

namespace WebApplication2.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product>? products;

        public void OnGet()
        {
            var productService = new ProductServices();
            products= productService.GetProducts();
        }
    }
}