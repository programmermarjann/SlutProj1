using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlutProj1.Models
{
    public class TshirtRepository : ITshirtRepository
    {
   
            private readonly SlutDbContext _slutDbContext;

            public TshirtRepository(SlutDbContext appDbContext)
            {
                _slutDbContext = appDbContext;
            }
         
        public IEnumerable<Tshirt> AllTshirts
            {
                get
                {
                return _slutDbContext.Tshirts.Include(c => c.Size); 
                }
            }

            public Tshirt GetTshirtById(int TshirtID)
            {
                return _slutDbContext.Tshirts.FirstOrDefault(p => p.TshirtID == TshirtID);
            }

        public Tshirt GetTshirtbyID(int TshirtID)
        {
           throw new NotImplementedException();
        }
    }
    }


