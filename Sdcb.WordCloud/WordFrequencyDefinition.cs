namespace Sdcb.WordCloud
{
    public class WordFrequencyDefinition
    {
        public WordFrequencyDefinition(string word, int frequency)
        {
            this.Word = word;
            this.Frequency = frequency;
        }

        public string Word { get; set; }

        public int Frequency { get; set; }
    }
}
