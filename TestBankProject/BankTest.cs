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


        [Test]
        public void EgyenlegFeltolt_NullSzamlaszammal_ArgumentNullException()
        {
            bank.UjSzamla("Gipsz Jakab", "1234");

            Assert.Throws<ArgumentNullException>(() => bank.EgyenlegFeltolt(null, 10000));
        }


        [Test]
        public void EgyenlegFeltolt_NemLetezoSzamlaszammal_HibasSzamlaszamException()
        {
            bank.UjSzamla("Gipsz Jakab", "1234");

            Assert.Throws<HibasSzamlaszamException>(() => bank.EgyenlegFeltolt("5678", 10000));
        }


        [Test]
        public void EgyenlegFeltolt_0Osszeg_ArgumentException()
        {
            bank.UjSzamla("Gipsz Jakab", "1234");

            Assert.Throws<ArgumentException>(() => bank.EgyenlegFeltolt("1234", 0));
        }

        [Test]
        public void EgyenlegFeltolt_LetezoSzamlaraEgyszeriFeltoltes_EgyenlegMegvaltozik()
        {
            bank.UjSzamla("Gipsz Jakab", "1234");

            bank.EgyenlegFeltolt("1234", 10000);

            Assert.That(bank.Egyenleg("1234"), Is.EqualTo(10000));
        }

        [Test]
        public void EgyenlegFeltolt_LetezoSzamlaraTobbszoriFeltoltes_EgyenlegOsszeadodik()
        {
            bank.UjSzamla("Gipsz Jakab", "1234");

            bank.EgyenlegFeltolt("1234", 10000);
            bank.EgyenlegFeltolt("1234", 20000);

            Assert.That(bank.Egyenleg("1234"), Is.EqualTo(30000));
        }

        [Test]
        public void EgyenlegFeltolt_TobbSzamlaval_EgyenlegMegfeleloSzamlaraTolt()
        {
            bank.UjSzamla("Gipsz Jakab", "1234");
            bank.UjSzamla("Gipsz Jakab", "4321");
            bank.UjSzamla("Teszt Elek", "5678");

            bank.EgyenlegFeltolt("1234", 10000);
            bank.EgyenlegFeltolt("4321", 20000);
            bank.EgyenlegFeltolt("5678", 50000);

            Assert.That(bank.Egyenleg("1234"), Is.EqualTo(10000));
            Assert.That(bank.Egyenleg("4321"), Is.EqualTo(20000));
            Assert.That(bank.Egyenleg("5678"), Is.EqualTo(50000));
        }
    }
}
