using Business;
using Data;

namespace Test
{
    [TestClass]
    public class ToyTest
    {
        [TestMethod]
        public void GetPlace_MustGenerateException_WhenXisZero()
        {
            // Arrange
            List<Place> places = Logic.GenerateGrid(2);

            // Act and Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Logic.GetPlace(places, 0, 1));
        }

        [TestMethod]
        public void GetPlace_MustGenerateException_WhenYisZero()
        {
            // Arrange
            List<Place> places = Logic.GenerateGrid(2);

            // Act and Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Logic.GetPlace(places, 1, 0));
        }

        [TestMethod]
        public void MoveUp_MustGenerateException_WhenAlreadyOnTop()
        {
            // Arrange
            List<Place> places = Logic.GenerateGrid(2);
            Place currentPlace = Logic.GetPlace(places, 1, 1);

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => Logic.MoveUp(places, currentPlace));
        }

        [TestMethod]
        public void MoveDown_MustGenerateException_WhenAlreadyAtTheBottom()
        {
            // Arrange
            List<Place> places = Logic.GenerateGrid(2);
            Place currentPlace = Logic.GetPlace(places, 2, 2);

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => Logic.MoveDown(places, currentPlace));
        }

        [TestMethod]
        public void MoveRight_MustGenerateException_WhenAlreadyAtTheEnd()
        {
            // Arrange
            List<Place> places = Logic.GenerateGrid(2);
            Place currentPlace = Logic.GetPlace(places, 1, 2);

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => Logic.MoveRight(places, currentPlace));
        }

        [TestMethod]
        public void MoveLeft_MustGenerateException_WhenAlreadyAtTheBeginning()
        {
            // Arrange
            List<Place> places = Logic.GenerateGrid(2);
            Place currentPlace = Logic.GetPlace(places, 2, 1);

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => Logic.MoveLeft(places, currentPlace));
        }
    }
}