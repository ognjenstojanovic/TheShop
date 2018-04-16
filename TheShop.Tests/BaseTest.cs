namespace TheShop.Tests
{
    using Autofac.Extras.Moq;
    using NUnit.Framework;

    public class BaseTest
    {
        protected AutoMock Mock { get; private set; }

        [SetUp]
        public virtual void SetUp()
        {
            Mock = AutoMock.GetLoose();
        }

        [TearDown]
        public virtual void TearDown()
        {
            Mock.Dispose();
        }
    }
}