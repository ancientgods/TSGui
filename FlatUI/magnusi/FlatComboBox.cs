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
	public class FlatComboBox : ComboBox
	{
		private static List<WeakReference> __ENCList = new List<WeakReference>();
		private int W;
		private int H;
		private int _StartIndex;
		private int x;
		private int y;
		private MouseState State;
		private Color _BaseColor;
		private Color _BGColor;
		private Color _HoverColor;
		[Category("Colors")]
		public Color HoverColor
		{
			get
			{
				return this._HoverColor;
			}
			set
			{
				this._HoverColor = value;
			}
		}
		private int StartIndex
		{
			get
			{
				return this._StartIndex;
			}
			set
			{
				this._StartIndex = value;
				try
				{
					base.SelectedIndex = value;
				}
				catch (Exception arg_13_0)
				{
					ProjectData.SetProjectError(arg_13_0);
					ProjectData.ClearProjectError();
				}
				this.Invalidate();
			}
		}
		[DebuggerNonUserCode]
		private static void __ENCAddToList(object value)
		{
			List<WeakReference> _ENCList = FlatComboBox.__ENCList;
			bool flag = false;
			checked
			{
				try
				{
					Monitor.Enter(_ENCList, ref flag);
					bool flag2 = FlatComboBox.__ENCList.Count == FlatComboBox.__ENCList.Capacity;
					if (flag2)
					{
						int num = 0;
						int arg_44_0 = 0;
						int num2 = FlatComboBox.__ENCList.Count - 1;
						int num3 = arg_44_0;
						while (true)
						{
							int arg_95_0 = num3;
							int num4 = num2;
							if (arg_95_0 > num4)
							{
								break;
							}
							WeakReference weakReference = FlatComboBox.__ENCList[num3];
							flag2 = weakReference.IsAlive;
							if (flag2)
							{
								bool flag3 = num3 != num;
								if (flag3)
								{
									FlatComboBox.__ENCList[num] = FlatComboBox.__ENCList[num3];
								}
								num++;
							}
							num3++;
						}
						FlatComboBox.__ENCList.RemoveRange(num, FlatComboBox.__ENCList.Count - num);
						FlatComboBox.__ENCList.Capacity = FlatComboBox.__ENCList.Count;
					}
					FlatComboBox.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
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
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			this.x = e.Location.X;
			this.y = e.Location.Y;
			this.Invalidate();
			bool flag = e.X < checked(this.Width - 41);
			if (flag)
			{
				this.Cursor = Cursors.IBeam;
			}
			else
			{
				this.Cursor = Cursors.Hand;
			}
		}
		protected override void OnDrawItem(DrawItemEventArgs e)
		{
			base.OnDrawItem(e);
			this.Invalidate();
			bool flag = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
			if (flag)
			{
				this.Invalidate();
			}
		}
		protected override void OnClick(EventArgs e)
		{
			base.OnClick(e);
			this.Invalidate();
		}
		public void DrawItem_(object sender, DrawItemEventArgs e)
		{
			bool flag = e.Index < 0;
			if (!flag)
			{
				e.DrawBackground();
				e.DrawFocusRectangle();
				e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
				e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
				e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				flag = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);
				if (flag)
				{
					e.Graphics.FillRectangle(new SolidBrush(this._HoverColor), e.Bounds);
				}
				else
				{
					e.Graphics.FillRectangle(new SolidBrush(this._BaseColor), e.Bounds);
				}
				Graphics arg_128_0 = e.Graphics;
				string arg_128_1 = base.GetItemText(RuntimeHelpers.GetObjectValue(base.Items[e.Index]));
				Font arg_128_2 = new Font("Segoe UI", 8f);
				Brush arg_128_3 = Brushes.White;
				Rectangle r = checked(new Rectangle(e.Bounds.X + 2, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height));
				arg_128_0.DrawString(arg_128_1, arg_128_2, arg_128_3, r);
				e.Graphics.Dispose();
			}
		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			this.Height = 18;
		}
		public FlatComboBox()
		{
			base.DrawItem += new DrawItemEventHandler(this.DrawItem_);
			FlatComboBox.__ENCAddToList(this);
			this._StartIndex = 0;
			this.State = MouseState.None;
			this._BaseColor = Color.FromArgb(25, 27, 29);
			this._BGColor = Color.FromArgb(45, 47, 49);
			this._HoverColor = Color.FromArgb(35, 168, 109);
			this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.DrawMode = DrawMode.OwnerDrawFixed;
			this.BackColor = Color.FromArgb(45, 45, 48);
			this.ForeColor = Color.White;
			this.DropDownStyle = ComboBoxStyle.DropDownList;
			this.Cursor = Cursors.Hand;
			this.StartIndex = 0;
			this.ItemHeight = 18;
			this.Font = new Font("Segoe UI", 8f, FontStyle.Regular);
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			Helpers.B = new Bitmap(this.Width, this.Height);
			Helpers.G = Graphics.FromImage(Helpers.B);
			this.W = this.Width;
			this.H = this.Height;
			Rectangle Base = new Rectangle(0, 0, this.W, this.H);
			checked
			{
				Rectangle Button = new Rectangle(this.W - 40, 0, this.W, this.H);
				GraphicsPath GP = new GraphicsPath();
				GraphicsPath GP2 = new GraphicsPath();
				Graphics g = Helpers.G;
				g.Clear(Color.FromArgb(45, 45, 48));
				g.SmoothingMode = SmoothingMode.HighQuality;
				g.PixelOffsetMode = PixelOffsetMode.HighQuality;
				g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				g.FillRectangle(new SolidBrush(this._BGColor), Base);
				GP.Reset();
				GP.AddRectangle(Button);
				g.SetClip(GP);
				g.FillRectangle(new SolidBrush(this._BaseColor), Button);
				g.ResetClip();
				g.DrawLine(Pens.White, this.W - 10, 6, this.W - 30, 6);
				g.DrawLine(Pens.White, this.W - 10, 12, this.W - 30, 12);
				g.DrawLine(Pens.White, this.W - 10, 18, this.W - 30, 18);
				Graphics arg_18B_0 = g;
				string arg_18B_1 = this.Text;
				Font arg_18B_2 = this.Font;
				Brush arg_18B_3 = Brushes.White;
				Point p = new Point(4, 6);
				arg_18B_0.DrawString(arg_18B_1, arg_18B_2, arg_18B_3, p, Helpers.NearSF);
				Helpers.G.Dispose();
				e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
				Helpers.B.Dispose();
			}
		}
	}
}
