namespace Service.DTO
{
    public class ResponseDTO<T>
    {
        public bool Status { get; set; }
        public T Data { get; set; }
    }
}
