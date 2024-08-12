using MongoDB.Driver;
using System.Threading.Tasks;
using PaymentService.Models;
using PaymentService.Data;
using MongoDB.Bson;

namespace PaymentService.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly MongoDBContext _context;

        public PaymentRepository(MongoDBContext context)
        {
            _context = context;
        }

        public async Task<Payment> GetPaymentByIdAsync(string id)
        {
            var objectId = new ObjectId(id);
            return await _context.Payments.Find(p => p.Id == objectId).FirstOrDefaultAsync();
        }

        public async Task CreatePaymentAsync(Payment payment)
        {
            await _context.Payments.InsertOneAsync(payment);
        }
    }
}
