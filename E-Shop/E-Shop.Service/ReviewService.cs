namespace E_Shop.Service
{
    using System.Collections.Generic;
    using System.Linq;

    using Data.Infrastructure;
    using Data.Repositories;
    using Model;

    public interface IReviewService
    {
        Review GetReview(int id);

        List<Review> GetReviews(int productId);

        void CreateReview(Review review);

        void DeleteReview(Review review);
    }

    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        private readonly IUnitOfWork _unitOfWork;

        public ReviewService(IReviewRepository reviewRepository, IUnitOfWork unitOfWork)
        {
            _reviewRepository = reviewRepository;
            _unitOfWork = unitOfWork;
        }

        public Review GetReview(int id)
        {
            var review = _reviewRepository.GetById(id);
            return review;
        }

        public List<Review> GetReviews(int productId)
        {
            var reviews = _reviewRepository.GetMany(x => x.ProductId == productId).ToList();
            return reviews;
        }

        public void CreateReview(Review review)
        {
            _reviewRepository.Add(review);
            _unitOfWork.Commit();
        }

        public void DeleteReview(Review review)
        {
            _reviewRepository.Delete(review);
            SaveReview();
        }

        private void SaveReview()
        {
            _unitOfWork.Commit();
        }
    }
}
