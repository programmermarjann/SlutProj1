using System.Collections.Generic;

namespace SlutProj1.Models
{
    public interface ITshirtRepository
    {
        public IEnumerable<Tshirt> AllTshirts { get; }

        Tshirt GetTshirtbyID(int TshirtID);


    }
}