using System.Runtime.Serialization;

namespace OracleExecutor.Objects
{
    [DataContract]
    public class Command
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string Text { get; set; }

        public Command(string Id, string text)
        {
            this.Id = Id;
            this.Text = text;
        }
    }
}