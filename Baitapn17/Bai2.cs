using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baitapn17
{
    public class Bai2
    {
        private int[] _number;
        public Bai2(int[] numbers)
        {
            if (numbers.Length != 4)
            {
                throw new ArgumentException("mảng phải có 4 phần tử");
            }
            _number = numbers;
        }
        public int HieuCuaMang()
        {
            return _number.Max() - _number.Min();
        }
    }
}
