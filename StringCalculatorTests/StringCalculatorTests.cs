using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringCalculatorNamespace;

namespace IO_testy
{
    [TestClass]
    public class StringCalculatorTests
    {
        
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(StringCalculator.Add(""), 0);
        }
        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(StringCalculator.Add("5"), 5);
            Assert.AreEqual(StringCalculator.Add("7"), 7);
            Assert.AreEqual(StringCalculator.Add("9"), 9);
            
            Assert.AreEqual(StringCalculator.Add("507"), 507);
            Assert.AreEqual(StringCalculator.Add("720"), 720);
        }
        [TestMethod]
        public void TestMethod3()
        {
            Assert.AreEqual(StringCalculator.Add("5,2"), 7);
            Assert.AreEqual(StringCalculator.Add("71,11"), 82);
            Assert.AreEqual(StringCalculator.Add("83,120"), 83+120);
            
            Assert.AreEqual(StringCalculator.Add("507,121"), 507 + 121);
            Assert.AreEqual(StringCalculator.Add("720,95"), 720+95);
        }
        [TestMethod]
        public void TestMethod4()
        {
            Assert.AreEqual(StringCalculator.Add("5\n2"), 7);
            Assert.AreEqual(StringCalculator.Add("71\n11"), 82);
            Assert.AreEqual(StringCalculator.Add("83\n120"), 83 + 120);
           
            Assert.AreEqual(StringCalculator.Add("507\n121"), 507 + 121);
            Assert.AreEqual(StringCalculator.Add("720\n95"), 720 + 95);
        }
        [TestMethod]
        public void TestMethod5()
        {
            Assert.AreEqual(StringCalculator.Add("5\n2,3,11"), 21);
            Assert.AreEqual(StringCalculator.Add("71\n11\n12"), 71+11+12);
            Assert.AreEqual(StringCalculator.Add("83\n120\n12,23\n45,67\n88"), 83 + 120 + 12 + 23 + 45 + 67 + 88);
            
            Assert.AreEqual(StringCalculator.Add("507\n121,123,12"), 507 + 121 + 123 + 12);
            Assert.AreEqual(StringCalculator.Add("720\n95\n25,12,12,24"), 720 + 95 + 25 + 12 + 12 + 24);
        }
        [TestMethod]
        public void TestMethod6()
        {
            try
            {
                StringCalculator.Add("//-12--21");
                Assert.Fail();
            }
            catch (NegativeNumberException e)
            {
                Console.WriteLine("OK");   
            }
            
        }
        [TestMethod]
        public void TestMethod7()
        {
            Assert.AreEqual(StringCalculator.Add("1001"), 0);
            Assert.AreEqual(StringCalculator.Add("1001,12"), 12);
            Assert.AreEqual(StringCalculator.Add("1001\n21,999"), 21 + 999);
            Assert.AreEqual(StringCalculator.Add("1001\n85\n1"), 85+1);
        }
        [TestMethod]
        public void TestMethod8()
        {
            Assert.AreEqual(StringCalculator.Add("//#101#12#34"), 101+12+34);
            Assert.AreEqual(StringCalculator.Add("//+101+12"), 101+12);
            //Assert.AreEqual(StringCalculator.Add("//-11-21-999"), 21 + 999 + 11);
            Assert.AreEqual(StringCalculator.Add("//.101.85.1"), 85 + 1 + 101);
        }
        [TestMethod]
        public void TestMethod9()
        {
            Assert.AreEqual(StringCalculator.Add("//[###]123###25"), 123 + 25);
        }
        [TestMethod]
        public void TestMethod10()
        {
            Assert.AreEqual(StringCalculator.Add("//[###][&&]123###25&&32"), 123 + 25 + 32);
        }
    }
}
