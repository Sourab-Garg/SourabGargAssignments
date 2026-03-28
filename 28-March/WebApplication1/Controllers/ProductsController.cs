using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductApiService _productApiService;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductApiService productApiService, ILogger<ProductsController> logger)
        {
            _productApiService = productApiService;
            _logger = logger;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            try
            {
                var products = await _productApiService.GetAllProductsAsync();
                return View(products);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching products: {ex.Message}");
                TempData["ErrorMessage"] = "Error fetching products. Please try again.";
                return View(new List<ProductViewModel>());
            }
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var product = await _productApiService.GetProductByIdAsync(id);
                if (product == null)
                {
                    TempData["ErrorMessage"] = $"Product with ID {id} not found.";
                    return RedirectToAction(nameof(Index));
                }

                return View(product);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching product: {ex.Message}");
                TempData["ErrorMessage"] = "Error fetching product. Please try again.";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,Price,StockQuantity")] ProductViewModel product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var createdProduct = await _productApiService.CreateProductAsync(product);
                    TempData["SuccessMessage"] = "Product created successfully!";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating product: {ex.Message}");
                ModelState.AddModelError(string.Empty, "Error creating product. Please try again.");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var product = await _productApiService.GetProductByIdAsync(id);
                if (product == null)
                {
                    TempData["ErrorMessage"] = $"Product with ID {id} not found.";
                    return RedirectToAction(nameof(Index));
                }

                return View(product);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching product for edit: {ex.Message}");
                TempData["ErrorMessage"] = "Error fetching product. Please try again.";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,StockQuantity")] ProductViewModel product)
        {
            if (id != product.Id)
            {
                TempData["ErrorMessage"] = "Product ID mismatch.";
                return RedirectToAction(nameof(Index));
            }

            try
            {
                if (ModelState.IsValid)
                {
                    var updatedProduct = await _productApiService.UpdateProductAsync(id, product);
                    TempData["SuccessMessage"] = "Product updated successfully!";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating product: {ex.Message}");
                ModelState.AddModelError(string.Empty, "Error updating product. Please try again.");
            }

            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var product = await _productApiService.GetProductByIdAsync(id);
                if (product == null)
                {
                    TempData["ErrorMessage"] = $"Product with ID {id} not found.";
                    return RedirectToAction(nameof(Index));
                }

                return View(product);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching product for delete: {ex.Message}");
                TempData["ErrorMessage"] = "Error fetching product. Please try again.";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var success = await _productApiService.DeleteProductAsync(id);
                if (success)
                {
                    TempData["SuccessMessage"] = "Product deleted successfully!";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["ErrorMessage"] = "Product not found.";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting product: {ex.Message}");
                TempData["ErrorMessage"] = $"Error deleting product: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
