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
	public class FlatColorPalette : Control
	{
		private static List<WeakReference> __ENCList = new List<WeakReference>();
		private int W;
		private int H;
		private Color _Red;
		private Color _Cyan;
		private Color _Blue;
		private Color _LimeGreen;
		private Color _Orange;
		private Color _Purple;
		private Color _Black;
		private Color _Gray;
		private Color _White;
		[Category("Colors")]
		public Color Red
		{
			get
			{
				return this._Red;
			}
			set
			{
				this._Red = value;
			}
		}
		[Category("Colors")]
		public Color Cyan
		{
			get
			{
				return this._Cyan;
			}
			set
			{
				this._Cyan = value;
			}
		}
		[Category("Colors")]
		public Color Blue
		{
			get
			{
				return this._Blue;
			}
			set
			{
				this._Blue = value;
			}
		}
		[Category("Colors")]
		public Color LimeGreen
		{
			get
			{
				return this._LimeGreen;
			}
			set
			{
				this._LimeGreen = value;
			}
		}
		[Category("Colors")]
		public Color Orange
		{
			get
			{
				return this._Orange;
			}
			set
			{
				this._Orange = value;
			}
		}
		[Category("Colors")]
		public Color Purple
		{
			get
			{
				return this._Purple;
			}
			set
			{
				this._Purple = value;
			}
		}
		[Category("Colors")]
		public Color Black
		{
			get
			{
				return this._Black;
			}
			set
			{
				this._Black = value;
			}
		}
		[Category("Colors")]
		public Color Gray
		{
			get
			{
				return this._Gray;
			}
			set
			{
				this._Gray = value;
			}
		}
		[Category("Colors")]
		public Color White
		{
			get
			{
				return this._White;
			}
			set
			{
				this._White = value;
			}
		}
		[DebuggerNonUserCode]
		private static void __ENCAddToList(object value)
		{
			List<WeakReference> _ENCList = FlatColorPalette.__ENCList;
			bool flag = false;
			checked
			{
				try
				{
					Monitor.Enter(_ENCList, ref flag);
					bool flag2 = FlatColorPalette.__ENCList.Count == FlatColorPalette.__ENCList.Capacity;
					if (flag2)
					{
						int num = 0;
						int arg_44_0 = 0;
						int num2 = FlatColorPalette.__ENCList.Count - 1;
						int num3 = arg_44_0;
						while (true)
						{
							int arg_95_0 = num3;
							int num4 = num2;
							if (arg_95_0 > num4)
							{
								break;
							}
							WeakReference weakReference = FlatColorPalette.__ENCList[num3];
							flag2 = weakReference.IsAlive;
							if (flag2)
							{
								bool flag3 = num3 != num;
								if (flag3)
								{
									FlatColorPalette.__ENCList[num] = FlatColorPalette.__ENCList[num3];
								}
								num++;
							}
							num3++;
						}
						FlatColorPalette.__ENCList.RemoveRange(num, FlatColorPalette.__ENCList.Count - num);
						FlatColorPalette.__ENCList.Capacity = FlatColorPalette.__ENCList.Count;
					}
					FlatColorPalette.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
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
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			this.Width = 180;
			this.Height = 80;
		}
		public FlatColorPalette()
		{
			FlatColorPalette.__ENCAddToList(this);
			this._Red = Color.FromArgb(220, 85, 96);
			this._Cyan = Color.FromArgb(10, 154, 157);
			this._Blue = Color.FromArgb(0, 128, 255);
			this._LimeGreen = Color.FromArgb(35, 168, 109);
			this._Orange = Color.FromArgb(253, 181, 63);
			this._Purple = Color.FromArgb(155, 88, 181);
			this._Black = Color.FromArgb(45, 47, 49);
			this._Gray = Color.FromArgb(63, 70, 73);
			this._White = Color.FromArgb(243, 243, 243);
			this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.BackColor = Color.FromArgb(60, 70, 73);
			Size size = new Size(160, 80);
			this.Size = size;
			this.Font = new Font("Segoe UI", 12f);
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			Helpers.B = new Bitmap(this.Width, this.Height);
			Helpers.G = Graphics.FromImage(Helpers.B);
			checked
			{
				this.W = this.Width - 1;
				this.H = this.Height - 1;
				Graphics g = Helpers.G;
				g.SmoothingMode = SmoothingMode.HighQuality;
				g.PixelOffsetMode = PixelOffsetMode.HighQuality;
				g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				g.Clear(this.BackColor);
				Graphics arg_88_0 = g;
				Brush arg_88_1 = new SolidBrush(this._Red);
				Rectangle rectangle = new Rectangle(0, 0, 20, 40);
				arg_88_0.FillRectangle(arg_88_1, rectangle);
				Graphics arg_AA_0 = g;
				Brush arg_AA_1 = new SolidBrush(this._Cyan);
				rectangle = new Rectangle(20, 0, 20, 40);
				arg_AA_0.FillRectangle(arg_AA_1, rectangle);
				Graphics arg_CC_0 = g;
				Brush arg_CC_1 = new SolidBrush(this._Blue);
				rectangle = new Rectangle(40, 0, 20, 40);
				arg_CC_0.FillRectangle(arg_CC_1, rectangle);
				Graphics arg_EE_0 = g;
				Brush arg_EE_1 = new SolidBrush(this._LimeGreen);
				rectangle = new Rectangle(60, 0, 20, 40);
				arg_EE_0.FillRectangle(arg_EE_1, rectangle);
				Graphics arg_110_0 = g;
				Brush arg_110_1 = new SolidBrush(this._Orange);
				rectangle = new Rectangle(80, 0, 20, 40);
				arg_110_0.FillRectangle(arg_110_1, rectangle);
				Graphics arg_132_0 = g;
				Brush arg_132_1 = new SolidBrush(this._Purple);
				rectangle = new Rectangle(100, 0, 20, 40);
				arg_132_0.FillRectangle(arg_132_1, rectangle);
				Graphics arg_154_0 = g;
				Brush arg_154_1 = new SolidBrush(this._Black);
				rectangle = new Rectangle(120, 0, 20, 40);
				arg_154_0.FillRectangle(arg_154_1, rectangle);
				Graphics arg_179_0 = g;
				Brush arg_179_1 = new SolidBrush(this._Gray);
				rectangle = new Rectangle(140, 0, 20, 40);
				arg_179_0.FillRectangle(arg_179_1, rectangle);
				Graphics arg_19E_0 = g;
				Brush arg_19E_1 = new SolidBrush(this._White);
				rectangle = new Rectangle(160, 0, 20, 40);
				arg_19E_0.FillRectangle(arg_19E_1, rectangle);
				Graphics arg_1DD_0 = g;
				string arg_1DD_1 = "Color Palette";
				Font arg_1DD_2 = this.Font;
				Brush arg_1DD_3 = new SolidBrush(this._White);
				rectangle = new Rectangle(0, 22, this.W, this.H);
				arg_1DD_0.DrawString(arg_1DD_1, arg_1DD_2, arg_1DD_3, rectangle, Helpers.CenterSF);
				base.OnPaint(e);
				Helpers.G.Dispose();
				e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
				Helpers.B.Dispose();
			}
		}
	}
}
