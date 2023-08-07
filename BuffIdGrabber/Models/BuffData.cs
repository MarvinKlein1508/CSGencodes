namespace BuffIdGrabber.Models
{
    public class BuffData
    {
        public BuffItem[] items { get; set; }
        public int page_num { get; set; }
        public int page_size { get; set; }
        public int total_count { get; set; }
        public int total_page { get; set; }
    }

}