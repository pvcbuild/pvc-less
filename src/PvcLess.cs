using PvcCore;
using System.Collections.Generic;
using System.IO;

namespace PvcPlugins
{
    public class PvcLess : PvcPlugin
    {
        public override string[] SupportedTags
        {
            get
            {
                return new string[] { ".less" };
            }
        }

        public override IEnumerable<PvcStream> Execute(IEnumerable<PvcStream> inputStreams)
        {
            var lessEngine = new dotless.Core.LessEngine();
            var resultStreams = new List<PvcStream>();

            foreach (var inputStream in inputStreams)
            {
                var lessContent = inputStream.ToString();
                var cssContent = lessEngine.TransformToCss(lessContent, "");

                var newStreamName = Path.Combine(Path.GetDirectoryName(inputStream.StreamName), Path.GetFileNameWithoutExtension(inputStream.StreamName) + ".css");
                var resultStream = PvcUtil.StringToStream(cssContent, newStreamName);
                resultStreams.Add(resultStream);
            }

            return resultStreams;
        }
    }
}
