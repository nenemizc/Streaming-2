using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Streaming_2
{
    public class StreamingPlatform
    {
        public List<IContent> Contents { get; private set; } = new List<IContent>();

        public void AddContent(IContent content) => Contents.Add(content);

        public IContent GetLongestContent()
        {
            if (Contents.Count == 0) return null;
            IContent longest = Contents[0];
            foreach (var c in Contents)
            {
                if (c.GetLength() > longest.GetLength()) longest = c;
            }
            return longest;
        }

        public void LoadFromFile(string filePath)
        {
            string fileContent = File.ReadAllText(filePath);
            string[] lines = fileContent.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                string[] parts = line.Split(';');
                string type = parts[0].ToUpper().Trim();

                if (type == "MOVIE" && parts.Length >= 3)
                {
                    string title = parts[1].Trim();
                    int length = int.Parse(parts[2].Trim());
                    AddContent(new Movie(new Video(title, length)));
                }
                else if (type == "SERIES" && parts.Length >= 3)
                {
                    string seriesTitle = parts[1].Trim();
                    List<Video> episodes = new List<Video>();

                    for (int i = 2; i < parts.Length; i++)
                    {
                        string[] epParts = parts[i].Split(',');
                        if (epParts.Length == 2)
                        {
                            episodes.Add(new Video(epParts[0].Trim(), int.Parse(epParts[1].Trim())));
                        }
                    }

                    if (episodes.Count > 0)
                    {
                        AddContent(new Series(seriesTitle, episodes));
                    }
                }
            }
        }
    }
}
