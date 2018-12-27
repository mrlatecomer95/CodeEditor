using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Rendering;
//using ICSharpCode.AvalonEdit.Rendering;

using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace AvalonEdit.AddIn
{
    public class BracketHighlightRenderer : IBackgroundRenderer
    {
        BracketSearchResult result;
        Pen borderPen;
        Brush backgroundBrush;
        TextView textView;

        public static readonly Color DefaultBackground = Color.FromArgb(22, 0, 0, 255);
        public static readonly Color DefaultBorder = Color.FromArgb(52, 0, 0, 255);

        public void SetHighlight(BracketSearchResult result)
        {
            if (this.result != result)
            {
                this.result = result;
                textView.InvalidateLayer(this.Layer);
            }
        }

        public BracketHighlightRenderer(TextView textView)
        {
            if (textView == null)
                throw new ArgumentNullException("textView");

            this.textView = textView;

            this.textView.BackgroundRenderers.Add(this);
        }

        void UpdateColors(Color background, Color foreground)
        {
            this.borderPen = new Pen(new SolidColorBrush(foreground), 1);
            this.borderPen.Freeze();

            this.backgroundBrush = new SolidColorBrush(background);
            this.backgroundBrush.Freeze();
        }

        public KnownLayer Layer
        {
            get
            {
                return KnownLayer.Selection;
            }
        }

        public void Draw(TextView textView, DrawingContext drawingContext)
        {
            if (this.result == null)
                return;

            BackgroundGeometryBuilder builder = new BackgroundGeometryBuilder();

            builder.CornerRadius = 1;
            //builder.AlignToMiddleOfPixels = true;
            builder.AlignToWholePixels = true;
            builder.BorderThickness = 100;

            builder.AddSegment(textView, new TextSegment() { StartOffset = result.OpeningBracketOffset, Length = result.OpeningBracketLength });
            builder.CloseFigure(); // prevent connecting the two segments
            builder.AddSegment(textView, new TextSegment() { StartOffset = result.ClosingBracketOffset, Length = result.ClosingBracketLength });

            Geometry geometry = builder.CreateGeometry();
            if (geometry != null)
            {
                drawingContext.DrawGeometry(backgroundBrush, borderPen, geometry);
            }
        }

        public static void ApplyCustomizationsToRendering(BracketHighlightRenderer renderer)
        {
            renderer.UpdateColors(DefaultBackground, DefaultBorder);
        }
    }
}
