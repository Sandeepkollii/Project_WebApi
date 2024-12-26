using Project_WebApi.Context;
using Project_WebApi.IRepo;
using Project_WebApi.Models;

namespace Project_WebApi.Repo
{
    public class BatchRepository : IBatchRepository
    {
        AppDbContext _dbContext;
        public BatchRepository(AppDbContext context)
        {

            _dbContext = context;

        }
        public Batch AddBatch(Batch batch)
        {
            batch.IsActive = true;
            _dbContext.Batches.Add(batch);
            _dbContext.SaveChanges();
            return batch;
        }

        public bool DeleteBatch(int batchId)
        {
            Batch batch = GetBatchById(batchId);
            if (batch != null)
            {
                //_dbContext.Remove(batch);
                batch.IsActive &= false;
                _dbContext.SaveChanges();
                return true;
            }
            else
                return false;

        }

        public Batch GetBatchById(int id)
        {
            var batch = _dbContext.Batches.FirstOrDefault(x => x.BatchId == id);
            return batch;
        }

        public List<Batch> GetBatches()
        {
            return _dbContext.Batches.Where(x=>x.IsActive==true).ToList();
        }

        public bool UpdateBatch(int batchId, Batch batch)
        {
            Batch obj = GetBatchById(batchId);
            if (obj != null)
            {
                obj.StartDate = DateTime.Now;
                obj.EndDate = DateTime.Now;
                obj.BatchCount = batch.BatchCount;
                _dbContext.SaveChanges();
                return true;
            }
            else
                return false;
        }
    }
}
