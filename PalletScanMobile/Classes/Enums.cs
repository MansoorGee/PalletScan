﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PalletScanMobile
{
    public enum MatchResult
    {
        Matched,
        NotMatched,
        NoResult
    }
    public enum RoleType
    {
        Employee,
        Supervisor,
        Admin
    }
    public enum Option
    {
        LastSyncId

    }

    public enum PalletMatch
    {
        Matched,
        NotMatched,
        MatchedWrongLocation
    }
}
