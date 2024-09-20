using EPiServer.Framework.DataAnnotations;

namespace Nackademin_Episerver.Models
{
    [ContentType(
       GUID = "738D86FC-9008-434A-A630-9E0406BDBC76"
    )]
    [MediaDescriptor(ExtensionString = "jpg,jpeg,jpe,ico,gif,bmp,png,webp,pdf")]
    public class ImageFile : ImageData
    {
    }
}
