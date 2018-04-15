using System;
using Fehlersuche_mit_Unittests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unittests_zur_Fehlersuche
{
    [TestClass]
    public class BerechnenTest
    {
        [TestMethod]
        public void TestPlus()
        {
            double zahl1 = 15.3;
            double zahl2 = 14.7;
            string operation = "+";

            double ergebnis = Program.Berechne(zahl1, zahl2, operation);

            Assert.AreEqual(ergebnis, 30.0);
        }

        [TestMethod]
        public void TestMinus()
        {
            double zahl1 = 15.3;
            double zahl2 = 14.7;
            string operation = "-";

            double ergebnis = Program.Berechne(zahl1, zahl2, operation);

            Assert.AreEqual(ergebnis, 0.5);
        }

        [TestMethod]
        public void TestMal()
        {
            double zahl1 = 5;
            double zahl2 = 4;
            string operation = "*";

            double ergebnis = Program.Berechne(zahl1, zahl2, operation);

            Assert.AreEqual(ergebnis, 20.5);
        }

        [TestMethod]
        public void TestGeteilt()
        {
            double zahl1 = 100;
            double zahl2 = 20;
            string operation = "/";

            double ergebnis = Program.Berechne(zahl1, zahl2, operation);

            Assert.AreEqual(ergebnis, 5);
        }

        [TestMethod]
        public void TestUngueltigerOperand()
        {
            double zahl1 = 15.3;
            double zahl2 = 14.7;
            string operation = "e";
            

            Assert.ThrowsException<InvalidOperationException>(new Action(() => { Program.Berechne(zahl1, zahl2, operation); }));
        }
    }
}
