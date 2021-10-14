using System;

namespace Pica.Api.Models
{
    public class DigitalAsset
    {
        public Guid DigitalAssetId { get; set; }
        public string Name { get; set; }
        public byte[] Bytes { get; set; }
        public string ContentType { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
    }
}
