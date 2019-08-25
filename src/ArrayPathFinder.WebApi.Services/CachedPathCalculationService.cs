using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using ArrayPathFinder.WebApi.Contracts.Response;

namespace ArrayPathFinder.WebApi.Services
{
    public class CachedPathCalculationService : IPathCalculationService
    {
        private readonly Dictionary<string, ArrayPathCalculationResult> _cachedCalculations;
        private readonly IPathCalculationService _service;

        public CachedPathCalculationService(IPathCalculationService service)
        {
            _service = service;
            _cachedCalculations = new Dictionary<string, ArrayPathCalculationResult>();
        }

        public ArrayPathCalculationResult CalculatePath(List<int> items)
        {
            string itemsHash = GetHash(items);

            if (!_cachedCalculations.TryGetValue(itemsHash, out ArrayPathCalculationResult result))
            {
                result = _service.CalculatePath(items);
                _cachedCalculations.Add(itemsHash, result);
            }

            return result;
        }

        private string GetHash(List<int> items)
        {
            string itemsString = string.Join(string.Empty, items);
            using (MD5 md5 = MD5.Create())
            {
                byte[] bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(itemsString));

                StringBuilder stringBuilder = new StringBuilder();
                foreach (byte @byte in bytes)
                {
                    stringBuilder.Append(@byte.ToString("x2"));
                }

                return stringBuilder.ToString();
            }
        }
    }
}