
using Enlighten.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Enlighten.Business.Class
{
    public class BaseClass
    {
        protected EnlightenDBContext _context;
        protected BaseClass()
        {
            EnlightenDBContext context = new EnlightenDBContext();
            
                _context = context;
            
        }

       ~BaseClass()
        {
            _context.Dispose();
        }
    }
}