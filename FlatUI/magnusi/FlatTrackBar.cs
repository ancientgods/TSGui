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
	[DefaultEvent("Scroll")]
	public class FlatTrackBar : Control
	{
		[Flags]
		public enum _Style
		{
			Slider = 0,
			Knob = 1
		}
		public delegate void ScrollEventHandler(object sender);
		private static List<WeakReference> __ENCList = new List<WeakReference>();
		private int W;
		private int H;
		private int Val;
		private bool Bool;
		private Rectangle Track;
		private Rectangle Knob;
		private FlatTrackBar._Style Style_;
		private FlatTrackBar.ScrollEventHandler ScrollEvent;
		private int _Minimum;
		private int _Maximum;
		private int _Value;
		private bool _ShowValue;
		private Color BaseColor;
		private Color _TrackColor;
		private Color SliderColor;
		private Color _HatchColor;
		public event FlatTrackBar.ScrollEventHandler Scroll
		{
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.ScrollEvent = (FlatTrackBar.ScrollEventHandler)Delegate.Combine(this.ScrollEvent, value);
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.ScrollEvent = (FlatTrackBar.ScrollEventHandler)Delegate.Remove(this.ScrollEvent, value);
			}
		}
		public FlatTrackBar._Style Style
		{
			get
			{
				return this.Style_;
			}
			set
			{
				this.Style_ = value;
			}
		}
		[Category("Colors")]
		public Color TrackColor
		{
			get
			{
				return this._TrackColor;
			}
			set
			{
				this._TrackColor = value;
			}
		}
		[Category("Colors")]
		public Color HatchColor
		{
			get
			{
				return this._HatchColor;
			}
			set
			{
				this._HatchColor = value;
			}
		}
		public int Minimum
		{
			get
			{
				int Minimum = 0;
				return Minimum;
			}
			set
			{
				bool flag = value < 0;
				if (flag)
				{
				}
				this._Minimum = value;
				flag = (value > this._Value);
				if (flag)
				{
					this._Value = value;
				}
				flag = (value > this._Maximum);
				if (flag)
				{
					this._Maximum = value;
				}
				this.Invalidate();
			}
		}
		public int Maximum
		{
			get
			{
				return this._Maximum;
			}
			set
			{
				bool flag = value < 0;
				if (flag)
				{
				}
				this._Maximum = value;
				flag = (value < this._Value);
				if (flag)
				{
					this._Value = value;
				}
				flag = (value < this._Minimum);
				if (flag)
				{
					this._Minimum = value;
				}
				this.Invalidate();
			}
		}
		public int Value
		{
			get
			{
				return this._Value;
			}
			set
			{
				bool flag = value == this._Value;
				if (!flag)
				{
					flag = (value > this._Maximum || value < this._Minimum);
					if (flag)
					{
					}
					this._Value = value;
					this.Invalidate();
					FlatTrackBar.ScrollEventHandler scrollEvent = this.ScrollEvent;
					flag = (scrollEvent != null);
					if (flag)
					{
						scrollEvent(this);
					}
				}
			}
		}
		public bool ShowValue
		{
			get
			{
				return this._ShowValue;
			}
			set
			{
				this._ShowValue = value;
			}
		}
		[DebuggerNonUserCode]
		private static void __ENCAddToList(object value)
		{
			List<WeakReference> _ENCList = FlatTrackBar.__ENCList;
			bool flag = false;
			checked
			{
				try
				{
					Monitor.Enter(_ENCList, ref flag);
					bool flag2 = FlatTrackBar.__ENCList.Count == FlatTrackBar.__ENCList.Capacity;
					if (flag2)
					{
						int num = 0;
						int arg_44_0 = 0;
						int num2 = FlatTrackBar.__ENCList.Count - 1;
						int num3 = arg_44_0;
						while (true)
						{
							int arg_95_0 = num3;
							int num4 = num2;
							if (arg_95_0 > num4)
							{
								break;
							}
							WeakReference weakReference = FlatTrackBar.__ENCList[num3];
							flag2 = weakReference.IsAlive;
							if (flag2)
							{
								bool flag3 = num3 != num;
								if (flag3)
								{
									FlatTrackBar.__ENCList[num] = FlatTrackBar.__ENCList[num3];
								}
								num++;
							}
							num3++;
						}
						FlatTrackBar.__ENCList.RemoveRange(num, FlatTrackBar.__ENCList.Count - num);
						FlatTrackBar.__ENCList.Capacity = FlatTrackBar.__ENCList.Count;
					}
					FlatTrackBar.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
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
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				this.Val = checked((int)Math.Round(unchecked(checked((double)(this._Value - this._Minimum) / (double)(this._Maximum - this._Minimum)) * (double)checked(this.Width - 11))));
				this.Track = new Rectangle(this.Val, 0, 10, 20);
				this.Bool = this.Track.Contains(e.Location);
			}
		}
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			checked
			{
				bool flag = this.Bool && e.X > -1 && e.X < this.Width + 1;
				if (flag)
				{
					this.Value = this._Minimum + (int)Math.Round(unchecked((double)checked(this._Maximum - this._Minimum) * ((double)e.X / (double)this.Width)));
				}
			}
		}
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.Bool = false;
		}
		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
			bool flag = e.KeyCode == Keys.Subtract;
			checked
			{
				if (flag)
				{
					bool flag2 = this.Value == 0;
					if (!flag2)
					{
						this.Value--;
					}
				}
				else
				{
					bool flag2 = e.KeyCode == Keys.Add;
					if (flag2)
					{
						flag = (this.Value == this._Maximum);
						if (!flag)
						{
							this.Value++;
						}
					}
				}
			}
		}
		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			this.Invalidate();
		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			this.Height = 23;
		}
		public FlatTrackBar()
		{
			FlatTrackBar.__ENCAddToList(this);
			this._Maximum = 10;
			this._ShowValue = false;
			this.BaseColor = Color.FromArgb(45, 47, 49);
			this._TrackColor = Helpers._FlatColor;
			this.SliderColor = Color.FromArgb(25, 27, 29);
			this._HatchColor = Color.FromArgb(23, 148, 92);
			this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.Height = 18;
			this.BackColor = Color.FromArgb(60, 70, 73);
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			Helpers.B = new Bitmap(this.Width, this.Height);
			Helpers.G = Graphics.FromImage(Helpers.B);
			checked
			{
				this.W = this.Width - 1;
				this.H = this.Height - 1;
				Rectangle Base = new Rectangle(1, 6, this.W - 2, 8);
				GraphicsPath GP = new GraphicsPath();
				GraphicsPath GP2 = new GraphicsPath();
				Graphics g = Helpers.G;
				g.SmoothingMode = SmoothingMode.HighQuality;
				g.PixelOffsetMode = PixelOffsetMode.HighQuality;
				g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				g.Clear(this.BackColor);
				this.Val = (int)Math.Round(unchecked(checked((double)(this._Value - this._Minimum) / (double)(this._Maximum - this._Minimum)) * (double)checked(this.W - 10)));
				this.Track = new Rectangle(this.Val, 0, 10, 20);
				this.Knob = new Rectangle(this.Val, 4, 11, 14);
				GP.AddRectangle(Base);
				g.SetClip(GP);
				Graphics arg_124_0 = g;
				Brush arg_124_1 = new SolidBrush(this.BaseColor);
				Rectangle rectangle = new Rectangle(0, 7, this.W, 8);
				arg_124_0.FillRectangle(arg_124_1, rectangle);
				Graphics arg_15B_0 = g;
				Brush arg_15B_1 = new SolidBrush(this._TrackColor);
				rectangle = new Rectangle(0, 7, this.Track.X + this.Track.Width, 8);
				arg_15B_0.FillRectangle(arg_15B_1, rectangle);
				g.ResetClip();
				HatchBrush HB = new HatchBrush(HatchStyle.Plaid, this.HatchColor, this._TrackColor);
				Graphics arg_1A5_0 = g;
				Brush arg_1A5_1 = HB;
				rectangle = new Rectangle(-10, 7, this.Track.X + this.Track.Width, 8);
				arg_1A5_0.FillRectangle(arg_1A5_1, rectangle);
				switch (this.Style)
				{
				case FlatTrackBar._Style.Slider:
					GP2.AddRectangle(this.Track);
					g.FillPath(new SolidBrush(this.SliderColor), GP2);
					break;
				case FlatTrackBar._Style.Knob:
					GP2.AddEllipse(this.Knob);
					g.FillPath(new SolidBrush(this.SliderColor), GP2);
					break;
				}
				bool showValue = this.ShowValue;
				if (showValue)
				{
					Graphics arg_271_0 = g;
					string arg_271_1 = Conversions.ToString(this.Value);
					Font arg_271_2 = new Font("Segoe UI", 8f);
					Brush arg_271_3 = Brushes.White;
					rectangle = new Rectangle(1, 6, this.W, this.H);
					arg_271_0.DrawString(arg_271_1, arg_271_2, arg_271_3, rectangle, new StringFormat
					{
						Alignment = StringAlignment.Far,
						LineAlignment = StringAlignment.Far
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
}
