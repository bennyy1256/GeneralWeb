using AutoMapper;
using General.Service.Implement.Mappings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Service.ImplementTests
{
    [TestClass]
    public class TestHooks
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            Mapper.Initialize(x =>
                x.AddProfile<ServiceProfile>());
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {

        }
    }
}
