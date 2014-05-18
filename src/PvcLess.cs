using PvcCore;
using System.Collections.Generic;
using System.IO;

namespace PvcPlugins
{
    public class PvcLess : PvcPlugin
    {
        public override IEnumerable<PvcStream> Execute(IEnumerable<PvcStream> inputStreams)
        {
            var lessEngine = new dotless.Core.LessEngine();
            var resultStreams = new List<PvcStream>();

            foreach (var inputStream in inputStreams)
            {
                var lessContent = inputStream.ToString();
                var cssContent = lessEngine.TransformToCss(lessContent, "");

                var resultStream = PvcUtil.StringToStream(cssContent, inputStream.StreamName);
                resultStreams.Add(resultStream);
            }

            return resultStreams;
        }
    }
}
