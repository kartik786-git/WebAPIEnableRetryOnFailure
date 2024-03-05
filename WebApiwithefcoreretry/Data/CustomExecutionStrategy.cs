using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage;

namespace WebApiwithefcoreretry.Data
{
    public class CustomExecutionStrategy : ExecutionStrategy
    {
        public CustomExecutionStrategy(
            ExecutionStrategyDependencies executionStrategy) :
            base(executionStrategy, 
                ExecutionStrategy.DefaultMaxRetryCount,
                ExecutionStrategy.DefaultMaxDelay)
        {
            
        }

        public CustomExecutionStrategy(
            ExecutionStrategyDependencies executionStrategy,
            int maxRetryCount, TimeSpan maxDealy) :
            base(executionStrategy,
                maxRetryCount,
                maxDealy)
        {

        }
        protected override bool ShouldRetryOn(Exception exception)
        {
           return exception.GetType() == typeof(SqlException);
        }
    }
}
