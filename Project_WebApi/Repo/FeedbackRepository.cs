using Project_WebApi.Context;
using Project_WebApi.IRepo;
using Project_WebApi.Models;

namespace Project_WebApi.Repo
{
    public class FeedbackRepository : IFeedbackRepository
    {
        AppDbContext _dbContext;
        public FeedbackRepository(AppDbContext context)
        {

            _dbContext = context;

        }
        public Feedback AddFeedback(Feedback feedback)
        {
            feedback.IsActive = true;
            _dbContext.Feedbacks.Add(feedback);
            _dbContext.SaveChanges();
            return feedback;
        }

        public bool DeleteFeedback(int FeedbackId)
        {
            Feedback feedback = GetfeedbackById(FeedbackId);
            if (feedback != null)
            {
                //_dbContext.Remove(batch);
                feedback.IsActive &= false;
                _dbContext.SaveChanges();
                return true;
            }
            else
                return false;

        }

        public Feedback GetfeedbackById(int id)
        {
            var feedback = _dbContext.Feedbacks.FirstOrDefault(x => x.FeedbackId == id);
            return feedback;
        }

        public List<Feedback> GetFeedbacks()
        {
            return _dbContext.Feedbacks.Where(x => x.IsActive == true).ToList();
        }

        public bool UpdateFeedback(int FeedbackId, Feedback feedback)
        {
            Feedback obj = GetfeedbackById(FeedbackId);
            if (obj != null)
            {
                obj.Text = feedback.Text;
                obj.Date = DateTime.Now;
                _dbContext.SaveChanges();
                return true;
            }
            else
                return false;
        }

        Feedback IFeedbackRepository.GetFeedbackById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
