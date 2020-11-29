using MarsRover.ConsoleApp;
using Xunit;

namespace MarsRover.UnitTest
{
    public class UnitTest
    {
        [Fact]
        public void CreateBoard_CheckIfNull()
        {
            //var result = Record.Exception(() => DateTime.Now.ToPrettyDate(null));
            //Assert.NotNull(result);
            //var exception = Assert.IsType<ArgumentNullException>(result);
            //var actual = exception.ParamName;
            //const string expected = "culture";
            //Assert.Equal(expected, actual);
           //Program.Process()
            
        }


        //[Theory, AutoMoqData]
        //public void CreateNewCustomer_Should_Success([Frozen] Mock<ICustomerAssembler> assembler, [Frozen] Mock<ICustomerRepository> repository, CustomerDto customerDto, Domain.Customer customer, CustomerService sut)
        //{
        //    assembler.Setup(c => c.ToCustomer(customerDto)).Returns(customer);
        //    repository.Setup(c => c.Save(customer)).Returns(It.IsAny<Guid>());

        //    Action action = () =>
        //    {
        //        sut.CreateNew(customerDto);
        //    };
        //    action.Should().NotThrow<Exception>();
        //}
    }
}
