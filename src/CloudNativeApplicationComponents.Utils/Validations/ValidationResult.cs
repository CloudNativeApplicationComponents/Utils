using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CloudNativeApplicationComponents.Utils
{
    public class ValidationResult
    {
        public bool Valid { get => !ValidationErrors.Any(t => t.Level == ValidationLevel.Error); }
        public bool HasWarning { get => ValidationErrors.Any(t => t.Level == ValidationLevel.Warn); }

        public ValidationResult(IEnumerable<InvalidCause> invalidCauses)
        {
            var list = invalidCauses?.ToList() ?? new List<InvalidCause>();
            ValidationErrors = new ReadOnlyCollection<InvalidCause>(list);
        }

        public IReadOnlyCollection<InvalidCause> ValidationErrors { get; }
    }
}
