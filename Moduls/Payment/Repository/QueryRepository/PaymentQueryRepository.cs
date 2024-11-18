using MixVideo.Common.BaseRepository.BaseQueryGenericRepository;
using MixVideo.Common.Data;

namespace MixVideo.Moduls.Payment.Repository.QueryRepository;

public class PaymentQueryRepository(AppQueryDbContext context)
    :QueryGenericRepository<Payment>(context),IPaymentQueryRepository;