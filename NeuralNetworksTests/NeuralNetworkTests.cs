﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeuralNetworks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworks.Tests
{
    [TestClass()]
    public class NeuralNetworkTests
    {
        //[TestMethod()]
        //public void FeedForwardTest()
        //{
        //    var outputs = new double[] { 0, 0, 1, 0, 0, 0, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1 };
        //    var inputs = new double[,]
        //    {
        //        // Результат - Пациент болен - 1
        //        //             Пациент Здоров - 0

        //        // Неправильная температура T
        //        // Хороший возраст A
        //        // Курит S
        //        // Правильно питается F
        //        //T  A  S  F
        //        { 0, 0, 0, 0 },
        //        { 0, 0, 0, 1 },
        //        { 0, 0, 1, 0 },
        //        { 0, 0, 1, 1 },
        //        { 0, 1, 0, 0 },
        //        { 0, 1, 0, 1 },
        //        { 0, 1, 1, 0 },
        //        { 0, 1, 1, 1 },
        //        { 1, 0, 0, 0 },
        //        { 1, 0, 0, 1 },
        //        { 1, 0, 1, 0 },
        //        { 1, 0, 1, 1 },
        //        { 1, 1, 0, 0 },
        //        { 1, 1, 0, 1 },
        //        { 1, 1, 1, 0 },
        //        { 1, 1, 1, 1 }
        //    };

        //    var topology = new Topology(4, 1, 0.1, 2);
        //    var neuralNetwork = new NeuralNetwork(topology);
        //    var difference = neuralNetwork.Learn(outputs, inputs, 10000);

        //    var results = new List<double>();
        //    for(int i = 0; i < outputs.Length; i++)
        //    {
        //        var row = NeuralNetwork.GetRow(inputs, i);
        //        var res = neuralNetwork.Predict(row).Output;
        //        results.Add(res);
        //    }

        //    for(int i = 0; i < results.Count; i++)
        //    {
        //        var expected = Math.Round(outputs[i], 2);
        //        var actual = Math.Round(results[i], 2);
        //        Assert.AreEqual(expected, actual);
        //    }
        //}

        [TestMethod()]
        public void RecognizeImages()
        {
            var size = 10;
            var dogPath = @"C:\Users\Sasha\Desktop\Yes\";
            var nonsheperddog = @"C:\Users\Sasha\Desktop\Non\";

            var converter = new PictureConverter();
            var testDogPathImageInput = converter.Convert(@"C:\Users\Sasha\Desktop\neuralnetworks-master\NeuralNetworksTests\Images\1.png");
            var testCatImageInput = converter.Convert(@"C:\Users\Sasha\Desktop\neuralnetworks-master\NeuralNetworksTests\Images\3.png");

            var topology = new Topology(testDogPathImageInput.Length, 1, 0.1, testDogPathImageInput.Length / 2);
            var neuralNetwork = new NeuralNetwork(topology);

            double[,] DogSheperdInputs = GetData(dogPath, converter, testDogPathImageInput, size);
            neuralNetwork.Learn(new double[] { 1 }, DogSheperdInputs, 1);

            double[,] DogNonSheperdInputs = GetData(nonsheperddog, converter, testCatImageInput, size);
            neuralNetwork.Learn(new double[] { 0 }, DogNonSheperdInputs, 1);

            var dog = neuralNetwork.Predict(testDogPathImageInput.Select(t => (double)t).ToArray());
            var cat = neuralNetwork.Predict(testCatImageInput.Select(t => (double)t).ToArray());

            Assert.AreEqual(1, Math.Round(dog.Output, 2));
            Assert.AreEqual(0, Math.Round(cat.Output, 2));
        }

        private static double[,] GetData(string parasitizedPath, PictureConverter converter, double[] testImageInput, int size)
        {
            var images = Directory.GetFiles(parasitizedPath);
            var result = new double[size, testImageInput.Length];
            for (int i = 0; i < size; i++)
            {
                var image = converter.Convert(images[i]);
                for (int j = 0; j < image.Length; j++)
                {
                    result[i, j] = image[j];
                }
            }

            return result;
        }
    }
}