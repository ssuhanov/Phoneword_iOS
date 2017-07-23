
using System;
using NUnit.Framework;
using Phoneword_iOS;

namespace Phoneword_iOS_Tests.Helpers
{
    [TestFixture]
    public class PhoneTranslatorTests
    {
        string instance;

        string correctPhoneNumber1 = "9262746";
        string correctPhoneNumber2 = "23 4 926";
        string correctPhoneNumber3 = "";

        [Test]
        public void CorrectTranslate1()
        {
            instance = "Xamarin";
            string result = instance.ToPhoneNumber();
            Assert.AreEqual(result, correctPhoneNumber1, string.Format("{0} should be translated to {1}", instance, correctPhoneNumber1));
        }

		[Test]
		public void CorrectTranslate2()
		{
            instance = "2,3 4 Xam";
			string result = instance.ToPhoneNumber();
            Assert.AreEqual(result, correctPhoneNumber2, string.Format("{0} should be translated to {1}", instance, correctPhoneNumber2));
		}

		[Test]
		public void CorrectTranslate3()
		{
            instance = "???";
			string result = instance.ToPhoneNumber();
            Assert.AreEqual(result, correctPhoneNumber3, string.Format("{0} should be translated to {1}", instance, correctPhoneNumber3));
		}
	}
}
