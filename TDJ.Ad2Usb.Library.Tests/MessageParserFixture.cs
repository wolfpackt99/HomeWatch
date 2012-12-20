using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Moq;
using Common.Logging;

namespace TDJ.Ad2Usb.Library.Tests
{
    [TestClass]
    public class MessageParserFixture
    {
        [ClassInitialize]
        public static void Init(TestContext context)
        { 
            
        }

        [TestMethod]
        public void TestBadStringForNullResult()
        {
            var logMock = new Mock<ILog>();

            logMock.Setup(s => s.DebugFormat(It.IsAny<string>(), It.IsAny<object>())).Verifiable();

            var parser = new MessageParser{
                Logger = logMock.Object
            };
            Message expectedResult = null;

            var result = parser.Process("some string");

            result.ShouldBeEquivalentTo(result);

            logMock.Verify();
        }

        [TestMethod]
        public void Vista50PFullMessage()
        { 
            var message = "@[01000001000---------],0e5,[f707000600e5800c0c020000],\"ARMED ***AWAY***** ALL SECURE **\"";
            var logMock = new Mock<ILog>();

            logMock.Setup(s => s.DebugFormat(It.IsAny<string>(), It.IsAny<object>())).Verifiable();

            var parser = new MessageParser{
                Logger = logMock.Object
            };
            Message expectedResult = null;

            var result = parser.Process(message);

            result.ShouldBeEquivalentTo(expectedResult);

            logMock.Verify();
        }
    }
}
