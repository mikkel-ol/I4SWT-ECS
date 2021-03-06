﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSubstitute;
using NUnit.Framework;

namespace ECS.Unit.Test
{
    [TestFixture]
    public class ECSUnitTest
    {
        // Objects pref. interfaces
        private ECS uut = null;
        private ISensor _tempSensor = null;
        private IHeater _heater = null;

        [SetUp] // https://github.com/nunit/docs/wiki/Attributes
        public void setup()
        {
            _tempSensor = Substitute.For<ISensor>();
            _heater = Substitute.For<IHeater>();
            uut = new ECS(10, _tempSensor, _heater);
        }

        [Test]
        public void ECS_CtorInSetupThreshold10_Returns10()
        {
            // work is done in setup

            Assert.That(uut.GetThreshold(), Is.EqualTo(10));
        }

        [TestCase(5, 5)]
        [TestCase(-10, -10)]
        public void SetThreshold_ReturnsCorrectThreshold(int thr, int result)
        {
            uut.SetThreshold(thr);

            Assert.That(uut.GetThreshold(), Is.EqualTo(result));
        }

        [TestCase(5, 5)]
        [TestCase(-10, -10)]
        public void GetCurTemp_ReturnsCorrectTemp(int temp, int result)
        {
            _tempSensor.GetSensorData().Returns(temp);
            
            int currTemp = uut.GetCurTemp();

            Assert.That(currTemp, Is.EqualTo(result));
        }

        [Test]
        public void Regulate_TempThresholdIs10TempIsNeg5_TurnOnCalled()
        {
            _tempSensor.GetSensorData().Returns(-5);
            
            uut.Regulate();

            _heater.Received(1).TurnOn();
        }

        [Test]
        public void Regulate_TempThresholdIs10TempIs15_TurnOffCalled()
        {
            _tempSensor.GetSensorData().Returns(15);

            uut.Regulate();

            _heater.Received(1).TurnOff();
        }

        [TestCase(false, false, false)]
        [TestCase(true, false, false)]
        [TestCase(false, true, false)]
        [TestCase(true, true, true)]
        public void RunSelfTest_StubsReturnsAllBoolValues_ReturnsCorrectBool(bool heaterBool, bool sensorBool, bool result)
        {
            _heater.RunSelfTest().Returns(heaterBool);
            _tempSensor.RunSelfTest().Returns(sensorBool);
            // work is done in setup
            bool selfTestResult = uut.RunSelfTest();

            Assert.That(selfTestResult, Is.EqualTo(result));
        }

        //
        //  OLD HANDWRITTEN FAKES TESTS
        //
        /*
        private ECS uut = null;

        [SetUp] // https://github.com/nunit/docs/wiki/Attributes
        public void setup()
        {
            // setup Using interfaces
            ISensor fakeTempSensor = new FakeTempSensor();
            IHeater fakeHeater = new FakeHeater();
            uut = new ECS(10, fakeTempSensor, fakeHeater);

        }

        /*        [TestCase(1,2,3,TestName ="CaseOne")]
                public void TestTest(double a, double b, double result)
                {
                    Assert.That(result, Is.EqualTo(1 + 2));
                }

        [Test]
        public void ECS_CtorInSetupThreshold10_Returns10()
        {
            // work is done in setup

            Assert.That(uut.GetThreshold(), Is.EqualTo(10));
        }

        [TestCase(5,5)]
        [TestCase(-10, -10)]
        public void SetThreshold_ReturnsCorrectThreshold(int thr, int result)
        {
            uut.SetThreshold(thr);

            Assert.That(uut.GetThreshold(), Is.EqualTo(result));
        }

        [TestCase(5, 5)]
        [TestCase(-10, -10)]
        public void GetCurTemp_ReturnsCorrectTemp(int temp, int result)
        {

            FakeTempSensor fakeTempSensor = new FakeTempSensor();
            FakeHeater fakeHeater = new FakeHeater();
            fakeTempSensor.SetTestTemp(temp);
            uut = new ECS(10, fakeTempSensor, fakeHeater);

            int currTemp = uut.GetCurTemp();

            Assert.That(currTemp, Is.EqualTo(result));
        }

        [TestCase(-5, true)]
        [TestCase(15, false)]
        public void Regulate_TempThresholdIs10_ReturnsCorrectHeatBool(int temp, bool result)
        {

            FakeTempSensor fakeTempSensor = new FakeTempSensor();
            FakeHeater fakeHeater = new FakeHeater();
            uut = new ECS(10, fakeTempSensor, fakeHeater);
            fakeTempSensor.SetTestTemp(temp);

            uut.Regulate();
            bool isHeaterOn = fakeHeater.GetTestHeaterIsOnBool();

            Assert.That(isHeaterOn, Is.EqualTo(result));
        }

        [Test]
        public void RunSelfTest_StubsReturnTrue_ReturnsTrue()
        {
            // work is done in setup
            bool selfTestTrue = uut.RunSelfTest();

            Assert.That(selfTestTrue, Is.EqualTo(true));
        }
        */




    }
    }