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
namespace magnusi
{
	public class FlatProgressBar : Control
	{
		private static List<WeakReference> __ENCList = new List<WeakReference>();
		private int W;
		private int H;
		private int _Value;
		private int _Maximum;
		private Color _BaseColor;
		private Color _ProgressColor;
		private Color _DarkerProgress;
		[Category("Control")]
		public int Maximum
		{
			get
			{
				return this._Maximum;
			}
			set
			{
				bool flag = value < this._Value;
				if (flag)
				{
					this._Value = value;
				}
				this._Maximum = value;
				this.Invalidate();
			}
		}
		[Category("Control")]
		public int Value
		{
			get
			{
				int value = this._Value;
				bool flag = value == 0;
				int Value;
				if (flag)
				{
					Value = 0;
				}
				else
				{
					Value = this._Value;
				}
				return Value;
			}
			set
			{
				int num = value;
				bool flag = num > this._Maximum;
				if (flag)
				{
					value = this._Maximum;
					this.Invalidate();
				}
				this._Value = value;
				this.Invalidate();
			}
		}
		[Category("Colors")]
		public Color ProgressColor
		{
			get
			{
				return this._ProgressColor;
			}
			set
			{
				this._ProgressColor = value;
			}
		}
		[Category("Colors")]
		public Color DarkerProgress
		{
			get
			{
				return this._DarkerProgress;
			}
			set
			{
				this._DarkerProgress = value;
			}
		}
		[DebuggerNonUserCode]
		private static void __ENCAddToList(object value)
		{
			List<WeakReference> _ENCList = FlatProgressBar.__ENCList;
			bool flag = false;
			checked
			{
				try
				{
					Monitor.Enter(_ENCList, ref flag);
					bool flag2 = FlatProgressBar.__ENCList.Count == FlatProgressBar.__ENCList.Capacity;
					if (flag2)
					{
						int num = 0;
						int arg_44_0 = 0;
						int num2 = FlatProgressBar.__ENCList.Count - 1;
						int num3 = arg_44_0;
						while (true)
						{
							int arg_95_0 = num3;
							int num4 = num2;
							if (arg_95_0 > num4)
							{
								break;
							}
							WeakReference weakReference = FlatProgressBar.__ENCList[num3];
							flag2 = weakReference.IsAlive;
							if (flag2)
							{
								bool flag3 = num3 != num;
								if (flag3)
								{
									FlatProgressBar.__ENCList[num] = FlatProgressBar.__ENCList[num3];
								}
								num++;
							}
							num3++;
						}
						FlatProgressBar.__ENCList.RemoveRange(num, FlatProgressBar.__ENCList.Count - num);
						FlatProgressBar.__ENCList.Capacity = FlatProgressBar.__ENCList.Count;
					}
					FlatProgressBar.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
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
			this.Height = 42;
		}
		protected override void CreateHandle()
		{
			base.CreateHandle();
			this.Height = 42;
		}
		public void Increment(int Amount)
		{
			checked
			{
				this.Value += Amount;
			}
		}
		public FlatProgressBar()
		{
			FlatProgressBar.__ENCAddToList(this);
			this._Value = 0;
			this._Maximum = 100;
			this._BaseColor = Color.FromArgb(45, 47, 49);
			this._ProgressColor = Helpers._FlatColor;
			this._DarkerProgress = Color.FromArgb(23, 148, 92);
			this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.BackColor = Color.FromArgb(60, 70, 73);
			this.Height = 42;
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			Helpers.B = new Bitmap(this.Width, this.Height);
			Helpers.G = Graphics.FromImage(Helpers.B);
			checked
			{
				this.W = this.Width - 1;
				this.H = this.Height - 1;
				Rectangle Base = new Rectangle(0, 24, this.W, this.H);
				GraphicsPath GP = new GraphicsPath();
				GraphicsPath GP2 = new GraphicsPath();
				GraphicsPath GP3 = new GraphicsPath();
				Graphics g = Helpers.G;
				g.SmoothingMode = SmoothingMode.HighQuality;
				g.PixelOffsetMode = PixelOffsetMode.HighQuality;
				g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				g.Clear(this.BackColor);
				int iValue = (int)Math.Round(unchecked((double)this._Value / (double)this._Maximum * (double)this.Width));
				int value = this.Value;
				bool flag = value == 0;
				if (flag)
				{
					g.FillRectangle(new SolidBrush(this._BaseColor), Base);
					Graphics arg_109_0 = g;
					Brush arg_109_1 = new SolidBrush(this._ProgressColor);
					Rectangle rectangle = new Rectangle(0, 24, iValue - 1, this.H - 1);
					arg_109_0.FillRectangle(arg_109_1, rectangle);
				}
				else
				{
					flag = (value == 100);
					if (flag)
					{
						g.FillRectangle(new SolidBrush(this._BaseColor), Base);
						Graphics arg_15B_0 = g;
						Brush arg_15B_1 = new SolidBrush(this._ProgressColor);
						Rectangle rectangle = new Rectangle(0, 24, iValue - 1, this.H - 1);
						arg_15B_0.FillRectangle(arg_15B_1, rectangle);
					}
					else
					{
						g.FillRectangle(new SolidBrush(this._BaseColor), Base);
						GraphicsPath arg_195_0 = GP;
						Rectangle rectangle = new Rectangle(0, 24, iValue - 1, this.H - 1);
						arg_195_0.AddRectangle(rectangle);
						g.FillPath(new SolidBrush(this._ProgressColor), GP);
						HatchBrush HB = new HatchBrush(HatchStyle.Plaid, this._DarkerProgress, this._ProgressColor);
						Graphics arg_1E1_0 = g;
						Brush arg_1E1_1 = HB;
						rectangle = new Rectangle(0, 24, iValue - 1, this.H - 1);
						arg_1E1_0.FillRectangle(arg_1E1_1, rectangle);
						Rectangle Balloon = new Rectangle(iValue - 18, 0, 34, 16);
						GP2 = Helpers.RoundRec(Balloon, 4);
						g.FillPath(new SolidBrush(this._BaseColor), GP2);
						GP3 = Helpers.DrawArrow(iValue - 9, 16, true);
						g.FillPath(new SolidBrush(this._BaseColor), GP3);
						Graphics arg_286_0 = g;
						string arg_286_1 = Conversions.ToString(this.Value);
						Font arg_286_2 = new Font("Segoe UI", 10f);
						Brush arg_286_3 = new SolidBrush(this._ProgressColor);
						rectangle = new Rectangle(iValue - 11, -2, this.W, this.H);
						arg_286_0.DrawString(arg_286_1, arg_286_2, arg_286_3, rectangle, Helpers.NearSF);
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
