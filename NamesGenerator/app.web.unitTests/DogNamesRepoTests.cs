using app.domain;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapp;
using Xunit;

namespace app.web.unitTests
{
    public class DogNamesRepoTests
    {
        [Fact]
        public void TestRepositoryImplementation()
        {
            var dogNames = new List<DogName>()
            {
                new DogName()
                {
                    Name = "Chien Chien"
                }
            };

            var mockDogNamesRepository = new Mock<IRepository<DogName>>();
            mockDogNamesRepository.Setup(r => r.GetAll()).Returns(dogNames.AsQueryable());

            var controllerUnderTest = new HomeController(mockDogNamesRepository.Object);
            var result = controllerUnderTest.Index();
            Assert.IsType<ViewResult>(result);
        }
        
    }
}
