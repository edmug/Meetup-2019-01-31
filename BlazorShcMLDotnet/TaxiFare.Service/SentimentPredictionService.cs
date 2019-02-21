using Microsoft.ML;
using Microsoft.ML.Core.Data;
//using Microsoft.ML.Runtime.Data;
using System.IO;
using TaxiFare.Shared;

namespace TaxiFare.Service
{
    public class SentimentPredictionService : ISentimentPredictionService
    {
        protected readonly ITransformer loadedModel;
        protected readonly MLContext mlContext;
        public SentimentPredictionService(string modelPath)
        {
            mlContext = new MLContext(seed: 0);

            using (var stream = new FileStream(modelPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                loadedModel = mlContext.Model.Load(stream);
        }

        public SentimentPrediction GetSentiment(SentimentIssue sentimentIssue)
        {
            // Create prediction engine related to the loaded trained model
            var predEngine = loadedModel.CreatePredictionEngine<SentimentIssue, SentimentPrediction>(mlContext);

            //Score
            var resultprediction = predEngine.Predict(sentimentIssue);

            return resultprediction;
        }
    }

}