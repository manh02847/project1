using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NnmLesson08Lab.Models;

namespace NnmLesson08Lab.Controllers
{
    public class NnmProductController : Controller
    {
        public IActionResult Index()
        {
            return View(NnmDataLocal.NnmProducts);
        }

        [HttpGet]
        public IActionResult NnmDetails(int id)
        {
            var product = NnmDataLocal.NnmProducts.FirstOrDefault(x => x.NnmProductId == id);
            return product == null ? NotFound() : View(product);
        }

        [HttpGet]
        public IActionResult NnmCreate()
        {
            NnmSetCategories();
            return View(new NnmProduct { NnmCreatedDate = DateTime.Today, NnmStatus = true });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NnmCreate(NnmProduct product, IFormFile? nnmImageFile)
        {
            if (!ModelState.IsValid)
            {
                NnmSetCategories();
                return View(product);
            }

            product.NnmProductId = NnmDataLocal.NnmGetNextProductId();
            product.NnmImage = NnmSaveImage(nnmImageFile);
            NnmDataLocal.NnmProducts.Add(product);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult NnmEdit(int id)
        {
            var product = NnmDataLocal.NnmProducts.FirstOrDefault(x => x.NnmProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            NnmSetCategories();
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NnmEdit(int id, NnmProduct product, IFormFile? nnmImageFile)
        {
            var oldProduct = NnmDataLocal.NnmProducts.FirstOrDefault(x => x.NnmProductId == id);
            if (oldProduct == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                product.NnmImage = oldProduct.NnmImage;
                NnmSetCategories();
                return View(product);
            }

            oldProduct.NnmProductName = product.NnmProductName;
            oldProduct.NnmPrice = product.NnmPrice;
            oldProduct.NnmSalePrice = product.NnmSalePrice;
            oldProduct.NnmStatus = product.NnmStatus;
            oldProduct.NnmCreatedDate = product.NnmCreatedDate;
            oldProduct.NnmCategoryId = product.NnmCategoryId;
            oldProduct.NnmDescription = product.NnmDescription;

            var image = NnmSaveImage(nnmImageFile);
            if (image != null)
            {
                oldProduct.NnmImage = image;
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult NnmDelete(int id)
        {
            var product = NnmDataLocal.NnmProducts.FirstOrDefault(x => x.NnmProductId == id);
            return product == null ? NotFound() : View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NnmDeleted(int id)
        {
            var product = NnmDataLocal.NnmProducts.FirstOrDefault(x => x.NnmProductId == id);
            if (product != null)
            {
                NnmDataLocal.NnmProducts.Remove(product);
            }

            return RedirectToAction(nameof(Index));
        }

        private void NnmSetCategories()
        {
            ViewBag.NnmCategories = new SelectList(
                NnmDataLocal.NnmCategories,
                nameof(NnmCategory.NnmCategoryId),
                nameof(NnmCategory.NnmCategoryName));
        }

        private string? NnmSaveImage(IFormFile? imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
            {
                return null;
            }

            var imageFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "products");
            Directory.CreateDirectory(imageFolder);

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(Path.GetFileName(imageFile.FileName))}";
            var filePath = Path.Combine(imageFolder, fileName);
            using var stream = new FileStream(filePath, FileMode.Create);
            imageFile.CopyTo(stream);

            return $"/images/products/{fileName}";
        }
    }
}
