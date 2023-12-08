using LibDB;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PositiveTestGetByID()
        {
            DB db = new DB();
            db.OpenConnection();

            var idToSearch = 5;

            var temp = db.GetID(idToSearch);

            var expectedValues = new List<string>() { "5", "Test", "Hello" };
            var actualValues = new List<string>();

            foreach (var item in temp)
            {
                actualValues.Add(item[0].ToString());
                actualValues.Add(item[1].ToString());
                actualValues.Add(item[2].ToString());
            }

            var expectedString = string.Join("", expectedValues);
            var actualString = string.Join("", actualValues);

            Assert.That(actualValues, Is.EqualTo(expectedValues));

            db.CloseConnection();
        }
        [Test]
        public void NegativeTestGetByID()
        {
            DB db = new DB();
            db.OpenConnection();

            var temp = db.GetID(145);

            var expect = "Запись с таким ID не найдена";
            var actual = "";

            foreach (var item in temp)
            {
                actual = item[0];
            }

            Assert.That(actual, Is.EqualTo(expect));

            db.CloseConnection();
        }

        [Test]
        public void PositiveTestGetByName()
        {
            DB db = new DB();
            db.OpenConnection();

            var temp = db.GetName("Test");

            var expect = 5 + " " + "Test" + " " + "Hello";
            var actual = "";

            foreach (var item in temp)
            {
                actual = item[0] + " " + item[1] + " " + item[2];
            }

            Assert.That(actual, Is.EqualTo(expect));

            db.CloseConnection();


        }

        [Test]
        public void NegativeTestGetByName()
        {
            DB db = new DB();
            db.OpenConnection();

            var temp = db.GetName("Test1");

            var expect = "Запись с таким именем не найдена";
            var actual = "";

            foreach (var item in temp)
            {
                actual = item[0];
            }

            Assert.That(actual, Is.EqualTo(expect));

            db.CloseConnection();

        }

        [Test]
        public void PositiveTestAddData()
        {
            DB db = new DB();
            db.OpenConnection();

            var expect = "Данные добавлены в базу";
            var actual = db.Add(1, "name", "message");

            Assert.That(actual, Is.EqualTo(expect));

            db.CloseConnection();

        }

        [Test]
        public void NegativeTestAddData()
        {
            DB db = new DB();
            db.OpenConnection();

            var expect = "Данные должны быть заполнены";
            var actual = db.Add(6, null, null);

            Assert.That(actual, Is.EqualTo(expect));

            db.CloseConnection();

        }

        [Test]
        public void NegativeTestUpdate()
        {
            DB db = new DB();
            db.OpenConnection();

            var expect = "Запись с таким ID не найдена";
            var actual = db.Update(158, "message");

            Assert.That(actual, Is.EqualTo(expect));

            db.CloseConnection();

        }

        [Test]
        public void PositiveTestUpdate()
        {
            DB db = new DB();
            db.OpenConnection();

            var expect = "Запись успешно обновлена";
            var actual = db.Update(12, "message123");

            Assert.That(actual, Is.EqualTo(expect));

            db.CloseConnection();

        }

        [Test]
        public void NegativeTestDelete()
        {
            DB db = new DB();
            db.OpenConnection();

            var expect = "Запись с таким ID не найдена";
            var actual = db.Delete(158);

            Assert.That(actual, Is.EqualTo(expect));

            db.CloseConnection();

        }

        [Test]
        public void PositiveTestDelete()
        {
            DB db = new DB();
            db.OpenConnection();

            var expect = "Запись удалена успешно";
            var actual = db.Delete(1);

            Assert.That(actual, Is.EqualTo(expect));

            db.CloseConnection();

        }
    }
}