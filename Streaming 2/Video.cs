using System;
using System.Collections.Generic;
using System.Text;

namespace Streaming_2
{
    public class Video
    {
        private string title;
        private int length;

        public Video(string title, int length)
        {
            this.title = title;
            this.length = length;
        }

        public string Title { get => title; set => title = value; }
        public int Length { get => length; set => length = value; }
    }
}
