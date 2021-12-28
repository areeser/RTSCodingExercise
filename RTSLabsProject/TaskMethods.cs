using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RTSLabsProject
{

    public class TaskMethods
    {
        public static Dictionary<string, int> aboveBelow(List<int> list, int partition)
        {
            int above = 0;
            int below = 0;
            Dictionary<string, int> aboveBelowCounts = new Dictionary<string, int>();

            //Go through the list and get a count for the number of ints above and below the given number.
            foreach (int number in list)
            {
                if (number > partition)
                    above++;
                else if (number < partition)
                    below++;
                //If the number is equal to the partition number, it is not counted. 
            }

            aboveBelowCounts.Add("above", above);
            aboveBelowCounts.Add("below", below);

            return aboveBelowCounts;
        }

        public static string stringRotation(string stringToRotate, int rotationAmount)
        {
            //Get the location to split the string
            int stringSplit = stringToRotate.Length - rotationAmount;

            //Get a substring for all the letters up to the partition and a substring for all the letters after the partition
            return stringToRotate.Substring(stringSplit) + stringToRotate.Substring(0, stringSplit);
        }
    }

    [TestClass]
    public class RTSLabsTests
    {
        [TestMethod]
        public void AboveBelowTest()
        {
            List<int> list = new List<int> { 1, 5, 2, 1, 10 };
            int partition = 6;
            var dict = TaskMethods.aboveBelow(list, partition);

            Assert.AreEqual(1, dict["above"]);
            Assert.AreEqual(4, dict["below"]);
        }

        [TestMethod]
        public void AboveBelowTest_PartitionInList()
        {
            List<int> list = new List<int> { 1, 5, 5, 3, 10 };
            int partition = 5;
            var dict = TaskMethods.aboveBelow(list, partition);

            Assert.AreEqual(1, dict["above"]);
            Assert.AreEqual(2, dict["below"]);
        }

        [TestMethod]
        public void StringRotationTest()
        {
            string stringToRotate = "myString";
            int rotationAmount = 2;
            string rotatedString = TaskMethods.stringRotation(stringToRotate, rotationAmount);
            Assert.AreEqual("ngmyStri", rotatedString);
        }

        [TestMethod]
        public void StringRotationTest_OddLengthString()
        {
            string stringToRotate = "myOtherString";
            int rotationAmount = 5;
            string rotatedString = TaskMethods.stringRotation(stringToRotate, rotationAmount);
            Assert.AreEqual("tringmyOtherS", rotatedString);
        }
    }
}
