using Grpc.Core;
using Grpc.Core.Interceptors;

namespace PdfGenerationService.Interceptors;

public class ExceptionInterceptor: Interceptor
{
    public override AsyncUnaryCall<TResponse> AsyncUnaryCall<TRequest, TResponse>(TRequest request, ClientInterceptorContext<TRequest, TResponse> context,
        AsyncUnaryCallContinuation<TRequest, TResponse> continuation)
    {
        try
        {
            return continuation(request, context);
        } catch(Exception e)
        {
            Status status = new Status(StatusCode.InvalidArgument, $"Unknown unit {e.Message}!");
            throw new RpcException(status, e.Message); 
        }
    }
}