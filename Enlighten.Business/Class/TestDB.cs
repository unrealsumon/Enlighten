using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Enlighten.Data;
using Enlighten.Data.SharedModels;

namespace Enlighten.Business.Class
{
    public class TestDB :  BaseClass
    {
       

           public void insert(InventoryModel model)
        {
            var context = _context;
            //EnlightenDBContext context = new EnlightenDBContext();
            TB_Inventory iv=new TB_Inventory
                {
                    name=model.name,
                    qty=model.qty,
                };
                context.TB_Inventory.Add(iv);
                context.SaveChanges();
           // context.Dispose();
            

        }
    

    
    }
}