using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
                                  p.Model,
                                  p.Color,
                                  pc.CategoryName,
                                  p.IsDeleted,
                                  p.UnitName,
                                  p.UnitSize
                              };
            var list = ProductList.ToList();
            return list;
           
        }
    }
}