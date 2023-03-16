namespace MyCountDownEvent.Tests
{
    public class MyCountDownEvent_MainLogic_Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ZeroInitialCount_Test()
        {
            CMyCountdownEvent cd = new CMyCountdownEvent(0);
            if (cd.Wait(TimeSpan.FromSeconds(1)))
                Assert.Pass();
            Assert.Fail();
        }

        [Test]
        public void NegativeValueOfInitialCount_Test()
        {
            try
            {
                CMyCountdownEvent cd = new CMyCountdownEvent(-5);
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [Test]
        public void MoreSignalCountThanCount_Test()
        {
            try
            {
                CMyCountdownEvent cd = new CMyCountdownEvent(4);
                for (int i = 0; i < 5; i++)
                    cd.Signal();
            }
            catch 
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [Test]
        public void LessSignalCountThanCount_Test()
        {
            try
            {
                CMyCountdownEvent cd = new CMyCountdownEvent(5);
                for (int i = 0; i < 4; i++)
                    cd.Signal();
            }
            catch
            {
                Assert.Fail();
            }
            Assert.Pass();
        }

        [Test]
        public void SignalWithValueMoreThanCount_Test()
        {
            try
            {
                CMyCountdownEvent cd = new CMyCountdownEvent(5);
                cd.Signal(6);
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }


        [Test]
        public void SignalWithValueLessThanCount_Test()
        {
            try
            {
                CMyCountdownEvent cd = new CMyCountdownEvent(5);
                cd.Signal(4);
            }
            catch
            {
                Assert.Fail();
            }
            Assert.Pass();
        }


        [Test]
        public void TimeOutWait_Test()
        {
            CMyCountdownEvent cd = new CMyCountdownEvent(5);
            if (!cd.Wait(TimeSpan.FromSeconds(2)))
                Assert.Pass();
            Assert.Fail();
        }

    }
}