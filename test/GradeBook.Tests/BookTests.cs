using System;
using src.GradeBook;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {

            /*Typical Stucture */

            // arrange
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // act
            // var min = book.GetMin();    
            // var max = book.GetMax();

            var result = book.GetStatistics();
            
            // assert
            // Assert.Equal(77, min);
            // Assert.Equal(90.5, max);

            Assert.Equal(90.5, result.High);
            Assert.Equal(77.3, result.Low);
        }
    }
}
