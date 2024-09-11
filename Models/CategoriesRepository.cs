namespace MyProject.Models
{
    public static class CategoriesRepository
    {
        private static List<Category> _categories = new List<Category>()
        {
            new Category{CategoryId=1, CategoryName="Beverages", CategoryDescription="Beverages"},
            new Category{CategoryId=2, CategoryName="Meals", CategoryDescription="Meals"},
            new Category{CategoryId=3, CategoryName="Fruits", CategoryDescription="Fruits"},
            new Category{CategoryId=4, CategoryName="Meats", CategoryDescription="Meats"},
        };

        // CREATE CATEGORY
        public static void AddCategory(Category category)
        {
            var lastId = _categories.Max(x => x.CategoryId);
            category.CategoryId = lastId + 1;
            _categories.Add(category);
        }

        // READ ALL CATEGORIES
        public static List<Category> GetAllCategories() => _categories;

        // READ ONE CATEGORY BY ID
        public static Category? GetCategoryById(int categoryId)
        {
            var category = _categories.FirstOrDefault(
                x => x.CategoryId == categoryId);
            if (category != null)
            {
                return new Category
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                    CategoryDescription = category.CategoryDescription,
                };
            }
            return null;
        }

        // UPDATE CATEGORY
        public static void UpdateCategory(
            int categoryId, Category category)
        {
            if (categoryId != category.CategoryId) return;

            var CategoryToUpdate = _categories.FirstOrDefault(
                                x => x.CategoryId == categoryId);
            if (CategoryToUpdate != null)
            {
                CategoryToUpdate.CategoryName = category.CategoryName;
                CategoryToUpdate.CategoryDescription = category.CategoryDescription;
            }
        }

        // DELETE CATEGORY
        public static void DeleteCategory(int categoryId)
        {
            var category = _categories.FirstOrDefault(
                x => x.CategoryId == categoryId);
            if (category != null)
            {
                _categories.Remove(category);
            }
        }
    }
}
