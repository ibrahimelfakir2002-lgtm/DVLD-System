using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDvldClasses.Enums
{
    public enum enSaveResult
    {
        Success,
        InvalidData,
        HasLicense,
        HasActiveApplication,
        PassedTestsNotIssued,   // ✅ ADD THIS
        DuplicateApplication,
        FailedToCreateApplication,
        FailedToCreateLocalApp
    }
}
