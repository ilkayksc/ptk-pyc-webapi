using Xunit;

namespace PycApi.TestX
{
    public class Calculator
    {
        public int Addition(int n1, int n2) => n1 + n2;
        public int Multiplication(int n1, int n2) => n1 * n2;
        public int Subtraction(int n1, int n2) => n1 - n2;
        public double Division(double n1, double n2) => n1 / n2;
    }

    public class CalculatorTest
    {


        [Fact]
        public void AddTwoNumbers()
        {
            // Arrange
            int number1 = 5;
            int number2 = 15;
            Calculator sut = new Calculator();

            // Act
            int result = sut.Addition(number1, number2);

            // Assert
            Assert.Equal(20, result);
        }

        [Fact]
        public void SubtractTest()
        {
            // Arrange
            int number1 = 10;
            int number2 = 20;
            int expected = -10;
            Calculator mathematics = new Calculator();

            //Act
            int result = mathematics.Subtraction(number1, number2);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void MultiplyTwoNumbers()
        {
            // Arrange
            int number1 = 3;
            int number2 = 5;
            Calculator sut = new Calculator();

            // Act
            int result = sut.Multiplication(number1, number2);

            // Assert    // Equal<T>(T expected, T actual)
            Assert.Equal(15, result);
        }
    }
}
