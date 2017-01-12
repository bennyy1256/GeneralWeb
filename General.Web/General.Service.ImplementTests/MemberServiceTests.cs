using Microsoft.VisualStudio.TestTools.UnitTesting;
using General.Service.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using General.Service.Validation.ParameterValidate;
using General.Service.Interface;
using NSubstitute;
using FluentAssertions;

namespace General.Service.Implement.Tests
{
    [TestClass()]
    public class MemberServiceTests
    {
        private IMemberService MemberService { get; set; }

        [TestInitialize()]
        public void MyTestInitial()
        {
            //this.MemberService = Substitute.For<IMemberService>();
        }

        private MemberService GetSystemUnderTest()
        {
            var sut = new MemberService();
            return sut;
        }

        [Owner("Benny")]
        [TestMethod()]
        [TestCategory("MemberService")]
        public void IsExist_Name_Tom_Email_Age_19_ShouldReturn_True()
        {
            // arrange
            var name = "Tom";
            var email = "TOM@GMAIL.COM";
            var age = 19;

            var sut = this.GetSystemUnderTest();

            // act
            var actual = sut.IsExist(name, email, age);

            // assert
            actual.Should().BeTrue();
        }

        [Owner("Benny")]
        [TestMethod()]
        [TestCategory("MemberService")]
        public void IsExist_Name_Tom_Email_Age_SmallerThan18_ShouldThrow_ArgumentOutOfRangeException()
        {
            // arrange
            var name = "Tom";
            var email = "TOM@GMAIL.COM";
            var age = 17;

            var sut = this.GetSystemUnderTest();

            // act
            Action action = () => sut.IsExist(name, email, age);

            // assert
            action.ShouldThrow<ArgumentOutOfRangeException>();
        }
    }
}