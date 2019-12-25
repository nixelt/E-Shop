namespace E_Shop.Web.Core.Extensions
{
    using System.IO;
    using System.Web;

    public static class HttpPostedFileBaseExtension
    {
        public static byte[] ToByteArray(this HttpPostedFileBase file)
        {
            var rdr = new BinaryReader(file.InputStream);
            var res = rdr.ReadBytes(file.ContentLength);
            return res;
        }
    }
}
