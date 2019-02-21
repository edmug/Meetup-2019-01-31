using TaxiFare.Shared;

namespace TaxiFare.Service
{
    public interface ISentimentPredictionService
    {
        SentimentPrediction GetSentiment(SentimentIssue sentimentIssue);
    }
}