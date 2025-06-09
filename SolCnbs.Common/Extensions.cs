

namespace SolCnbs.Common
{
    public static class Extensions
    {
        public static string FullMessage(this Exception ex)
        {
            if (ex is AggregateException aex) return aex.InnerExceptions.Aggregate("[ ", (total, next) => $"{total}[{next.FullMessage()}] ") + "]";
            var msg = ex.Message.Replace(", see inner exception.", "").Trim();
            var innerMsg = ex.InnerException?.FullMessage();
            if (innerMsg is object && innerMsg != msg) msg = $"{msg} [ {innerMsg} ]";
            return msg;
        }
    }
}
