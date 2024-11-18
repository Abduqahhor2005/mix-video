using MixVideo.Common.BaseRepository.BaseCommandGenericRepository;
using MixVideo.Common.Data;

namespace MixVideo.Moduls.Payment.Repository.CommandRepository;

public class PaymentCommandRepository(AppCommandDbContext context)
    :CommandGenericRepository<Payment>(context),IPaymentCommandRepository;