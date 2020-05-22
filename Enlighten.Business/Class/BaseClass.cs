
using Enlighten.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Enlighten.Business.Class
{
    public class BaseClass :IDisposable
    {
        protected EnlightenDBContext _context;
        protected BaseClass()
        {
            EnlightenDBContext context = new EnlightenDBContext();
            
            // setting the db context
                _context = context;
            
        }

       public void Dispose()
        {
            _context.Dispose();
            _context = null;
        }
    }
}