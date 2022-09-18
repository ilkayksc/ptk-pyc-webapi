using Moq;
using PycApi.Data;
using System.Collections.Generic;
using Xunit;

namespace PycApi.TestX
{
    public class MoqTest
    {
        private readonly Mock<IHibernateRepository<Book>> _mockRepo;
        private readonly BookController _controller;


        public MoqTest()
        {
            _mockRepo = new Mock<IHibernateRepository<Book>>();
            _controller = new BookController(_mockRepo.Object);

            _mockRepo.Setup(repo => repo.GetAll()).Returns(new List<Book>() { new Book { Title = "Doly" }, new Book { Title = "Mopsa" } });
        }


        [Fact]
        public void Index_ActionExecutes_ReturnsViewForIndex()
        {
            var result = _controller.Get();
            Assert.IsType<List<Book>>(result);
        }

        [Fact]
        public void Index_ActionExecutes_ReturnsViewForIndex_Detail()
        {
            var result = _controller.GetItem(1);
            Assert.IsType<Book>(result);
        }

        [Fact]
        public void Index_ActionExecutes_ReturnsExactNumberOfEmployees()
        {          
            var result = _controller.Get();
            var viewResult = Assert.IsType<List<Book>>(result);
            Assert.Equal(2, viewResult.Count);
        }

    }
}
