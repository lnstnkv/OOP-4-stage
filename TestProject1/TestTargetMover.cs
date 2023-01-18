using System;
using System.Drawing;
using NUnit.Framework;
using Moq;
using WindowsFormsApp1;


namespace TestProject1
{
    public class TestTargetMover
    {
        // Класс хороших данных 
        [Test]
        public void MoveTargetEuclid_DownToPositiveDirection_ReturnPoint()
        {
            var targetMover = new TargetMoverEuclidean();
            var expected = new Point(1, 0);

            var actual = targetMover.TargetMove(new Point(1, 1), new Point(1, 0));

            Assert.AreEqual(expected, actual);
        }

        // Класс хороших данных
        [Test]
        public void MoveTargetEuclid_UpToPositiveDirection_ReturnPoint()
        {
            var targetMover = new TargetMoverEuclidean();
            var expected = new Point(5, 2);

            var actual = targetMover.TargetMove(new Point(5, 1), new Point(5, 2));

            Assert.AreEqual(expected, actual);
        }
        
        // Класс хороших данных
        [Test]
        public void MoveTargetEuclid_ToTwoDirection_ReturnPoint()
        {
            var targetMover = new TargetMoverEuclidean();
            var expected = new Point(5, 2);

            var actual = targetMover.TargetMove(new Point(5, 1), new Point(6, 2));

            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void MoveTargetEuclid_ToTwoNegativeDirection_ReturnPoint()
        {
            var targetMover = new TargetMoverSavingDirection();
            var expected = new Point(5, 2);

            var actual = targetMover.TargetMove(new Point(6, 2), new Point(5, 1));

            Assert.AreEqual(expected, actual);
        }
        
        // Класс хороших данных
        [Test]
        public void MoveTargetEuclid_OnePlace_ReturnPoint()
        {
            var targetMover = new TargetMoverEuclidean();
            var expected = new Point(5, 5);

            var actual = targetMover.TargetMove(new Point(5, 5), new Point(5, 5));

            Assert.AreEqual(expected, actual);
        }


        // Класс хороших данных
        [Test]
        public void MoveTargetEuclid_ToLeftSidePositiveDirection_ReturnPoint()
        {
            var targetMover = new TargetMoverEuclidean();
            var expected = new Point(1, 1);

            var actual = targetMover.TargetMove(new Point(0, 1), new Point(1, 1));

            Assert.AreEqual(expected, actual);
        }

        // Класс плохих данных
        [Test]
        public void MoveTargetEuclid_OffMapToLeft_ReturnOriginCoordinate()
        {
            var targetMover = new TargetMoverEuclidean();
            var expected = new Point(5, 4);

            var actual = targetMover.TargetMove(new Point(6, 4), new Point(5, 4));

            Assert.AreEqual(expected, actual);
        }

        // Класс плохих данных
        [Test]
        public void MoveTargetEuclid_OffMapToLeftAndSameY_ReturnOriginCoordinate()
        {
            var targetMover = new TargetMoverEuclidean();
            var expected = new Point(0, 0);

            var actual = targetMover.TargetMove(new Point(0, 0), new Point(-1, 0));

            Assert.AreEqual(expected, actual);
        }

        // Класс плохих данных
        [Test]
        public void MoveTargetEuclid_OffMapToLeftAndSameX_ReturnOriginCoordinate()
        {
            var targetMover = new TargetMoverEuclidean();
            var expected = new Point(0, 0);

            var actual = targetMover.TargetMove(new Point(0, 0), new Point(0, -1));

            Assert.AreEqual(expected, actual);
        }


        // Класс плохих данных
        [Test]
        public void MoveTargetEuclid_OffMapToRight_ReturnOriginCoordinate()
        {
            var targetMover = new TargetMoverEuclidean();
            var expected = new Point(1000, 1000);

            var actual = targetMover.TargetMove(new Point(1000, 1000), new Point(1002, 10002));

            Assert.AreEqual(expected, actual);
        }

        // Класс плохих данных
        [Test]
        public void MoveTargetEuclid_OffMapToRightAndSameY_ReturnOriginCoordinate()
        {
            var targetMover = new TargetMoverEuclidean();
            var expected = new Point(1000, 1000);

            var actual = targetMover.TargetMove(new Point(1000, 1000), new Point(1002, 1000));

            Assert.AreEqual(expected, actual);
        }

        // Класс плохих данных
        [Test]
        public void MoveTargetEuclid_OffMapToRightAndSameX_ReturnOriginCoordinate()
        {
            var targetMover = new TargetMoverEuclidean();
            var expected = new Point(1000, 1000);

            var actual = targetMover.TargetMove(new Point(1000, 1000), new Point(1000, 10002));

            Assert.AreEqual(expected, actual);
        }

        // Класс хороших данных
        [Test]
        public void MoveTargetEuclid_ToRightSidePositiveDirection_ReturnPoint()
        {
            var targetMover = new TargetMoverEuclidean();
            var expected = new Point(2, 1);

            var actual = targetMover.TargetMove(new Point(1, 1), new Point(2, 1));

            Assert.AreEqual(expected, actual);
        }

        // Класс хороших данных
        [Test]
        public void MoveTargetSavingDirection_ToLeftSidePositiveDirection_ReturnPoint()
        {
            var targetMover = new TargetMoverSavingDirection();
            var expected = new Point(1, 1);

            var actual = targetMover.TargetMove(new Point(0, 1), new Point(1, 1));

            Assert.AreEqual(expected, actual);
        }

        // Класс хороших данных
        [Test]
        public void MoveTargetSavingDirection_InPlaceToPositiveDirection_ReturnPoint()
        {
            var targetMover = new TargetMoverSavingDirection();
            var expected = new Point(1, 1);

            var actual = targetMover.TargetMove(new Point(1, 1), new Point(1, 1));

            Assert.AreEqual(expected, actual);
        }
        
        // Класс хороших данных
        [Test]
        public void MoveTargetSavingDirection_ToTwoPositiveDirection_ReturnPoint()
        {
            var targetMover = new TargetMoverSavingDirection();
            var expected = new Point(6, 1);

            var actual = targetMover.TargetMove(new Point(5, 1), new Point(6, 2));

            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void MoveTargetSavingDirection_ToTwoNegativeDirection_ReturnPoint()
        {
            var targetMover = new TargetMoverSavingDirection();
            var expected = new Point(5, 2);

            var actual = targetMover.TargetMove(new Point(6, 2), new Point(5, 1));

            Assert.AreEqual(expected, actual);
        }
        
        // Класс хороших данных
        [Test]
        public void MoveTargetSavingDirection_UpToPositiveDirection_ReturnPoint()
        {
            var targetMover = new TargetMoverSavingDirection();
            var expected = new Point(5, 1);

            var actual = targetMover.TargetMove(new Point(5, 0), new Point(5, 1));

            Assert.AreEqual(expected, actual);
        }

        // Класс хороших данных
        [Test]
        public void MoveTargetSavingDirection_DownToPositiveDirection_ReturnPoint()
        {
            var targetMover = new TargetMoverSavingDirection();
            var expected = new Point(5, 1);

            var actual = targetMover.TargetMove(new Point(5, 2), new Point(5, 1));

            Assert.AreEqual(expected, actual);
        }

        
        // Класс хороших данных
        [Test]
        public void MoveTargetSavingDirection_TiRightDirection_ReturnPoint()
        {
            var targetMover = new TargetMoverSavingDirection();
            var expected = new Point(5, 4);

            var actual = targetMover.TargetMove(new Point(6, 4), new Point(5, 4));

            Assert.AreEqual(expected, actual);
        }
        
        // Класс плохих данных
        [Test]
        public void MoveTargetSavingDirection_WhenOffMapOnLeft_ReturnOriginCoordinate()
        {
            var targetMover = new TargetMoverSavingDirection();
            var expected = new Point(0, 0);

            var actual = targetMover.TargetMove(new Point(0, 0), new Point(-1, -1));

            Assert.AreEqual(expected, actual);
        }

        // Класс плохих данных
        [Test]
        public void MoveTargetSavingDirection_WhenOffMapOnLeftAndSameY_ReturnOriginCoordinate()
        {
            var targetMover = new TargetMoverSavingDirection();
            var expected = new Point(0, 0);

            var actual = targetMover.TargetMove(new Point(0, 0), new Point(-1, 0));

            Assert.AreEqual(expected, actual);
        }

        // Класс плохих данных
        [Test]
        public void MoveTargetSavingDirection_WhenOffMapOnLeftAndSameX_ReturnOriginCoordinate()
        {
            var targetMover = new TargetMoverSavingDirection();
            var expected = new Point(0, 0);

            var actual = targetMover.TargetMove(new Point(0, 0), new Point(0, -1));

            Assert.AreEqual(expected, actual);
        }


        // Класс плохих данных
        [Test]
        public void MoveTargetSavingDirection_WhenOffMapOnRight_ReturnOriginCoordinate()
        {
            var targetMover = new TargetMoverSavingDirection();
            var expected = new Point(1000, 1000);

            var actual = targetMover.TargetMove(new Point(1000, 1000), new Point(1002, 10002));

            Assert.AreEqual(expected, actual);
        }

        // Класс плохих данных
        [Test]
        public void MoveTargetSavingDirection_WhenOffMapOnRightAndSameY_ReturnOriginCoordinate()
        {
            var targetMover = new TargetMoverSavingDirection();
            var expected = new Point(1000, 1000);

            var actual = targetMover.TargetMove(new Point(1000, 1000), new Point(1002, 1000));

            Assert.AreEqual(expected, actual);
        }

        // Класс плохих данных
        [Test]
        public void MoveTargetSavingDirection_WhenOffMapOnRightAndSameX_ReturnOriginCoordinate()
        {
            var targetMover = new TargetMoverSavingDirection();
            var expected = new Point(1000, 1000);

            var actual = targetMover.TargetMove(new Point(1000, 1000), new Point(1000, 10002));

            Assert.AreEqual(expected, actual);
        }
    }
}