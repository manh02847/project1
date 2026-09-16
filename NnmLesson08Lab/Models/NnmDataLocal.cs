namespace NnmLesson08Lab.Models
{
    public static class NnmDataLocal
    {
        public static List<NnmCategory> NnmCategories { get; } = new()
        {
            new NnmCategory { NnmCategoryId = 1, NnmCategoryName = "Điện thoại" },
            new NnmCategory { NnmCategoryId = 2, NnmCategoryName = "Máy tính" },
            new NnmCategory { NnmCategoryId = 3, NnmCategoryName = "Phụ kiện" }
        };

        public static List<NnmProduct> NnmProducts { get; } = new()
        {
            new NnmProduct
            {
                NnmProductId = 1,
                NnmProductName = "Điện thoại Samsung",
                NnmPrice = 12000000,
                NnmSalePrice = 11500000,
                NnmStatus = true,
                NnmCreatedDate = DateTime.Today,
                NnmCategoryId = 1,
                NnmDescription = "Điện thoại thông minh"
            },
            new NnmProduct
            {
                NnmProductId = 2,
                NnmProductName = "Laptop Dell",
                NnmPrice = 18500000,
                NnmSalePrice = 17900000,
                NnmStatus = true,
                NnmCreatedDate = DateTime.Today,
                NnmCategoryId = 2,
                NnmDescription = "Laptop phục vụ học tập"
            },
            new NnmProduct
            {
                NnmProductId = 3,
                NnmProductName = "Chuột không dây",
                NnmPrice = 350000,
                NnmSalePrice = 299000,
                NnmStatus = true,
                NnmCreatedDate = DateTime.Today,
                NnmCategoryId = 3,
                NnmDescription = "Phụ kiện máy tính"
            }
        };

        public static string NnmGetCategoryName(int categoryId)
        {
            return NnmCategories.FirstOrDefault(x => x.NnmCategoryId == categoryId)?.NnmCategoryName ?? string.Empty;
        }

        public static int NnmGetNextProductId()
        {
            return NnmProducts.Count == 0 ? 1 : NnmProducts.Max(x => x.NnmProductId) + 1;
        }
    }
}
