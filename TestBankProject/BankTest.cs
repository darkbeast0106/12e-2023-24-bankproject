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
        [Test]
        // FvNeve_MilyenEsetben_MitCsinál
        public void UjSzamla_HelyesAdatokkal_Egyenleg0Ft()
        {
            Bank bank = new Bank();
            
            bank.UjSzamla("Gipsz Jakab", "1234");

            Assert.That(bank.Egyenleg("1234"), Is.Zero);
        }

        [Test]
        public void UjSzamla_NullNevvel_ArgumentNullExceptiontDob()
        {
            Bank bank = new Bank();

            Assert.Throws<ArgumentNullException>(() => bank.UjSzamla(null, "1234"));
        }

        [Test]
        public void UjSzamla_UresNevvel_ArgumentExceptiontDob()
        {
            Bank bank = new Bank();

            Assert.Throws<ArgumentException>(() => bank.UjSzamla("", "1234"));
        }

        [Test]
        public void UjSzamla_NullSzamlaszammal_ArgumentNullExceptiontDob()
        {
            Bank bank = new Bank();

            Assert.Throws<ArgumentNullException>(() => bank.UjSzamla("Gipsz Jakab", null));
        }

        [Test]
        public void UjSzamla_UresSzamlaszammal_ArgumentExceptiontDob()
        {
            Bank bank = new Bank();

            Assert.Throws<ArgumentException>(() => bank.UjSzamla("Gipsz Jakab", ""));
        }

        [Test]
        public void UjSzamla_LetezoSzamlaszammal_ArgumentExceptiontDob()
        {
            Bank bank = new Bank();

            bank.UjSzamla("Gipsz Jakab", "1234");

            Assert.Throws<ArgumentException>(() => bank.UjSzamla("Teszt Elek", "1234"));
        }


        [Test]
        public void UjSzamla_LetezoNevvel_NemDobExceptiont()
        {
            Bank bank = new Bank();

            bank.UjSzamla("Gipsz Jakab", "1234");

            Assert.DoesNotThrow(() => bank.UjSzamla("Gipsz Jakab", "4321"));
        }
    }
}
