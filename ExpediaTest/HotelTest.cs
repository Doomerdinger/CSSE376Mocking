using System;
using Expedia;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Rhino.Mocks;

namespace ExpediaTest
{
	[TestClass]
	public class HotelTest
	{
		private Hotel targetHotel;
		private readonly int NightsToRentHotel = 5;
		private MockRepository mocks;
		
		[TestInitialize]
		public void TestInitialize()
		{
			targetHotel = new Hotel(NightsToRentHotel);
			mocks = new MockRepository();
		}
		
		[TestMethod]
		public void TestThatHotelInitializes()
		{
			Assert.IsNotNull(targetHotel);
		}
		
		[TestMethod]
		public void TestThatHotelHasCorrectBasePriceForOneDayStay()
		{
			var target = new Hotel(1);
			Assert.AreEqual(45, target.getBasePrice());
		}
		
		[TestMethod]
		public void TestThatHotelHasCorrectBasePriceForTwoDayStay()
		{
			var target = new Hotel(2);
			Assert.AreEqual(90, target.getBasePrice());
		}
		
		[TestMethod]
		public void TestThatHotelHasCorrectBasePriceForTenDaysStay()
		{
			var target = new Hotel(10);
			Assert.AreEqual(450, target.getBasePrice());
		}
		
		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void TestThatHotelThrowsOnBadLength()
		{
			new Hotel(-5);
		}
		
	}
}
