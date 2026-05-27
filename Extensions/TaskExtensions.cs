namespace myNUnit.Extensions
{
    public static class TaskExtensions
    {
        public static async Task<TResult> Then<TSource, TResult>(
            this Task<TSource> currentTask, 
            Func<TSource, Task<TResult>> nextAction)
        {
            var result = await currentTask;

            return await nextAction(result);
        }

        public static async Task<TSource> Then<TSource>(
            this Task<TSource> currentTask, 
            Func<TSource, Task> nextAction)
        {
            var result = await currentTask;
            await nextAction(result);
            return result;
        }
    }
}
