using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using NeuralNetworks;
using System.Collections.Generic;
using System.IO;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        //[TestMethod]
        //public void FeedForwardTest()
        //{
        //    var outputs = new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 };
        //    string[] s = new string[]
        //    {
        //        "взрыв","взрывной","взрывать","взорву","взорвать","подорвать","подрывник","подрывать","взрывная", "убегу"
        //    };
        //    var stringConverter = new StringConverter();
        //    var inputs = stringConverter.Convert(s);

        //    var topology = new Topology(10, 1, 0.01, 3);
        //    var neuralNetwork = new NeuralNetwork(topology);
        //    var difference = neuralNetwork.Learn(outputs, inputs, 100000);

        //    var test = new string[] { "взрыв" };
        //    var results = new List<double>();
        //    for (int i = 0; i < test.Length; i++)
        //    {
        //        var row = NeuralNetwork.GetRow(stringConverter.Convert(test), i);
        //        var res = neuralNetwork.Predict(row).Output;
        //        results.Add(res);
        //    }

        //    var expected = 0;
        //    var actual = Math.Round(results[0], 2);
        //    Assert.AreEqual(expected, actual);
        //}

        [TestMethod]
        public void Test()
        {
            //var outputs = new double[] { 1, 0, 1, 1, 1, 1, 1, 0, 0};
            //var inputs = new double[,]
            //{
            //    {0, 1, 0, 0, 0, 1 },
            //    {0, 1, 0, 0, 0, 0 },
            //    {1, 1, 0, 0, 0, 0 },
            //    {1, 0, 0, 1, 0, 0 },
            //    {1, 1, 1, 1, 0, 0 },
            //    {0, 1, 0, 1, 0, 1 },
            //    {0, 1, 1, 0, 0, 0 },
            //    {0, 0, 0, 0, 0, 1 },
            //    {0, 0, 0, 0, 1, 0 }
            //};
            var outputs = new double[] { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0 };
            var inputs = new double[,]
            {
                {0 },
                {1 },
                {2 },
                {3},
                {4 },
                {5 },
                {6 },
                {7 },
                {8 },
                {9 },
                {10 },
                {11 },
                {12 },
                {13 },
                {14 },
                {15 },
            };
            //var inputs = new double[,]
            //{
            //    {0, 0, 0, 0 },
            //    {0, 0, 0, 1 },
            //    {0, 0, 1, 0 },
            //    {0, 0, 1, 1 },
            //    {0, 1, 0, 0 },
            //    {0, 1, 0, 1 },
            //    {0, 1, 1, 0 },
            //    {0, 1, 1, 1 },
            //    {1, 0, 0, 0 },
            //    {1, 0, 0, 1 },
            //    {1, 0, 1, 0 },
            //    {1, 0, 1, 1 },
            //    {1, 1, 0, 0 },
            //    {1, 1, 0, 1 },
            //    {1, 1, 1, 0 },
            //    {1, 1, 1, 1 },
            //};
            var topology = new Topology(4, 1, 0.01, 2);
            var neuralNetwork = new NeuralNetwork(topology);

            var difference = neuralNetwork.Learn(outputs, inputs, 50000);

            var test = new double[] { 28 };
            var r = neuralNetwork.Predict(test);
            var res = neuralNetwork.Predict(test);
        }
    }
}
