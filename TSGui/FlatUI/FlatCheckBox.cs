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
using color = System.Drawing.Color;
using rectangle = System.Drawing.Rectangle;

namespace magnusi
{
	[DefaultEvent("CheckedChanged")]
	public class FlatCheckBox : Control
	{
		public delegate void CheckedChangedEventHandler(object sender);
		[Flags]
		public enum _Options
		{
			Style1 = 0,
			Style2 = 1
		}
		private static List<WeakReference> __ENCList = new List<WeakReference>();
		private int W;
		private int H;
		private MouseState State;
		private FlatCheckBox._Options O;
		private bool _Checked;
		private FlatCheckBox.CheckedChangedEventHandler CheckedChangedEvent;
		private color   _BaseColor;
		private color   _BorderColor;
		private color   _TextColor;
		public event FlatCheckBox.CheckedChangedEventHandler CheckedChanged
		{
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.CheckedChangedEvent = (FlatCheckBox.CheckedChangedEventHandler)Delegate.Combine(this.CheckedChangedEvent, value);
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.CheckedChangedEvent = (FlatCheckBox.CheckedChangedEventHandler)Delegate.Remove(this.CheckedChangedEvent, value);
			}
		}
		public bool Checked
		{
			get
			{
				return this._Checked;
			}
			set
			{
				this._Checked = value;
				this.Invalidate();
			}
		}
		[Category("Options")]
		public FlatCheckBox._Options Options
		{
			get
			{
				return this.O;
			}
			set
			{
				this.O = value;
			}
		}
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
		[Category("Colors")]
		public color   BorderColor
		{
			get
			{
				return this._BorderColor;
			}
			set
			{
				this._BorderColor = value;
			}
		}
		[DebuggerNonUserCode]
		private static void __ENCAddToList(object value)
		{
			List<WeakReference> _ENCList = FlatCheckBox.__ENCList;
			bool flag = false;
			checked
			{
				try
				{
					Monitor.Enter(_ENCList, ref flag);
					bool flag2 = FlatCheckBox.__ENCList.Count == FlatCheckBox.__ENCList.Capacity;
					if (flag2)
					{
						int num = 0;
						int arg_44_0 = 0;
						int num2 = FlatCheckBox.__ENCList.Count - 1;
						int num3 = arg_44_0;
						while (true)
						{
							int arg_95_0 = num3;
							int num4 = num2;
							if (arg_95_0 > num4)
							{
								break;
							}
							WeakReference weakReference = FlatCheckBox.__ENCList[num3];
							flag2 = weakReference.IsAlive;
							if (flag2)
							{
								bool flag3 = num3 != num;
								if (flag3)
								{
									FlatCheckBox.__ENCList[num] = FlatCheckBox.__ENCList[num3];
								}
								num++;
							}
							num3++;
						}
						FlatCheckBox.__ENCList.RemoveRange(num, FlatCheckBox.__ENCList.Count - num);
						FlatCheckBox.__ENCList.Capacity = FlatCheckBox.__ENCList.Count;
					}
					FlatCheckBox.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
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
		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			this.Invalidate();
		}
		protected override void OnClick(EventArgs e)
		{
			this._Checked = !this._Checked;
			FlatCheckBox.CheckedChangedEventHandler checkedChangedEvent = this.CheckedChangedEvent;
			bool flag = checkedChangedEvent != null;
			if (flag)
			{
				checkedChangedEvent(this);
			}
			base.OnClick(e);
		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			this.Height = 22;
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
		public FlatCheckBox()
		{
			FlatCheckBox.__ENCAddToList(this);
			this.State = MouseState.None;
			this._BaseColor = color  .FromArgb(45, 47, 49);
			this._BorderColor = Helpers._FlatColor;
			this._TextColor = color  .FromArgb(243, 243, 243);
			this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.BackColor = color  .FromArgb(60, 70, 73);
			this.Cursor = Cursors.Hand;
			this.Font = new Font("Segoe UI", 10f);
			Size size = new Size(112, 22);
			this.Size = size;
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			Helpers.B = new Bitmap(this.Width, this.Height);
			Helpers.G = Graphics.FromImage(Helpers.B);
			checked
			{
				this.W = this.Width - 1;
				this.H = this.Height - 1;
				rectangle Base = new rectangle (0, 2, this.Height - 5, this.Height - 5);
				Graphics g = Helpers.G;
				g.SmoothingMode = SmoothingMode.HighQuality;
				g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				g.Clear(this.BackColor);
				switch (this.O)
				{
				case FlatCheckBox._Options.Style1:
				{
					g.FillRectangle(new SolidBrush(this._BaseColor), Base);
					switch (this.State)
					{
					case MouseState.Over:
						g.DrawRectangle(new Pen(this._BorderColor), Base);
						break;
					case MouseState.Down:
						g.DrawRectangle(new Pen(this._BorderColor), Base);
						break;
					}
					bool flag = this.Checked;
					rectangle r;
					if (flag)
					{
						Graphics arg_14B_0 = g;
						string arg_14B_1 = "Ã¼";
						Font arg_14B_2 = new Font("Wingdings", 18f);
						Brush arg_14B_3 = new SolidBrush(this._BorderColor);
						r = new rectangle (5, 7, this.H - 9, this.H - 9);
						arg_14B_0.DrawString(arg_14B_1, arg_14B_2, arg_14B_3, r, Helpers.CenterSF);
					}
					flag = !this.Enabled;
					if (flag)
					{
						g.FillRectangle(new SolidBrush(color.FromArgb(54, 58, 61)), Base);
						Graphics arg_1C2_0 = g;
						string arg_1C2_1 = this.Text;
						Font arg_1C2_2 = this.Font;
						Brush arg_1C2_3 = new SolidBrush(color.FromArgb(140, 142, 143));
						r = new rectangle (20, 2, this.W, this.H);
						arg_1C2_0.DrawString(arg_1C2_1, arg_1C2_2, arg_1C2_3, r, Helpers.NearSF);
					}
					Graphics arg_204_0 = g;
					string arg_204_1 = this.Text;
					Font arg_204_2 = this.Font;
					Brush arg_204_3 = new SolidBrush(this._TextColor);
					r = new rectangle (20, 2, this.W, this.H);
					arg_204_0.DrawString(arg_204_1, arg_204_2, arg_204_3, r, Helpers.NearSF);
					break;
				}
				case FlatCheckBox._Options.Style2:
				{
					g.FillRectangle(new SolidBrush(this._BaseColor), Base);
					switch (this.State)
					{
					case MouseState.Over:
						g.DrawRectangle(new Pen(this._BorderColor), Base);
						g.FillRectangle(new SolidBrush(color.FromArgb(118, 213, 170)), Base);
						break;
					case MouseState.Down:
						g.DrawRectangle(new Pen(this._BorderColor), Base);
						g.FillRectangle(new SolidBrush(color.FromArgb(118, 213, 170)), Base);
						break;
					}
					bool flag = this.Checked;
					rectangle r;
					if (flag)
					{
						Graphics arg_2FA_0 = g;
						string arg_2FA_1 = "Ã¼";
						Font arg_2FA_2 = new Font("Wingdings", 18f);
						Brush arg_2FA_3 = new SolidBrush(this._BorderColor);
						r = new rectangle (5, 7, this.H - 9, this.H - 9);
						arg_2FA_0.DrawString(arg_2FA_1, arg_2FA_2, arg_2FA_3, r, Helpers.CenterSF);
					}
					flag = !this.Enabled;
					if (flag)
					{
						g.FillRectangle(new SolidBrush(color.FromArgb(54, 58, 61)), Base);
						Graphics arg_368_0 = g;
						string arg_368_1 = this.Text;
						Font arg_368_2 = this.Font;
						Brush arg_368_3 = new SolidBrush(color.FromArgb(48, 119, 91));
						r = new rectangle (20, 2, this.W, this.H);
						arg_368_0.DrawString(arg_368_1, arg_368_2, arg_368_3, r, Helpers.NearSF);
					}
					Graphics arg_3AA_0 = g;
					string arg_3AA_1 = this.Text;
					Font arg_3AA_2 = this.Font;
					Brush arg_3AA_3 = new SolidBrush(this._TextColor);
					r = new rectangle (20, 2, this.W, this.H);
					arg_3AA_0.DrawString(arg_3AA_1, arg_3AA_2, arg_3AA_3, r, Helpers.NearSF);
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
