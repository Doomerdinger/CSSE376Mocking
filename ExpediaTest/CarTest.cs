using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Expedia;
using Rhino.Mocks;

namespace ExpediaTest
{
	[TestClass]
	public class CarTest
	{	
		private Car targetCar;
		private MockRepository mocks;
		
		[TestInitialize]
		public void TestInitialize()
		{
			targetCar = new Car(5);
			mocks = new MockRepository();
		}
		
		[TestMethod]
		public void TestThatCarInitializes()
		{
			Assert.IsNotNull(targetCar);
		}	
		
		[TestMethod]
		public void TestThatCarHasCorrectBasePriceForFiveDays()
		{
			Assert.AreEqual(50, targetCar.getBasePrice()	);
		}
		
		[TestMethod]
		public void TestThatCarHasCorrectBasePriceForTenDays()
		{
            var target = new Car(10);
			Assert.AreEqual(80, target.getBasePrice());	
		}
		
		[TestMethod]
		public void TestThatCarHasCorrectBasePriceForSevenDays()
		{
			var target = new Car(7);
			Assert.AreEqual(10*7*.8, target.getBasePrice());
		}

        [TestMethod()]
        public void TestThatCarGetsLocationFromDatabase()
        {
            IDatabase mockDB = mocks.StrictMock<IDatabase>();
            String carLocation1 = "Bottom of the ocean";
            String carLocation2 = "Germany";
            Expect.Call(mockDB.getCarLocation(1)).Return(carLocation1);
            Expect.Call(mockDB.getCarLocation(2)).Return(carLocation2);
            mocks.ReplayAll();
            Car target = new Car(10);
            target.Database = mockDB;            String result;
            result = target.getCarLocation(1);
            Assert.AreEqual(carLocation1, result);

            result = target.getCarLocation(2);
            Assert.AreEqual(carLocation2, result);

            mocks.VerifyAll();
        }

        [TestMethod()]
        public void TestThatCarGetsRightMileage()
        {
            IDatabase mockDatabase = mocks.StrictMock<IDatabase>();
            Int32 miles = 96324;
            Expect.Call(mockDatabase.Miles).PropertyBehavior();
            mocks.ReplayAll();
            mockDatabase.Miles = miles;
            var target = new Car(10);
            target.Database = mockDatabase;
            Int32 mileNum = target.Mileage;
            Assert.AreEqual(mileNum, miles);
            mocks.VerifyAll();
        }

        [TestMethod()]
        public void TestThatObjectMotherBMWRightName()
        {
            String name = "BMW red car thing";
            var target = ObjectMother.BMW();
            Assert.AreEqual(name, target.Name);
        }
		
		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void TestThatCarThrowsOnBadLength()
		{
			new Car(-5);
		}
	}
}
