using BankProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBankProject
{
    internal class BankTest
    {
        Bank bank;

        [SetUp]
        public void Setup()
        {
            bank = new Bank();
        }

        [Test]
        // FvNeve_MilyenEsetben_MitCsinál
        public void UjSzamla_HelyesAdatokkal_Egyenleg0Ft()
        {
            
            bank.UjSzamla("Gipsz Jakab", "1234");

            Assert.That(bank.Egyenleg("1234"), Is.Zero);
        }

        [Test]
        public void UjSzamla_NullNevvel_ArgumentNullExceptiontDob()
        {
            Assert.Throws<ArgumentNullException>(() => bank.UjSzamla(null, "1234"));
        }

        [Test]
        public void UjSzamla_UresNevvel_ArgumentExceptiontDob()
        {
            Assert.Throws<ArgumentException>(() => bank.UjSzamla("", "1234"));
        }

        [Test]
        public void UjSzamla_NullSzamlaszammal_ArgumentNullExceptiontDob()
        {
            Assert.Throws<ArgumentNullException>(() => bank.UjSzamla("Gipsz Jakab", null));
        }

        [Test]
        public void UjSzamla_UresSzamlaszammal_ArgumentExceptiontDob()
        {
            Assert.Throws<ArgumentException>(() => bank.UjSzamla("Gipsz Jakab", ""));
        }

        [Test]
        public void UjSzamla_LetezoSzamlaszammal_ArgumentExceptiontDob()
        {
            bank.UjSzamla("Gipsz Jakab", "1234");

            Assert.Throws<ArgumentException>(() => bank.UjSzamla("Teszt Elek", "1234"));
        }


        [Test]
        public void UjSzamla_LetezoNevvel_NemDobExceptiont()
        {
            bank.UjSzamla("Gipsz Jakab", "1234");

            Assert.DoesNotThrow(() => bank.UjSzamla("Gipsz Jakab", "4321"));
        }


    }
}
