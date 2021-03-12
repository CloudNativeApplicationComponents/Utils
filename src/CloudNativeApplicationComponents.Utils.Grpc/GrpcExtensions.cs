using Grpc.Core;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CloudNativeApplicationComponents.Utils.Grpc
{
    public static class GrpcExtensions
    {
        public async static IAsyncEnumerable<T> ReadAllAsync<T>(this IAsyncStreamReader<T> streamReader, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            if (streamReader == null)
            {
                throw new System.ArgumentNullException(nameof(streamReader));
            }

            while (await streamReader.MoveNext(cancellationToken))
            {
                yield return streamReader.Current;
            }
        }
    }
}
