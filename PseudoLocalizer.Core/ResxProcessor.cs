namespace PseudoLocalizer.Core
{
    using System;
    using System.IO;
    using System.Xml;

    /// <summary>
    /// Applies transforms to string values in Resx resource files.
    /// </summary>
    public class ResxProcessor
    {
        /// <summary>
        /// Event raised when a string value to be transformed is found.
        /// </summary>
        public event EventHandler<TransformStringEventArgs> TransformString;

        /// <summary>
        /// Transform: read from an input stream and write to an output stream.
        /// </summary>
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
