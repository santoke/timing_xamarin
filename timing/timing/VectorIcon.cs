#if __ANDROID__
using SkiaSharp;
using SkiaSharp.Views.Forms;
#endif

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace timing
{
    class VectorIcon : Frame
    {
        public string ResourceId
        {
#if __ANDROID__
                get => (String)GetValue(IconFilePathProperty);
                set => SetValue(IconFilePathProperty, value);
#endif
#if __IOS__
            get; set;
#endif
        }

        // TODO :
#if __ANDROID__

        private readonly SKCanvasView _canvasView = new SKCanvasView();

        public static readonly BindableProperty IconFilePathProperty = BindableProperty.Create(
            nameof(ResourceId), typeof(string), typeof(VectorIcon), default(string), propertyChanged: RedrawCanvas);

        public VectorIcon()
        {
            Padding = new Thickness(0);

            this.InputTransparent = true;

            HasShadow = false;
            BackgroundColor = Color.Transparent;

            Content = _canvasView;
            _canvasView.PaintSurface += CanvasViewOnPaintSurface;
        }

        private static void RedrawCanvas(BindableObject bindable, object oldvalue, object newvalue)
        {
            VectorIcon svgIcon = bindable as VectorIcon;
            svgIcon?._canvasView.InvalidateSurface();
        }

        private void CanvasViewOnPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKCanvas canvas = args.Surface.Canvas;
            canvas.Clear();

            if (string.IsNullOrEmpty(ResourceId))
                return;

            using (Stream stream = GetType().Assembly.GetManifestResourceStream(ResourceId))
            {
                //string[] names = GetType().Assembly.GetManifestResourceNames(); // 리소스 이름 확인용

                SkiaSharp.Extended.Svg.SKSvg svg = new SkiaSharp.Extended.Svg.SKSvg();
                svg.Load(stream);

                SKImageInfo info = args.Info;
                //canvas.Translate(info.Width / 2f, info.Height / 2f);

                SKRect bounds = svg.ViewBox;
                //float xRatio = info.Width / bounds.Width;
                //float yRatio = info.Height / bounds.Height;
                //float ratio = Math.Min(xRatio, yRatio);

                float ratio = (float)this.WidthRequest / (float)bounds.Width;
                canvas.Scale(ratio); // 가이드 비율로
                ratio = (float)App.GuideWidth / (float)App.ScreenWidth;
                canvas.Scale(ratio); // 앱 스크린 비율로

                //canvas.Translate(-bounds.MidX, -bounds.MidY);

                canvas.DrawPicture(svg.Picture);
            }
        }
#endif
    }
}
