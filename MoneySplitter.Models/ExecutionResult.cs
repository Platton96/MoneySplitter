namespace MoneySplitter.Models
{
    public class ExecutionResult<T>
    {
        public T Result { get; set; }
        public bool IsSuccess { get; set; }
    }
}
