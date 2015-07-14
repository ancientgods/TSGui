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

namespace magnusi
{
	public class FlatStatusBar : Control
	{
		private static List<WeakReference> __ENCList = new List<WeakReference>();
		private int W;
		private int H;
		private bool _ShowTimeDate;
		private color  _BaseColor;
		private color  _TextColor;
		private color  _RectColor;
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
		[Category("Colors")]
		public color  RectColor
		{
			get
			{
				return this._RectColor;
			}
			set
			{
				this._RectColor = value;
			}
		}
		public bool ShowTimeDate
		{
			get
			{
				return this._ShowTimeDate;
			}
			set
			{
				this._ShowTimeDate = value;
			}
		}
		[DebuggerNonUserCode]
		private static void __ENCAddToList(object value)
		{
			List<WeakReference> _ENCList = FlatStatusBar.__ENCList;
			bool flag = false;
			checked
			{
				try
				{
					Monitor.Enter(_ENCList, ref flag);
					bool flag2 = FlatStatusBar.__ENCList.Count == FlatStatusBar.__ENCList.Capacity;
					if (flag2)
					{
						int num = 0;
						int arg_44_0 = 0;
						int num2 = FlatStatusBar.__ENCList.Count - 1;
						int num3 = arg_44_0;
						while (true)
						{
							int arg_95_0 = num3;
							int num4 = num2;
							if (arg_95_0 > num4)
							{
								break;
							}
							WeakReference weakReference = FlatStatusBar.__ENCList[num3];
							flag2 = weakReference.IsAlive;
							if (flag2)
							{
								bool flag3 = num3 != num;
								if (flag3)
								{
									FlatStatusBar.__ENCList[num] = FlatStatusBar.__ENCList[num3];
								}
								num++;
							}
							num3++;
						}
						FlatStatusBar.__ENCList.RemoveRange(num, FlatStatusBar.__ENCList.Count - num);
						FlatStatusBar.__ENCList.Capacity = FlatStatusBar.__ENCList.Count;
					}
					FlatStatusBar.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
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
		protected override void CreateHandle()
		{
			base.CreateHandle();
			this.Dock = DockStyle.Bottom;
		}
		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			this.Invalidate();
		}
		public string GetTimeDate()
		{
			return string.Concat(new string[]
			{
				Conversions.ToString(DateTime.Now.Date),
				" ",
				Conversions.ToString(DateTime.Now.Hour),
				":",
				Conversions.ToString(DateTime.Now.Minute)
			});
		}
		public FlatStatusBar()
		{
			FlatStatusBar.__ENCAddToList(this);
			this._ShowTimeDate = false;
			this._BaseColor = color .FromArgb(45, 47, 49);
			this._TextColor = color .White;
			this._RectColor = Helpers._FlatColor;
			this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.Font = new Font("Segoe UI", 8f);
			this.ForeColor = color .White;
			Size size = new Size(this.Width, 20);
			this.Size = size;
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
			g.Clear(this.BaseColor);
			g.FillRectangle(new SolidBrush(this.BaseColor), Base);
			Graphics arg_C6_0 = g;
			string arg_C6_1 = this.Text;
			Font arg_C6_2 = this.Font;
			Brush arg_C6_3 = Brushes.White;
			rectangle rectangle  = new rectangle (10, 4, this.W, this.H);
			arg_C6_0.DrawString(arg_C6_1, arg_C6_2, arg_C6_3, rectangle , Helpers.NearSF);
			Graphics arg_E6_0 = g;
			Brush arg_E6_1 = new SolidBrush(this._RectColor);
			rectangle = new rectangle (4, 4, 4, 14);
			arg_E6_0.FillRectangle(arg_E6_1, rectangle );
			bool showTimeDate = this.ShowTimeDate;
			if (showTimeDate)
			{
				Graphics arg_144_0 = g;
				string arg_144_1 = this.GetTimeDate();
				Font arg_144_2 = this.Font;
				Brush arg_144_3 = new SolidBrush(this._TextColor);
				rectangle = new rectangle (-4, 2, this.W, this.H);
				arg_144_0.DrawString(arg_144_1, arg_144_2, arg_144_3, rectangle , new StringFormat
				{
					Alignment = StringAlignment.Far,
					LineAlignment = StringAlignment.Center
				});
			}
			base.OnPaint(e);
			Helpers.G.Dispose();
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
			Helpers.B.Dispose();
		}
	}
}
