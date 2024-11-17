using Baitapn17;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N17.NunitTest
{
    [TestFixture]
    public class Bai3Test
    {
        private Bai3 _b3 = new Bai3();
        [Test]
        
        [TestCase(1, "Toyota", 0, "Mới")] // Giá bằng 0 (không hợp lệ)
        [TestCase(2, "Honda", -50000, "Cũ")] // Giá âm (không hợp lệ)
        [TestCase(3, "Mazda", 1, "Mới")] // Giá gần bằng 1 (hợp lệ)
        [TestCase(4, "Nissan", 1000000, "Cũ")] // Giá lớn (hợp lệ)
        public void ThemXeTheogia(int ma, string ten, decimal gia, string ghichu)
        {
            if (gia <= 0)
            {
                Assert.Throws<ArgumentException>(() => _b3.Them(new XeOto(ma, ten, gia, ghichu)));
            }
            else
            {
                var xe = new XeOto(ma, ten, gia, ghichu);
                _b3.Them(xe);
                var danhSach = _b3.LayDanhSach();
                Assert.AreEqual(1, danhSach.Count);
                Assert.AreEqual(ten, danhSach.First().Ten);
            }
        }
        [Test]
        [TestCase(1, "", 500000, "Mới")] 
        [TestCase(2, "Toyota", 500000, "Mới")] 
        public void ThemXeTheoten(int ma, string ten, decimal gia, string ghichu)
        {
            if (string.IsNullOrWhiteSpace(ten))
            {
                Assert.Throws<ArgumentException>(() => _b3.Them(new XeOto(ma, ten, gia, ghichu)));
            }
            else
            {
                var xe = new XeOto(ma, ten, gia, ghichu);
                _b3.Them(xe);
                var danhSach = _b3.LayDanhSach();
                Assert.AreEqual(1, danhSach.Count);
                Assert.AreEqual(ten, danhSach.First().Ten);
            }
        }

       
        [Test]
        [TestCase(1, "Toyota", 500000, "Mới", "Honda", 0, "Cũ")] 
        [TestCase(2, "Toyota", 500000, "Mới", "Honda", 600000, "Cũ")] 
        public void SuaThanhCong(int ma, string ten, decimal gia, string ghichu, string tenCapNhat, decimal giaCapNhat, string ghichuCapNhat)
        {
            var xe = new XeOto(ma, ten, gia, ghichu);
            _b3.Them(xe);

            if (giaCapNhat <= 0)
            {
                Assert.Throws<ArgumentException>(() => _b3.Sua(new XeOto(ma, tenCapNhat, giaCapNhat, ghichuCapNhat)));
            }
            else
            {
                var xeCapNhat = new XeOto(ma, tenCapNhat, giaCapNhat, ghichuCapNhat);
                _b3.Sua(xeCapNhat);
                var danhSach = _b3.LayDanhSach();
                Assert.AreEqual(1, danhSach.Count);
                Assert.AreEqual(tenCapNhat, danhSach.First().Ten);
                Assert.AreEqual(giaCapNhat, danhSach.First().Gia);
            }
        }

        
        [Test]
        [TestCase(1, "Toyota", 500000, "Mới", 2)] 
        public void XoaXekhongtontai(int ma, string ten, decimal gia, string ghichu, int maKhongTonTai)
        {
            var xe = new XeOto(ma, ten, gia, ghichu);
            _b3.Them(xe);

            _b3.Xoa(maKhongTonTai); 

            var danhSach = _b3.LayDanhSach();
            Assert.AreEqual(1, danhSach.Count);
        }
    }
}
