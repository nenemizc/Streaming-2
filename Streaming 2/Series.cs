using System;
using System.Collections.Generic;
using System.Text;

namespace Streaming_2
{
    public class Series : IContent
    {
        private string title;
        private List<Video> videos;

        public Series(string title, Video firstVideo)
        {
            this.title = title;
            this.videos = new List<Video> { firstVideo };
        }

        public Series(string title, List<Video> videos)
        {
            this.title = title;
            this.videos = videos;
        }

        public string GetTitle()
        {
            return title;
        }

        public int GetLength()
        {
            return videos.Sum(v => v.Length);
        }
    }
}
