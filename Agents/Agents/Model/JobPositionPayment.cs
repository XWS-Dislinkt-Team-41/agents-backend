using System.Collections.Generic;
using Castle.Components.DictionaryAdapter;

namespace Agents.Model
{
    public class JobPositionPayment : Entity
    {
        public string JobPosition { get; set; }
        public long CompanyId { get; set; }
        public double Min { get; set; }
        public double Average { get; set; }
        public double Max { get; set; }

        public int ReviewsNumber { get; set; }

        public List<long> Reviewers { get; set; }

        public JobPositionPayment(){}
        public JobPositionPayment(Payment payment)
        {
            if (payment.JobPositionPayment.Reviewers == null)
            {
                Reviewers = new List<long>();
            }
            else
            {
                Reviewers = payment.JobPositionPayment.Reviewers;
                ReviewsNumber = payment.JobPositionPayment.ReviewsNumber;
            }

            JobPosition = payment.JobPosition;
            CompanyId = payment.CompanyId;
            Reviewers.Add(payment.UserId);
            ReviewsNumber += 1;
            CalculateAveragePrice(payment);
            CalculateMaxPrice(payment);
            CalculateMinPrice(payment);
        }

        public void CalculateMinPrice(Payment payment)
        {
            if ( payment.Price < payment.JobPositionPayment.Min  || payment.JobPositionPayment.Min == null)
            {
                Min = payment.Price;
            }
        }

        public void CalculateMaxPrice(Payment payment)
        {
            if (payment.Price > payment.JobPositionPayment.Max || payment.JobPositionPayment.Max == null)
            {
                Max = payment.Price;
            }
        }

        public void CalculateAveragePrice(Payment payment)
        {
            if (payment.JobPositionPayment.Average == 0)
            {
                Average = payment.Price;
            }
            else
            {
                Average = (payment.JobPositionPayment.Average + payment.Price) / ReviewsNumber;
            }
        }

    }
}
