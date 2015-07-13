using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace magnusi
{
	[StandardModule]
	public sealed class Helpers
	{
		internal static Graphics G;
		internal static Bitmap B;
		internal static Color _FlatColor = Color.FromArgb(35, 168, 109);
		internal static StringFormat NearSF = new StringFormat
		{
			Alignment = StringAlignment.Near,
			LineAlignment = StringAlignment.Near
		};
		internal static StringFormat CenterSF = new StringFormat
		{
			Alignment = StringAlignment.Center,
			LineAlignment = StringAlignment.Center
		};
		public static GraphicsPath RoundRec(Rectangle Rectangle, int Curve)
		{
			GraphicsPath P = new GraphicsPath();
			checked
			{
				int ArcRectangleWidth = Curve * 2;
				GraphicsPath arg_2F_0 = P;
				Rectangle rect = new Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth);
				arg_2F_0.AddArc(rect, -180f, 90f);
				GraphicsPath arg_63_0 = P;
				rect = new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth);
				arg_63_0.AddArc(rect, -90f, 90f);
				GraphicsPath arg_A1_0 = P;
				rect = new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth);
				arg_A1_0.AddArc(rect, 0f, 90f);
				GraphicsPath arg_D5_0 = P;
				rect = new Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth);
				arg_D5_0.AddArc(rect, 90f, 90f);
				GraphicsPath arg_118_0 = P;
				Point point = new Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y);
				Point arg_118_1 = point;
				Point pt = new Point(Rectangle.X, Curve + Rectangle.Y);
				arg_118_0.AddLine(arg_118_1, pt);
				return P;
			}
		}
		public static GraphicsPath RoundRect(float x, float y, float w, float h, float r = 0.3f, bool TL = true, bool TR = true, bool BR = true, bool BL = true)
		{
			float d = Math.Min(w, h) * r;
			float xw = x + w;
			float yh = y + h;
			GraphicsPath RoundRect = new GraphicsPath();
			GraphicsPath graphicsPath = RoundRect;
			if (TL)
			{
				graphicsPath.AddArc(x, y, d, d, 180f, 90f);
			}
			else
			{
				graphicsPath.AddLine(x, y, x, y);
			}
			if (TR)
			{
				graphicsPath.AddArc(xw - d, y, d, d, 270f, 90f);
			}
			else
			{
				graphicsPath.AddLine(xw, y, xw, y);
			}
			if (BR)
			{
				graphicsPath.AddArc(xw - d, yh - d, d, d, 0f, 90f);
			}
			else
			{
				graphicsPath.AddLine(xw, yh, xw, yh);
			}
			if (BL)
			{
				graphicsPath.AddArc(x, yh - d, d, d, 90f, 90f);
			}
			else
			{
				graphicsPath.AddLine(x, yh, x, yh);
			}
			graphicsPath.CloseFigure();
			return RoundRect;
		}
		public static GraphicsPath DrawArrow(int x, int y, bool flip)
		{
			GraphicsPath GP = new GraphicsPath();
			int W = 12;
			int H = 6;
			checked
			{
				if (flip)
				{
					GP.AddLine(x + 1, y, x + W + 1, y);
					GP.AddLine(x + W, y, x + H, y + H - 1);
				}
				else
				{
					GP.AddLine(x, y + H, x + W, y + H);
					GP.AddLine(x + W, y + H, x + H, y);
				}
				GP.CloseFigure();
				return GP;
			}
		}
	}
}
