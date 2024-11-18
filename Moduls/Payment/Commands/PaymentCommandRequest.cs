using MediatR;
using MixVideo.Common.PatternResult;

namespace MixVideo.Moduls.Payment.Commands;

public readonly record struct CreatePaymentRequest(
    PaymentBaseInfo PaymentBaseInfo):IRequest<BaseResult>;
    
public readonly record struct UpdatePaymentRequest(
    int Id,
    PaymentBaseInfo PaymentBaseInfo):IRequest<BaseResult>;    
  
public readonly record struct DeletePaymentRequest(int Id):IRequest<BaseResult>;