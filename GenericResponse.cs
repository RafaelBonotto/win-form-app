namespace WinFormsAppLogin
{
    public class GenericResponse<T> 
    {
        public bool Success { get; set; }
        public T? Response { get; set; }
        public Guid CorrelationId { get; set; }
    }
}
