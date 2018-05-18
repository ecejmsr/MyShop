using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using MyShop.Core.Models;

namespace MyShop.DataAccess.InMemory
{
    public class ProductCategoryRepository
    {
        MemoryCache cache = MemoryCache.Default;
        List<ProductCategory> categories;

        public ProductCategoryRepository()
        {
            categories = cache["categories"] as List<ProductCategory>;
            if (categories == null)
            {
                categories = new List<ProductCategory>();
            }
        }

        public void Commit()
        {
            cache["categories"] = categories;
        }

        public void Insert(ProductCategory category)
        {
            categories.Add(category);
        }

        public void Update(ProductCategory category)
        {
            ProductCategory categoryToUpdate = categories.Find(c => c.ID == category.ID);
            if (categoryToUpdate != null)
            {
                categoryToUpdate = category;
            }
            else
            {
                throw new Exception("Catergory Is Not Found");
                //Do nlogger stuff here too
            }
        }

        public ProductCategory Find(string ID)
        {
            ProductCategory category = categories.Find(c => c.ID == ID);
            if (category != null)
            {
                return category;
            }
            else
            {
                throw new Exception("Catergory Is Not Found");
                //Do nlogger stuff here too
            }
        }

        public IQueryable<ProductCategory> Collection()
        {
            return categories.AsQueryable();
        }

        public void Delete(string ID)
        {
            ProductCategory category = categories.Find(c => c.ID == ID);
            if (category != null)
            {
                categories.Remove(category);
            }
            else
            {
                throw new Exception("Category Is Not Found");
                //Do nlogger stuff here too
            }
        }
    }
}
