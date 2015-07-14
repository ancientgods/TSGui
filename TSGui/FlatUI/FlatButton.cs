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
	public class FlatButton : Control
	{
		private static List<WeakReference> __ENCList = new List<WeakReference>();
		private int W;
		private int H;
		private bool _Rounded;
		private MouseState State;
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
		[Category("Options")]
		public bool Rounded
		{
			get
			{
				return this._Rounded;
			}
			set
			{
				this._Rounded = value;
			}
		}
		[DebuggerNonUserCode]
		private static void __ENCAddToList(object value)
		{
			List<WeakReference> _ENCList = FlatButton.__ENCList;
			bool flag = false;
			checked
			{
				try
				{
					Monitor.Enter(_ENCList, ref flag);
					bool flag2 = FlatButton.__ENCList.Count == FlatButton.__ENCList.Capacity;
					if (flag2)
					{
						int num = 0;
						int arg_44_0 = 0;
						int num2 = FlatButton.__ENCList.Count - 1;
						int num3 = arg_44_0;
						while (true)
						{
							int arg_95_0 = num3;
							int num4 = num2;
							if (arg_95_0 > num4)
							{
								break;
							}
							WeakReference weakReference = FlatButton.__ENCList[num3];
							flag2 = weakReference.IsAlive;
							if (flag2)
							{
								bool flag3 = num3 != num;
								if (flag3)
								{
									FlatButton.__ENCList[num] = FlatButton.__ENCList[num3];
								}
								num++;
							}
							num3++;
						}
						FlatButton.__ENCList.RemoveRange(num, FlatButton.__ENCList.Count - num);
						FlatButton.__ENCList.Capacity = FlatButton.__ENCList.Count;
					}
					FlatButton.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
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
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			this.State = MouseState.Down;
			this.Invalidate();
		}
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.State = MouseState.Over;
			this.Invalidate();
		}
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			this.State = MouseState.Over;
			this.Invalidate();
		}
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.State = MouseState.None;
			this.Invalidate();
		}
		public FlatButton()
		{
			FlatButton.__ENCAddToList(this);
			this._Rounded = false;
			this.State = MouseState.None;
			this._BaseColor = Helpers._FlatColor;
			this._TextColor = color .FromArgb(243, 243, 243);
			this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			Size size = new Size(106, 32);
			this.Size = size;
			this.BackColor = color .Transparent;
			this.Font = new Font("Segoe UI", 12f);
			this.Cursor = Cursors.Hand;
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			Helpers.B = new Bitmap(this.Width, this.Height);
			Helpers.G = Graphics.FromImage(Helpers.B);
			checked
			{
				this.W = this.Width - 1;
				this.H = this.Height - 1;
				GraphicsPath GP = new GraphicsPath();
				rectangle Base = new rectangle (0, 0, this.W, this.H);
				Graphics g = Helpers.G;
				g.SmoothingMode = SmoothingMode.HighQuality;
				g.PixelOffsetMode = PixelOffsetMode.HighQuality;
				g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				g.Clear(this.BackColor);
				switch (this.State)
				{
				case MouseState.None:
				{
					bool rounded = this.Rounded;
					if (rounded)
					{
						GP = Helpers.RoundRec(Base, 6);
						g.FillPath(new SolidBrush(this._BaseColor), GP);
						g.DrawString(this.Text, this.Font, new SolidBrush(this._TextColor), Base, Helpers.CenterSF);
					}
					else
					{
						g.FillRectangle(new SolidBrush(this._BaseColor), Base);
						g.DrawString(this.Text, this.Font, new SolidBrush(this._TextColor), Base, Helpers.CenterSF);
					}
					break;
				}
				case MouseState.Over:
				{
					bool rounded = this.Rounded;
					if (rounded)
					{
						GP = Helpers.RoundRec(Base, 6);
						g.FillPath(new SolidBrush(this._BaseColor), GP);
						g.FillPath(new SolidBrush(color.FromArgb(20, color .White)), GP);
						g.DrawString(this.Text, this.Font, new SolidBrush(this._TextColor), Base, Helpers.CenterSF);
					}
					else
					{
						g.FillRectangle(new SolidBrush(this._BaseColor), Base);
						g.FillRectangle(new SolidBrush(color.FromArgb(20, color .White)), Base);
						g.DrawString(this.Text, this.Font, new SolidBrush(this._TextColor), Base, Helpers.CenterSF);
					}
					break;
				}
				case MouseState.Down:
				{
					bool rounded = this.Rounded;
					if (rounded)
					{
						GP = Helpers.RoundRec(Base, 6);
						g.FillPath(new SolidBrush(this._BaseColor), GP);
						g.FillPath(new SolidBrush(color.FromArgb(20, color .Black)), GP);
						g.DrawString(this.Text, this.Font, new SolidBrush(this._TextColor), Base, Helpers.CenterSF);
					}
					else
					{
						g.FillRectangle(new SolidBrush(this._BaseColor), Base);
						g.FillRectangle(new SolidBrush(color.FromArgb(20, color .Black)), Base);
						g.DrawString(this.Text, this.Font, new SolidBrush(this._TextColor), Base, Helpers.CenterSF);
					}
					break;
				}
				}
				base.OnPaint(e);
				Helpers.G.Dispose();
				e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
				Helpers.B.Dispose();
			}
		}
	}
}
