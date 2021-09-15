using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace task3
{
    class PCLogic
    {
        public int PCPlaying(List<string> moves)
        {
            return RNGCryptoServiceProvider.GetInt32(0, moves.Count);
        }
    }
}
