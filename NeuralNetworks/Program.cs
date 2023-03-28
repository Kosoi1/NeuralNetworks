using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworks
{
    internal class Program
    {
        public static void RecognizeImages()
        {
            var size = 100;
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

            Console.WriteLine(dog.Output);
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
        static void Main()
        {
            RecognizeImages();
        }
    }
}
