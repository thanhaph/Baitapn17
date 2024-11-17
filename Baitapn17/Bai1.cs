using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baitapn17
{
    public class Bai1
    {
        public List<int> GetSochiahetcho2(int[] numbers)
        {
            return numbers.Where(n => n % 2 == 0).ToList();
        }
    }
}
