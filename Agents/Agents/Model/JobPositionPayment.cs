using System.Collections.Generic;

namespace Agents.Model
{
    public class JobPositionPayment : Entity
    {
        public string JobPosition { get; set; }
        public int CompanyId { get; set; }
        public double Min { get; set; }
        public double Average { get; set; }
        public double Max { get; set; }

        public int ReviewsNumber { get; set; }

        public List<int> Reviewers { get; protected set; }

        public JobPositionPayment(){}
        public JobPositionPayment(Payment payment)
        {
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
            if (payment.JobPositionPayment.Average == null)
            {
                Average = payment.Price;
            }
            else
            {
                Average = (Average + payment.Price) / ReviewsNumber;
            }
        }

    }
}
