using System.Net;

using Tost.ObjectResults.Interfaces;

namespace Tost.ObjectResults.Types.Success;

public sealed record StatusCodeResult(HttpStatusCode StatusCode) : IPredefinedReason, ISuccess;
