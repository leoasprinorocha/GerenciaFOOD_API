using Hangfire.Common;
using Hangfire.States;
using Hangfire.Storage;
using System;

namespace GerenciaFOOD_API
{
    public class AutoDeleteAfterSuccessAttribute : JobFilterAttribute, IApplyStateFilter
    {
        private readonly TimeSpan _deleteAfter;

        public AutoDeleteAfterSuccessAttribute(int hours, int minutes, int seconds)
        {
            _deleteAfter = new TimeSpan(hours, minutes, seconds);
        }

        public void OnStateApplied(ApplyStateContext context, IWriteOnlyTransaction transaction)
        {
            context.JobExpirationTimeout = _deleteAfter;
        }

        public void OnStateUnapplied(ApplyStateContext context, IWriteOnlyTransaction transaction)
        {
        }
    }
}
