using EPiServer.Shell.ObjectEditing;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;

namespace Nackademin_Episerver.Business.CustomProperties
{
    [EditorDescriptorRegistration(
       TargetType = typeof(string),
       UIHint = "MetaRobots"
   )]
    public class MetaIndexDescriptor : EditorDescriptor
    {
        public override void ModifyMetadata(ExtendedMetadata metadata, IEnumerable<Attribute> attributes)
        {
            SelectionFactoryType = typeof(MetaRobotsFactory);
            ClientEditingClass = "epi-cms/contentediting/editors/SelectionEditor";

            base.ModifyMetadata(metadata, attributes);
        }
    }
}
