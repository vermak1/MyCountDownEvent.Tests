using System.Runtime.ExceptionServices;

namespace MyCountDownEvent.Tests
{
    public class MyCountDownEvent_Threading_Tests
    {

        [Test]
        public void Wait_Test()
        {
            CMyCountdownEvent cd = new CMyCountdownEvent(5);
            Thread t1 = new Thread(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    cd.Signal();
                }
            });

            Thread t2 = new Thread(() =>
            {
                cd.Wait();
            });

            t1.Start();
            t2.Start();

            if (t2.Join(1000))
                Assert.Pass();
            Assert.Fail();
        }

        [Test]
        public void ParallelSignal_Test()
        {
            CMyCountdownEvent cd = new CMyCountdownEvent(100);

            Thread t1 = new Thread(() =>
            {
                for (int i = 0; i < 50; i++)
                    cd.Signal();
            });

            Thread t2 = new Thread(() =>
            {
                for (int i = 0; i < 50; i++)
                    cd.Signal();
            });

            t1.Start();
            t2.Start();

            if (cd.Wait(TimeSpan.FromSeconds(5)))
                Assert.Pass();
            Assert.Fail();
        }
    }
}
