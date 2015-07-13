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
namespace magnusi
{
	public class FlatMini : Control
	{
		private static List<WeakReference> __ENCList = new List<WeakReference>();
		private MouseState State;
		private int x;
		private Color _BaseColor;
		private Color _TextColor;
		[Category("Colors")]
		public Color BaseColor
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
		public Color TextColor
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
			List<WeakReference> _ENCList = FlatMini.__ENCList;
			bool flag = false;
			checked
			{
				try
				{
					Monitor.Enter(_ENCList, ref flag);
					bool flag2 = FlatMini.__ENCList.Count == FlatMini.__ENCList.Capacity;
					if (flag2)
					{
						int num = 0;
						int arg_44_0 = 0;
						int num2 = FlatMini.__ENCList.Count - 1;
						int num3 = arg_44_0;
						while (true)
						{
							int arg_95_0 = num3;
							int num4 = num2;
							if (arg_95_0 > num4)
							{
								break;
							}
							WeakReference weakReference = FlatMini.__ENCList[num3];
							flag2 = weakReference.IsAlive;
							if (flag2)
							{
								bool flag3 = num3 != num;
								if (flag3)
								{
									FlatMini.__ENCList[num] = FlatMini.__ENCList[num3];
								}
								num++;
							}
							num3++;
						}
						FlatMini.__ENCList.RemoveRange(num, FlatMini.__ENCList.Count - num);
						FlatMini.__ENCList.Capacity = FlatMini.__ENCList.Count;
					}
					FlatMini.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
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
				this.FindForm().WindowState = FormWindowState.Minimized;
				break;
			case FormWindowState.Maximized:
				this.FindForm().WindowState = FormWindowState.Minimized;
				break;
			}
		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			Size size = new Size(18, 18);
			this.Size = size;
		}
		public FlatMini()
		{
			FlatMini.__ENCAddToList(this);
			this.State = MouseState.None;
			this._BaseColor = Color.FromArgb(45, 47, 49);
			this._TextColor = Color.FromArgb(243, 243, 243);
			this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.BackColor = Color.White;
			Size size = new Size(18, 18);
			this.Size = size;
			this.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.Font = new Font("Marlett", 12f);
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			Bitmap B = new Bitmap(this.Width, this.Height);
			Graphics G = Graphics.FromImage(B);
			Rectangle Base = new Rectangle(0, 0, this.Width, this.Height);
			Graphics graphics = G;
			graphics.SmoothingMode = SmoothingMode.HighQuality;
			graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics.Clear(this.BackColor);
			graphics.FillRectangle(new SolidBrush(this._BaseColor), Base);
			Graphics arg_A3_0 = graphics;
			string arg_A3_1 = "0";
			Font arg_A3_2 = this.Font;
			Brush arg_A3_3 = new SolidBrush(this.TextColor);
			Rectangle r = new Rectangle(2, 1, this.Width, this.Height);
			arg_A3_0.DrawString(arg_A3_1, arg_A3_2, arg_A3_3, r, Helpers.CenterSF);
			switch (this.State)
			{
			case MouseState.Over:
				graphics.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.White)), Base);
				break;
			case MouseState.Down:
				graphics.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.Black)), Base);
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
