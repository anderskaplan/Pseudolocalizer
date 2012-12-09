namespace PseudoLocalizer.Core
{
    using System;
    using System.IO;
    using System.Xml;

    public class ResxProcessor
    {
        public event EventHandler<TransformStringEventArgs> TransformString;

        public void Transform(Stream inputStream, Stream outputStream)
        {
            var document = new XmlDocument();
            document.PreserveWhitespace = true;
            document.Load(inputStream);

            foreach (XmlNode node in document.SelectNodes("/root/data/value"))
            {
                var child = node.FirstChild;
                if (child != null && child.NodeType == XmlNodeType.Text)
                {
                    var original = child.Value;
                    var args = new TransformStringEventArgs { Value = original };
                    OnTransformString(args);

                    if (args.Value != original)
                    {
                        child.Value = args.Value;
                    }
                }
            }

            using (var xmlWriter = XmlWriter.Create(outputStream))
            {
                document.WriteTo(xmlWriter);
            }
        }

        private void OnTransformString(TransformStringEventArgs args)
        {
            var handler = TransformString;
            if (handler != null)
            {
                handler(this, args);
            }
        }
    }
}
