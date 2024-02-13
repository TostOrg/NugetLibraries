using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tost.ObjectResults.Interfaces;

namespace Tost.ObjectResults.Types.Success;

internal sealed record StatusCodeResult(System.Net.HttpStatusCode StatusCode) : IPredefinedReason, ISuccess;
