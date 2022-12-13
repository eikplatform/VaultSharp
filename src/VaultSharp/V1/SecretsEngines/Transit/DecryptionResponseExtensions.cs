using System;
using System.Linq;
using VaultSharp.Core;

namespace VaultSharp.V1.SecretsEngines.Transit
{
    public static class DecryptionResponseExtensions
    {
        public static void ThrowIfBatchErrors(this DecryptionResponse decryptionResponse)
        {
            var errors = decryptionResponse.BatchedResults
                .Select((result, i) => new { result?.Error, Index = i })
                .Where(item => item.Error != null).ToArray();

            if (errors.Any())
            {
                var errorMessage =
                    string.Join(Environment.NewLine, errors.Select(e => $"[{e.Index}]: {e.Error}"));
                throw new VaultApiException(errorMessage);
            }
        }
    }
}