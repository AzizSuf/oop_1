using Ex3_1_RomanConverter;

namespace RomanConverterTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestFromRomanToArabic()
        {
            Assert.AreEqual(RomanConverter.ToArabic("I"), 1);
            Assert.AreEqual(RomanConverter.ToArabic("II"), 2);
            Assert.AreEqual(RomanConverter.ToArabic("XII"), 12);
            Assert.AreEqual(RomanConverter.ToArabic("VI"), 6);
            Assert.AreEqual(RomanConverter.ToArabic("IV"), 4);
            Assert.AreEqual(RomanConverter.ToArabic("MMMCMXCIX"), 3999);
            Assert.AreEqual(RomanConverter.ToArabic("XX"), 20);
            Assert.AreEqual(RomanConverter.ToArabic("CCLXXXVIII"), 288);
            Assert.AreEqual(RomanConverter.ToArabic("MMDCCLXXVI"), 2776);
            Assert.AreEqual(RomanConverter.ToArabic("XC"), 90);
            Assert.AreEqual(RomanConverter.ToArabic("XXX"), 30);
        }

        [TestMethod]
        public void TestFromArabicToRoman()
        {
            Assert.AreEqual(RomanConverter.ToRoman(1), "I");
            Assert.AreEqual(RomanConverter.ToRoman(2), "II");
            Assert.AreEqual(RomanConverter.ToRoman(12), "XII");
            Assert.AreEqual(RomanConverter.ToRoman(6), "VI");
            Assert.AreEqual(RomanConverter.ToRoman(4), "IV");
            Assert.AreEqual(RomanConverter.ToRoman(3999), "MMMCMXCIX");
            Assert.AreEqual(RomanConverter.ToRoman(20), "XX");
            Assert.AreEqual(RomanConverter.ToRoman(288), "CCLXXXVIII");
            Assert.AreEqual(RomanConverter.ToRoman(2776), "MMDCCLXXVI");
            Assert.AreEqual(RomanConverter.ToRoman(90), "XC");
            Assert.AreEqual(RomanConverter.ToRoman(30), "XXX");
        }
    }
}
