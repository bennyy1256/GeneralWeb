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
using General.Repository.Interface;
using Ploeh.AutoFixture;
using General.Service.ParameterDto;
using General.Model;
using AutoMapper;
using General.Service.Implement.Mappings;

namespace General.Service.Implement.Tests
{
    [TestClass()]
    public class MemberServiceTests
    {
        private IMemberRepository MemberRepository { get; set; }

        [TestInitialize()]
        public void MyTestInitial()
        {
            this.MemberRepository = Substitute.For<IMemberRepository>();
        }

        private MemberService GetSystemUnderTest()
        {
            var sut = new MemberService(this.MemberRepository);
            return sut;
        }

        [TestMethod()]
        [Owner("Benny")]
        [TestCategory("MemberService")]
        [TestProperty("MemberService", "IsExist")]
        public void IsExist_Name_Tom_Email_Age_19_ShouldReturn_True()
        {
            // arrange
            var name = "Tom";
            var email = "TOM@GMAIL.COM";
            var age = 19;

            var sut = this.GetSystemUnderTest();

            // act
            var actual = sut.IsExist(name, email);

            // assert
            actual.Should().BeTrue();
        }

        [Ignore]
        [TestMethod()]
        [Owner("Benny")]
        [TestCategory("MemberService")]
        [TestProperty("MemberService", "IsExist")]
        public void IsExist_Name_Tom_Email_Age_SmallerThan18_ShouldThrow_ArgumentOutOfRangeException()
        {
            // arrange
            var name = "Tom";
            var email = "TOM@GMAIL.com";

            var sut = this.GetSystemUnderTest();

            // act
            Action action = () => sut.IsExist(name, email);

            // assert
            action.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [TestMethod()]
        [Owner("Benny")]
        [TestCategory("MemberService")]
        [TestProperty("MemberService", "SaveMember")]
        public void SaveMember_Input_parameter_ShouldReturn_True()
        {
            // arrange
            var parameter = new MemberParameterDto()
            {
                Id = Guid.NewGuid(),
                Name = "Tom",
                Email = "TOM@GMAIL.COM",
                Password = "EF54AEF83A3F",
                Age = 21
            };

            this.MemberRepository.Save(Arg.Any<MemberModel>()).ReturnsForAnyArgs(true);
            //Mapper.Initialize(x => x.AddProfile<ServiceProfile>());
            var sut = this.GetSystemUnderTest();

            // act
            var actual = sut.SaveMember(parameter);

            // assert
            actual.Should().BeTrue();
        }
    }
}