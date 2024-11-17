using Baitapn17;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N17.NunitTest
{
    [TestFixture]
    public class Bai4Test
    {
        private Bai4 _b4 = new Bai4();
        [Test]
        [TestCase(1, "", "ha", "ha.le@gmail.com")] 
        [TestCase(2, "ha", "le", "hele@gmail.com")] 
        public void AddTheoten(int id, string firstName, string lastName, string email)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                Assert.Throws<ArgumentException>(() => _b4.Add(new Employee(id, firstName, lastName, email)));
            }
            else
            {
                var employee = new Employee(id, firstName, lastName, email);
                _b4.Add(employee);
                var employees = _b4.GetAll();
                Assert.AreEqual(1, employees.Count);
                Assert.AreEqual(firstName, employees.First().FirstName);
            }
        }
        [Test]
        [TestCase(1, "ha", "le", "hahahaha-email")] 
        [TestCase(2, "ha", "le", "hale@gmail.com")] 
        public void AddTheoemail(int id, string firstName, string lastName, string email)
        {
            if (!email.Contains("@"))
            {
                Assert.Throws<ArgumentException>(() => _b4.Add(new Employee(id, firstName, lastName, email)));
            }
            else
            {
                var employee = new Employee(id, firstName, lastName, email);
                _b4.Add(employee);
                var employees = _b4.GetAll();
                Assert.AreEqual(1, employees.Count);
                Assert.AreEqual(email, employees.First().Email);
            }
        }
        [Test]
        [TestCase(1, "thanh", "ha", "thanhha@gmail.com", 1, "ha", "le", "ha@gmail.com")] 
        [TestCase(2, "thanh", "ha", "thanhha@gmail.com", 1, "ha", "le", "hahahahahahahah")] 
        public void Update(int id, string firstName, string lastName, string email, int idUpdate, string firstNameUpdate, string lastNameUpdate, string emailUpdate)
        {
            var employee = new Employee(id, firstName, lastName, email);
            _b4.Add(employee);

            if (!emailUpdate.Contains("@"))
            {
                Assert.Throws<ArgumentException>(() => _b4.Update(new Employee(idUpdate, firstNameUpdate, lastNameUpdate, emailUpdate)));
            }
            else
            {
                var employeeUpdate = new Employee(idUpdate, firstNameUpdate, lastNameUpdate, emailUpdate);
                _b4.Update(employeeUpdate);
                var employees = _b4.GetAll();
                Assert.AreEqual(1, employees.Count);
                Assert.AreEqual(firstNameUpdate, employees.First().FirstName);
                Assert.AreEqual(emailUpdate, employees.First().Email);
            }
        }

        [Test]
        [TestCase(1, "ha", "le", "hale@gmail.com", 2)]
        public void Deletekhongtontai(int id, string firstName, string lastName, string email, int idNotExists)
        {
            var employee = new Employee(id, firstName, lastName, email);
            _b4.Add(employee);

            _b4.Delete(idNotExists); 

            var employees = _b4.GetAll();
            Assert.AreEqual(1, employees.Count);
        }
    }
}
