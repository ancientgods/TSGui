using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using color  = System.Drawing.Color;
using rectangle = System.Drawing.Rectangle;

namespace magnusi
{
	public class FlatMax : Control
	{
		private static List<WeakReference> __ENCList = new List<WeakReference>();
		private MouseState State;
		private int x;
		private color  _BaseColor;
		private color  _TextColor;
		[Category("Colors")]
		public color  BaseColor
		{
			get
			{
				return this._BaseColor;
			}
			set
			{
				this._BaseColor = value;
			}
		}
		[Category("Colors")]
		public color  TextColor
		{
			get
			{
				return this._TextColor;
			}
			set
			{
				this._TextColor = value;
			}
		}
		[DebuggerNonUserCode]
		private static void __ENCAddToList(object value)
		{
			List<WeakReference> _ENCList = FlatMax.__ENCList;
			bool flag = false;
			checked
			{
				try
				{
					Monitor.Enter(_ENCList, ref flag);
					bool flag2 = FlatMax.__ENCList.Count == FlatMax.__ENCList.Capacity;
					if (flag2)
					{
						int num = 0;
						int arg_44_0 = 0;
						int num2 = FlatMax.__ENCList.Count - 1;
						int num3 = arg_44_0;
						while (true)
						{
							int arg_95_0 = num3;
							int num4 = num2;
							if (arg_95_0 > num4)
							{
								break;
							}
							WeakReference weakReference = FlatMax.__ENCList[num3];
							flag2 = weakReference.IsAlive;
							if (flag2)
							{
								bool flag3 = num3 != num;
								if (flag3)
								{
									FlatMax.__ENCList[num] = FlatMax.__ENCList[num3];
								}
								num++;
							}
							num3++;
						}
						FlatMax.__ENCList.RemoveRange(num, FlatMax.__ENCList.Count - num);
						FlatMax.__ENCList.Capacity = FlatMax.__ENCList.Count;
					}
					FlatMax.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
				}
				finally
				{
					bool flag3 = flag;
					if (flag3)
					{
						Monitor.Exit(_ENCList);
					}
				}
			}
		}
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			this.State = MouseState.Over;
			this.Invalidate();
		}
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			this.State = MouseState.Down;
			this.Invalidate();
		}
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.State = MouseState.None;
			this.Invalidate();
		}
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.State = MouseState.Over;
			this.Invalidate();
		}
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			this.x = e.X;
			this.Invalidate();
		}
		protected override void OnClick(EventArgs e)
		{
			base.OnClick(e);
			switch (this.FindForm().WindowState)
			{
			case FormWindowState.Normal:
				this.FindForm().WindowState = FormWindowState.Maximized;
				break;
			case FormWindowState.Maximized:
				this.FindForm().WindowState = FormWindowState.Normal;
				break;
			}
		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			Size size = new Size(18, 18);
			this.Size = size;
		}
		public FlatMax()
		{
			FlatMax.__ENCAddToList(this);
			this.State = MouseState.None;
			this._BaseColor = color .FromArgb(45, 47, 49);
			this._TextColor = color .FromArgb(243, 243, 243);
			this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.BackColor = color .White;
			Size size = new Size(18, 18);
			this.Size = size;
			this.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.Font = new Font("Marlett", 12f);
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			Bitmap B = new Bitmap(this.Width, this.Height);
			Graphics G = Graphics.FromImage(B);
			rectangle Base = new rectangle (0, 0, this.Width, this.Height);
			Graphics graphics = G;
			graphics.SmoothingMode = SmoothingMode.HighQuality;
			graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics.Clear(this.BackColor);
			graphics.FillRectangle(new SolidBrush(this._BaseColor), Base);
			bool flag = this.FindForm().WindowState == FormWindowState.Maximized;
			if (flag)
			{
				Graphics arg_B7_0 = graphics;
				string arg_B7_1 = "2";
				Font arg_B7_2 = this.Font;
				Brush arg_B7_3 = new SolidBrush(this.TextColor);
				rectangle r = new rectangle (1, 1, this.Width, this.Height);
				arg_B7_0.DrawString(arg_B7_1, arg_B7_2, arg_B7_3, r, Helpers.CenterSF);
			}
			else
			{
				flag = (this.FindForm().WindowState == FormWindowState.Normal);
				if (flag)
				{
					Graphics arg_10C_0 = graphics;
					string arg_10C_1 = "1";
					Font arg_10C_2 = this.Font;
					Brush arg_10C_3 = new SolidBrush(this.TextColor);
					rectangle r = new rectangle (1, 1, this.Width, this.Height);
					arg_10C_0.DrawString(arg_10C_1, arg_10C_2, arg_10C_3, r, Helpers.CenterSF);
				}
			}
			switch (this.State)
			{
			case MouseState.Over:
				graphics.FillRectangle(new SolidBrush(color.FromArgb(30, color .White)), Base);
				break;
			case MouseState.Down:
				graphics.FillRectangle(new SolidBrush(color.FromArgb(30, color .Black)), Base);
				break;
			}
			base.OnPaint(e);
			G.Dispose();
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.DrawImageUnscaled(B, 0, 0);
			B.Dispose();
		}
	}
}
