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
using color   = System.Drawing.Color;
using rectangle = System.Drawing.Rectangle;

namespace magnusi
{
	public class FlatGroupBox : ContainerControl
	{
		private static List<WeakReference> __ENCList = new List<WeakReference>();
		private int W;
		private int H;
		private bool _ShowText;
		private color   _BaseColor; 
		[Category("Colors")]
		public color   BaseColor
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
		public bool ShowText
		{
			get
			{
				return this._ShowText;
			}
			set
			{
				this._ShowText = value;
			}
		}
		[DebuggerNonUserCode]
		private static void __ENCAddToList(object value)
		{
			List<WeakReference> _ENCList = FlatGroupBox.__ENCList;
			bool flag = false;
			checked
			{
				try
				{
					Monitor.Enter(_ENCList, ref flag);
					bool flag2 = FlatGroupBox.__ENCList.Count == FlatGroupBox.__ENCList.Capacity;
					if (flag2)
					{
						int num = 0;
						int arg_44_0 = 0;
						int num2 = FlatGroupBox.__ENCList.Count - 1;
						int num3 = arg_44_0;
						while (true)
						{
							int arg_95_0 = num3;
							int num4 = num2;
							if (arg_95_0 > num4)
							{
								break;
							}
							WeakReference weakReference = FlatGroupBox.__ENCList[num3];
							flag2 = weakReference.IsAlive;
							if (flag2)
							{
								bool flag3 = num3 != num;
								if (flag3)
								{
									FlatGroupBox.__ENCList[num] = FlatGroupBox.__ENCList[num3];
								}
								num++;
							}
							num3++;
						}
						FlatGroupBox.__ENCList.RemoveRange(num, FlatGroupBox.__ENCList.Count - num);
						FlatGroupBox.__ENCList.Capacity = FlatGroupBox.__ENCList.Count;
					}
					FlatGroupBox.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
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
		public FlatGroupBox()
		{
			FlatGroupBox.__ENCAddToList(this);
			this._ShowText = true;
			this._BaseColor = color  .FromArgb(60, 70, 73);
			this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.BackColor = color  .Transparent;
			Size size = new Size(240, 180);
			this.Size = size;
			this.Font = new Font("Segoe ui", 10f);
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
				GraphicsPath GP2 = new GraphicsPath();
				GraphicsPath GP3 = new GraphicsPath();
				rectangle Base = new rectangle (8, 8, this.W - 16, this.H - 16);
				Graphics g = Helpers.G;
				g.SmoothingMode = SmoothingMode.HighQuality;
				g.PixelOffsetMode = PixelOffsetMode.HighQuality;
				g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				g.Clear(this.BackColor);
				GP = Helpers.RoundRec(Base, 8);
				g.FillPath(new SolidBrush(this._BaseColor), GP);
				GP2 = Helpers.DrawArrow(28, 2, false);
				g.FillPath(new SolidBrush(this._BaseColor), GP2);
				GP3 = Helpers.DrawArrow(28, 8, true);
				g.FillPath(new SolidBrush(color.FromArgb(60, 70, 73)), GP3);
				bool showText = this.ShowText;
				if (showText)
				{
					Graphics arg_145_0 = g;
					string arg_145_1 = this.Text;
					Font arg_145_2 = this.Font;
					Brush arg_145_3 = new SolidBrush(Helpers._FlatColor);
					rectangle r = new rectangle (16, 16, this.W, this.H);
					arg_145_0.DrawString(arg_145_1, arg_145_2, arg_145_3, r, Helpers.NearSF);
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
