namespace WpfAppLogin.Models
{
    public class ResponseBase<T> where T: class
    {
        public int Status { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
    }
}
