using System;
using System.Collections.Generic;
using System.Text;

namespace SuperReaperLib
{
    public interface VersionCheckerCallback
    {
        void OnVersionChecked(bool isUpdated);
    }
}
