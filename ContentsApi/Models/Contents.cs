namespace ContentsApi.Models
{
    public class Contents
    {
        public int code { get; set; }
        public string status { get; set; }
        public bool isSuccessStatusCode { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public object[] folders { get; set; }
        public Content[] contents { get; set; }
        public int returnedContents { get; set; }
        public int returnedFolders { get; set; }
        public Contentcount contentCount { get; set; }
    }

    public class Contentcount
    {
        public int totalContents { get; set; }
        public int onDemandVideoCount { get; set; }
        public int onDemandAudioCount { get; set; }
        public int liveEventVideoCount { get; set; }
        public int liveEventAudioCount { get; set; }
        public int playlistCount { get; set; }
        public int originCount { get; set; }
        public int folderCount { get; set; }
    }

    public class Content
    {
        public bool liveStatusOnAir { get; set; }
        public bool liveStatusRecording { get; set; }
        public string onDemandFileName { get; set; }
        public string onDemandEncodingDescription { get; set; }
        public string onDemandDuration { get; set; }
        public string gidEncodingProfileOnDemand { get; set; }
        public bool liveMultibitrate { get; set; }
        public string title { get; set; }
        public bool trash { get; set; }
        public bool hasPoster { get; set; }
        public int onDemandEncodingStatus { get; set; }
        public string gidProperty { get; set; }
        public string contentId { get; set; }
        public int contentType { get; set; }
        public int deliveryStatus { get; set; }
        public bool protectedEmbed { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime updateDate { get; set; }
        public DateTime publishDateUTC { get; set; }
        public int publishStatus { get; set; }
    }
}