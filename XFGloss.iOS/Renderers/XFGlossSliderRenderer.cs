﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Slider), typeof(XFGloss.iOS.Renderers.XFGlossSliderRenderer))]
namespace XFGloss.iOS.Renderers
{
	public class XFGlossSliderRenderer : SliderRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Slider> e)
		{
			base.OnElementChanged(e);

			UpdateSliderProperties();
		}

		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == SliderGloss.MaxTrackTintColorProperty.PropertyName ||
				e.PropertyName == SliderGloss.MinTrackTintColorProperty.PropertyName ||
				e.PropertyName == SliderGloss.ThumbTintColorProperty.PropertyName)
			{
				UpdateSliderProperties(e.PropertyName);
			}
		}

		void UpdateSliderProperties(string propertyName = null)
		{
			if (Element == null || Control == null)
			{
				return;
			}

			// MaxTrackTintColor Property
			if (propertyName == null || propertyName == SliderGloss.MaxTrackTintColorProperty.PropertyName)
			{
				var maxTrackTintColor = (Color)Element.GetValue(SliderGloss.MaxTrackTintColorProperty);

				Control.MaximumTrackTintColor = (maxTrackTintColor == Color.Default) ? null : maxTrackTintColor.ToUIColor();
			}

			// MinTrackTintColor Property
			if (propertyName == null || propertyName == SliderGloss.MinTrackTintColorProperty.PropertyName)
			{
				var minTrackTintColor = (Color)Element.GetValue(SliderGloss.MinTrackTintColorProperty);

				Control.MinimumTrackTintColor = (minTrackTintColor == Color.Default) ? null : minTrackTintColor.ToUIColor();
			}

			// ThumbTintColor Property
			if (propertyName == null || propertyName == SliderGloss.ThumbTintColorProperty.PropertyName)
			{
				var thumbTintColor = (Color)Element.GetValue(SliderGloss.ThumbTintColorProperty);

				Control.ThumbTintColor = (thumbTintColor == Color.Default) ? null : thumbTintColor.ToUIColor();
			}
		}
	}
}