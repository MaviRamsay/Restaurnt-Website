namespace Restaurant_Website.Domain.Core
{
    public class UploadedFile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AbsoluteName { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
    }
}
