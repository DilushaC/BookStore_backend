using System.Threading.Tasks;
using PaymentService.Models;

namespace PaymentService.Repositories
{
    public interface IPaymentRepository
    {
        Task<Payment> GetPaymentByIdAsync(string id);
        Task CreatePaymentAsync(Payment payment);
    }
}
