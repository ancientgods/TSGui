using Microsoft.VisualBasic.CompilerServices;
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
using point = System.Drawing.Point;

namespace magnusi
{
	public class FlatNumeric : Control
	{
		private static List<WeakReference> __ENCList = new List<WeakReference>();
		private int W;
		private int H;
		private MouseState State;
		private int x;
		private int y;
		private long _Value;
		private long _Min;
		private long _Max;
		private bool Bool;
		private color  _BaseColor;
		private color  _ButtonColor;
		public long Value
		{
			get
			{
				return this._Value;
			}
			set
			{
				bool flag = value <= this._Max & value >= this._Min;
				if (flag)
				{
					this._Value = value;
				}
				this.Invalidate();
			}
		}
		public long Maximum
		{
			get
			{
				return this._Max;
			}
			set
			{
				bool flag = value > this._Min;
				if (flag)
				{
					this._Max = value;
				}
				flag = (this._Value > this._Max);
				if (flag)
				{
					this._Value = this._Max;
				}
				this.Invalidate();
			}
		}
		public long Minimum
		{
			get
			{
				return this._Min;
			}
			set
			{
				bool flag = value < this._Max;
				if (flag)
				{
					this._Min = value;
				}
				flag = (this._Value < this._Min);
				if (flag)
				{
					this._Value = this.Minimum;
				}
				this.Invalidate();
			}
		}
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
		public color  ButtonColor
		{
			get
			{
				return this._ButtonColor;
			}
			set
			{
				this._ButtonColor = value;
			}
		}
		[DebuggerNonUserCode]
		private static void __ENCAddToList(object value)
		{
			List<WeakReference> _ENCList = FlatNumeric.__ENCList;
			bool flag = false;
			checked
			{
				try
				{
					Monitor.Enter(_ENCList, ref flag);
					bool flag2 = FlatNumeric.__ENCList.Count == FlatNumeric.__ENCList.Capacity;
					if (flag2)
					{
						int num = 0;
						int arg_44_0 = 0;
						int num2 = FlatNumeric.__ENCList.Count - 1;
						int num3 = arg_44_0;
						while (true)
						{
							int arg_95_0 = num3;
							int num4 = num2;
							if (arg_95_0 > num4)
							{
								break;
							}
							WeakReference weakReference = FlatNumeric.__ENCList[num3];
							flag2 = weakReference.IsAlive;
							if (flag2)
							{
								bool flag3 = num3 != num;
								if (flag3)
								{
									FlatNumeric.__ENCList[num] = FlatNumeric.__ENCList[num3];
								}
								num++;
							}
							num3++;
						}
						FlatNumeric.__ENCList.RemoveRange(num, FlatNumeric.__ENCList.Count - num);
						FlatNumeric.__ENCList.Capacity = FlatNumeric.__ENCList.Count;
					}
					FlatNumeric.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
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
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			this.x = e.Location.X;
			this.y = e.Location.Y;
			this.Invalidate();
			bool flag = e.X < checked(this.Width - 23);
			if (flag)
			{
				this.Cursor = Cursors.IBeam;
			}
			else
			{
				this.Cursor = Cursors.Hand;
			}
		}
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			checked
			{
				bool flag = this.x > this.Width - 21 && this.x < this.Width - 3;
				if (flag)
				{
					bool flag2 = this.y < 15;
					if (flag2)
					{
						bool flag3 = this.Value + 1L <= this._Max;
						if (flag3)
						{
							this._Value += 1L;
						}
					}
					else
					{
						bool flag3 = this.Value - 1L >= this._Min;
						if (flag3)
						{
							this._Value -= 1L;
						}
					}
				}
				else
				{
					this.Bool = !this.Bool;
					this.Focus();
				}
				this.Invalidate();
			}
		}
		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			base.OnKeyPress(e);
			try
			{
				bool flag = this.Bool;
				if (flag)
				{
					this._Value = Conversions.ToLong(Conversions.ToString(this._Value) + e.KeyChar.ToString());
				}
				flag = (this._Value > this._Max);
				if (flag)
				{
					this._Value = this._Max;
				}
				this.Invalidate();
			}
			catch (Exception arg_64_0)
			{
				ProjectData.SetProjectError(arg_64_0);
				ProjectData.ClearProjectError();
			}
		}
		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
			bool flag = e.KeyCode == Keys.Back;
			if (flag)
			{
				this.Value = 0L;
			}
		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			this.Height = 30;
		}
		public FlatNumeric()
		{
			FlatNumeric.__ENCAddToList(this);
			this.State = MouseState.None;
			this._BaseColor = color .FromArgb(45, 47, 49);
			this._ButtonColor = Helpers._FlatColor;
			this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.Font = new Font("Segoe UI", 10f);
			this.BackColor = color .FromArgb(60, 70, 73);
			this.ForeColor = color .White;
			this._Min = 0L;
			this._Max = 9999999L;
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			Helpers.B = new Bitmap(this.Width, this.Height);
			Helpers.G = Graphics.FromImage(Helpers.B);
			this.W = this.Width;
			this.H = this.Height;
			rectangle Base = new rectangle (0, 0, this.W, this.H);
			Graphics g = Helpers.G;
			g.SmoothingMode = SmoothingMode.HighQuality;
			g.PixelOffsetMode = PixelOffsetMode.HighQuality;
			g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			g.Clear(this.BackColor);
			g.FillRectangle(new SolidBrush(this._BaseColor), Base);
			Graphics arg_B9_0 = g;
			Brush arg_B9_1 = new SolidBrush(this._ButtonColor);
			checked
			{
				rectangle rectangle  = new rectangle (this.Width - 24, 0, 24, this.H);
				arg_B9_0.FillRectangle(arg_B9_1, rectangle );
				Graphics arg_F6_0 = g;
				string arg_F6_1 = "+";
				Font arg_F6_2 = new Font("Segoe UI", 12f);
				Brush arg_F6_3 = Brushes.White;
				point p = new point(this.Width - 12, 8);
				arg_F6_0.DrawString(arg_F6_1, arg_F6_2, arg_F6_3, p, Helpers.CenterSF);
				Graphics arg_135_0 = g;
				string arg_135_1 = "-";
				Font arg_135_2 = new Font("Segoe UI", 10f, FontStyle.Bold);
				Brush arg_135_3 = Brushes.White;
				p = new point(this.Width - 12, 22);
				arg_135_0.DrawString(arg_135_1, arg_135_2, arg_135_3, p, Helpers.CenterSF);
				Graphics arg_180_0 = g;
				string arg_180_1 = Conversions.ToString(this.Value);
				Font arg_180_2 = this.Font;
				Brush arg_180_3 = Brushes.White;
				rectangle = new rectangle (5, 1, this.W, this.H);
				arg_180_0.DrawString(arg_180_1, arg_180_2, arg_180_3, rectangle , new StringFormat
				{
					LineAlignment = StringAlignment.Center
				});
				base.OnPaint(e);
				Helpers.G.Dispose();
				e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
				Helpers.B.Dispose();
			}
		}
	}
}
