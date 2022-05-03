namespace Silverstone.Weather.Domain.Model
{
    public class ValidationResult<T>
    {
        public T ResultItem { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }

        public ValidationResult<T> Successful(T resultItem)
        {
            Success = true;
            ResultItem = resultItem;
            return this;

        }

        public ValidationResult<T> Error(string message)
        {
            Success = false;
            ErrorMessage = message;
            return this;
        }
    }
}