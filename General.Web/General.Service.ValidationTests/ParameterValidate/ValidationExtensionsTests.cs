using Microsoft.VisualStudio.TestTools.UnitTesting;
using General.Service.Validation.ParameterValidate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;


namespace General.Service.Validation.ParameterValidate.Tests
{
    [TestClass()]
    public class ValidationExtensionsTests
    {

        [TestMethod()]
        [Owner("Benny")]
        [TestCategory("ValidationExtensions")]
        public void NotNull_Obj_123_ShouldRetuen_True()
        {
            // arrange
            var validation = new Validation();
            var obj = "123";

            // act
            var actual = validation.NotNull(obj);

            // assert
            actual.IsValid.Should().BeTrue();
        }
    }
}