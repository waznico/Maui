﻿using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Platform;

namespace CommunityToolkit.Maui.Extensions;

public static partial class NavigationExtensions
{
	static void PlatformShowPopup(BasePopup popup, IMauiContext mauiContext)
	{
		var window = mauiContext.GetNativeWindow().GetWindow() ?? throw new NullReferenceException("Window is null.");
		popup.Parent = PageExtensions.GetCurrentPage((Page)window.Content);
		var native = popup.ToHandler(mauiContext);
		native?.Invoke(nameof(IPopup.OnOpened));
	}

	static Task<object?> PlatformShowPopupAsync(Popup popup, IMauiContext mauiContext)
	{
		PlatformShowPopup(popup, mauiContext);
		return popup.Result;
	}
}