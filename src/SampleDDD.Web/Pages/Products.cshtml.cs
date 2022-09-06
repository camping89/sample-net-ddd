using Microsoft.AspNetCore.Mvc.RazorPages;
using SampleDDD.Application.Contracts.Products;

namespace SampleDDD.Web.Pages;

public class ProductModel : PageModel
{
    private readonly IProductAppService _productAppService;

    public List<ProductDto> Products { get; set; } = new();

    public ProductModel(IProductAppService productAppService)
    {
        _productAppService = productAppService;
    }

    public async Task OnGetAsync()
    {
        Products = await _productAppService.GetListAsync(new GetProductInput());
    }
}