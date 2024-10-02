namespace Nackademin_Episerver.Models.Pages
{
	[ContentType(
		GUID = "F752FE1E-8A8E-47E8-A41C-E8DE7531C2F7"
		)]
	[AvailableContentTypes(
		Availability.Specific,
		Include = 
		[typeof(SlideshowPage),
        typeof(SavedMoviePage)]
	)]
	public class ContainerPage : PageData, IContainerPage
	{
	}
}
