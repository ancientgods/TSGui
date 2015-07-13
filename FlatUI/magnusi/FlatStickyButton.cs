using System;
using System.Collections;
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
	public class FlatStickyButton : Control
	{
		private static List<WeakReference> __ENCList = new List<WeakReference>();
		private int W;
		private int H;
		private MouseState State;
		private bool _Rounded;
		private Color _BaseColor;
		private Color _TextColor;
		private Rectangle Rect
		{
			get
			{
				Rectangle result = new Rectangle(this.Left, this.Top, this.Width, this.Height);
				return result;
			}
		}
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
			List<WeakReference> _ENCList = FlatStickyButton.__ENCList;
			bool flag = false;
			checked
			{
				try
				{
					Monitor.Enter(_ENCList, ref flag);
					bool flag2 = FlatStickyButton.__ENCList.Count == FlatStickyButton.__ENCList.Capacity;
					if (flag2)
					{
						int num = 0;
						int arg_44_0 = 0;
						int num2 = FlatStickyButton.__ENCList.Count - 1;
						int num3 = arg_44_0;
						while (true)
						{
							int arg_95_0 = num3;
							int num4 = num2;
							if (arg_95_0 > num4)
							{
								break;
							}
							WeakReference weakReference = FlatStickyButton.__ENCList[num3];
							flag2 = weakReference.IsAlive;
							if (flag2)
							{
								bool flag3 = num3 != num;
								if (flag3)
								{
									FlatStickyButton.__ENCList[num] = FlatStickyButton.__ENCList[num3];
								}
								num++;
							}
							num3++;
						}
						FlatStickyButton.__ENCList.RemoveRange(num, FlatStickyButton.__ENCList.Count - num);
						FlatStickyButton.__ENCList.Capacity = FlatStickyButton.__ENCList.Count;
					}
					FlatStickyButton.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
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
		private bool[] GetConnectedSides()
		{
			bool[] Bool = new bool[]
			{
				false,
				false,
				false,
				false
			};
			try
			{
				IEnumerator enumerator = this.Parent.Controls.GetEnumerator();
				while (enumerator.MoveNext())
				{
					Control B = (Control)enumerator.Current;
					bool flag = B is FlatStickyButton;
					if (flag)
					{
						bool flag2 = B == this | !this.Rect.IntersectsWith(this.Rect);
						if (!flag2)
						{
							double A = checked(Math.Atan2((double)(this.Left - B.Left), (double)(this.Top - B.Top))) * 2.0 / 3.1415926535897931;
							checked
							{
								flag2 = ((double)((long)Math.Round(A) / 1L) == A);
								if (flag2)
								{
									Bool[(int)Math.Round(unchecked(A + 1.0))] = true;
								}
							}
						}
					}
				}
			}
			finally
			{

			}
			return Bool;
		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
		}
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
		}
		public FlatStickyButton()
		{
			FlatStickyButton.__ENCAddToList(this);
			this.State = MouseState.None;
			this._Rounded = false;
			this._BaseColor = Helpers._FlatColor;
			this._TextColor = Color.FromArgb(243, 243, 243);
			this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			Size size = new Size(106, 32);
			this.Size = size;
			this.BackColor = Color.Transparent;
			this.Font = new Font("Segoe UI", 12f);
			this.Cursor = Cursors.Hand;
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			Helpers.B = new Bitmap(this.Width, this.Height);
			Helpers.G = Graphics.FromImage(Helpers.B);
			this.W = this.Width;
			this.H = this.Height;
			GraphicsPath GP = new GraphicsPath();
			bool[] GCS = this.GetConnectedSides();
			GraphicsPath RoundedBase = Helpers.RoundRect(0f, 0f, (float)this.W, (float)this.H, 0.3f, !(GCS[2] | GCS[1]), !(GCS[1] | GCS[0]), !(GCS[3] | GCS[0]), !(GCS[3] | GCS[2]));
			Rectangle Base = new Rectangle(0, 0, this.W, this.H);
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
					GP = RoundedBase;
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
					GP = RoundedBase;
					g.FillPath(new SolidBrush(this._BaseColor), GP);
					g.FillPath(new SolidBrush(Color.FromArgb(20, Color.White)), GP);
					g.DrawString(this.Text, this.Font, new SolidBrush(this._TextColor), Base, Helpers.CenterSF);
				}
				else
				{
					g.FillRectangle(new SolidBrush(this._BaseColor), Base);
					g.FillRectangle(new SolidBrush(Color.FromArgb(20, Color.White)), Base);
					g.DrawString(this.Text, this.Font, new SolidBrush(this._TextColor), Base, Helpers.CenterSF);
				}
				break;
			}
			case MouseState.Down:
			{
				bool rounded = this.Rounded;
				if (rounded)
				{
					GP = RoundedBase;
					g.FillPath(new SolidBrush(this._BaseColor), GP);
					g.FillPath(new SolidBrush(Color.FromArgb(20, Color.Black)), GP);
					g.DrawString(this.Text, this.Font, new SolidBrush(this._TextColor), Base, Helpers.CenterSF);
				}
				else
				{
					g.FillRectangle(new SolidBrush(this._BaseColor), Base);
					g.FillRectangle(new SolidBrush(Color.FromArgb(20, Color.Black)), Base);
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
