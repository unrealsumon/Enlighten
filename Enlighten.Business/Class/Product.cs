using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Enlighten.Data.SharedModels;
using Enlighten.Data;

namespace Enlighten.Business.Class
{
    public class Product : BaseClass
    {
        public object GetProductList()
        {
            var context = _context;
            var ProductList = from p in context.TB_Product
                              join pc in context.TB_ProductCategory on p.CategoryID equals pc.CategoryID where p.CompanyID == LoginUser.ActiveCompanyID
                              select new
                              {
                                  p.ProductID,
                                  p.ProductName,
                                  p.Barcode,
                                  p.Brand,
                                  p.Size,
                                  p.ModelName,
                                  p.Color,
                                  pc.CategoryName,
                                  p.CategoryID,
                                  p.IsDeleted,
                                  p.UnitName,
                                  p.UnitSize,
                                  p.Description,
                                  p.ShortName
                              };
            var list = ProductList.ToList();
            return list;
           
        }
   

    public object GetCategoryList()
    {
        var context = _context;
            var categoryList = from p in context.TB_ProductCategory
                              where p.CompanyID == LoginUser.ActiveCompanyID
                              select new {
                                  p.CategoryID,
                                  p.CategoryName,
                                  p.IsDeleted
                              };
        var list = categoryList.ToList().OrderBy(x=>x.CategoryName);
        return list;

    }

        public string AddUpdateProduct(int id, ProductModel model)
        {
            var context = _context;
            TB_Product product;
      

            if (id == -1)
            {
                product = new TB_Product();   
            }
            else
            {
                product = context.TB_Product.Where(x => x.ProductID == id).FirstOrDefault();
            }

            product.ProductName = model.ProductName;
            product.CategoryID = model.CategoryID;
            product.Barcode = model.Barcode;
            product.UnitName = model.UnitName;
            product.UnitSize = model.UnitSize;
            product.Size = model.Size;
            product.ModelName = model.ModelName;
            product.Color = model.Color;
            product.Brand = model.Brand;
            product.Description = model.Description;
            product.IsDeleted = false;
            product.ShortName = model.ShortName;

            if (LoginUser.ActiveCompanyID != null)
            {
                product.CompanyID = (int)LoginUser.ActiveCompanyID;
            }
     


            try
            {
                if (id == -1)
                {
                    context.TB_Product.Add(product);
                }

                context.SaveChanges();              
                Dispose();
                return "";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

       

        public string AddUpdateCategory(int id, CategoryModel model)
        {
            var context = _context;
            TB_ProductCategory category;


            if (id == -1)
            {
                category = new TB_ProductCategory();
            }
            else
            {
                category = context.TB_ProductCategory.Where(x => x.CategoryID == id).FirstOrDefault();
            }

            category.CategoryName = model.CategoryName;
            category.IsDeleted = model.IsDeleted;
      
           

            if (LoginUser.ActiveCompanyID != null)
            {
                category.CompanyID = (int)LoginUser.ActiveCompanyID;
            }



            try
            {
                if (id == -1)
                {
                    context.TB_ProductCategory.Add(category);
                }

                context.SaveChanges();
                Dispose();
                return "";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public string RemoveProduct(int id)
        {
            var context = _context;
            TB_Product product;           
                product = context.TB_Product.Where(x => x.ProductID == id).FirstOrDefault();
            product.IsDeleted = true;
            try
            {
                context.SaveChanges();
                Dispose();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }



        public string RemoveCategory(int id)
        {
            var context = _context;
            TB_ProductCategory categroy;
            categroy = context.TB_ProductCategory.Where(x => x.CategoryID == id).FirstOrDefault();
            categroy.IsDeleted = true;
            try
            {
                context.SaveChanges();
                Dispose();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}