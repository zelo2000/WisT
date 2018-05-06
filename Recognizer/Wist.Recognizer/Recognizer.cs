﻿using Emgu.CV;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using WisT.Recognizer.Contracts;
using static Emgu.CV.Face.FaceRecognizer;

namespace WisT.Recognizer.Identifier
{
    public class Recognizer : IRecognizer
    {
        private double _minDistanse = double.PositiveInfinity;
        private double _transistRateCoefficient = 0.7;

        public Recognizer(IImageStorage imgRepo, ILabelStorage labelRepo)
        {
            _imgRepo = imgRepo;
            _labelRepo = labelRepo;
        }

        public Recognizer(IImageStorage imgRepo, ILabelStorage labelRepo, double transistRateCoefficient)
        {
            _imgRepo = imgRepo;
            _labelRepo = labelRepo;
            _transistRateCoefficient = transistRateCoefficient;
        }

        public IIdentifier GetIdentity(IFaceImage img)
        {
            IIdentifier answ = new Identifier(int.MinValue);
            var distanses = new List<double>();
            var labels = _labelRepo.GetAll();
            foreach (var label in labels)
            {
                IEnumerable<IFaceImage> batch = _imgRepo.Get(label.Id);
                List<Image<Gray, Byte>> compBatch = new List<Image<Gray, Byte>>();
                List<int> trainingLabels = new List<int>();

                int enumerator = 0;
                IIdentifier currentId = new Identifier(0);
                foreach (var current in batch)
                {
                    compBatch.Add(new Image<Gray, Byte>(current.ImageOfFace));
                    trainingLabels.Add(enumerator++);
                    currentId = current.Id;
                }

                FaceRecognizer recognizer = new LBPHFaceRecognizer(4, 10, 10, 10, 200);

                recognizer.Train(compBatch.ToArray(), trainingLabels.ToArray());

                PredictionResult result = recognizer.Predict(new Image<Gray, Byte>(img.ImageOfFace));
                distanses.Add(result.Distance);
                if (result.Distance < _minDistanse)
                {
                    _minDistanse = result.Distance;
                    answ = currentId;
                }
            }

            foreach(var dist in distanses)
            {
                if (_minDistanse > _transistRateCoefficient * dist && dist != _minDistanse)
                {
                    return new Identifier(-1);
                }
            }

            return answ;
        }

        private IImageStorage _imgRepo;
        private ILabelStorage _labelRepo;
    }
}