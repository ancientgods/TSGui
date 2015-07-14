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
	public class FormSkin : ContainerControl
	{
		private static List<WeakReference> __ENCList = new List<WeakReference>();
		private int W;
		private int H;
		private bool Cap;
		private bool _HeaderMaximize;
		private point MousePoint;
		private object MoveHeight;
		private color  _HeaderColor;
		private color  _BaseColor;
		private color  _BorderColor;
		private color  TextColor;
		private color  _HeaderLight;
		private color  _BaseLight;
		public color  TextLight;
		[Category("Colors")]
		public color  HeaderColor
		{
			get
			{
				return this._HeaderColor;
			}
			set
			{
				this._HeaderColor = value;
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
		public color  BorderColor
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
		[Category("Colors")]
		public color  FlatColor
		{
			get
			{
				return Helpers._FlatColor;
			}
			set
			{
				Helpers._FlatColor = value;
			}
		}
		[Category("Options")]
		public bool HeaderMaximize
		{
			get
			{
				return this._HeaderMaximize;
			}
			set
			{
				this._HeaderMaximize = value;
			}
		}
		[DebuggerNonUserCode]
		private static void __ENCAddToList(object value)
		{
			List<WeakReference> _ENCList = FormSkin.__ENCList;
			bool flag = false;
			checked
			{
				try
				{
					Monitor.Enter(_ENCList, ref flag);
					bool flag2 = FormSkin.__ENCList.Count == FormSkin.__ENCList.Capacity;
					if (flag2)
					{
						int num = 0;
						int arg_44_0 = 0;
						int num2 = FormSkin.__ENCList.Count - 1;
						int num3 = arg_44_0;
						while (true)
						{
							int arg_95_0 = num3;
							int num4 = num2;
							if (arg_95_0 > num4)
							{
								break;
							}
							WeakReference weakReference = FormSkin.__ENCList[num3];
							flag2 = weakReference.IsAlive;
							if (flag2)
							{
								bool flag3 = num3 != num;
								if (flag3)
								{
									FormSkin.__ENCList[num] = FormSkin.__ENCList[num3];
								}
								num++;
							}
							num3++;
						}
						FormSkin.__ENCList.RemoveRange(num, FormSkin.__ENCList.Count - num);
						FormSkin.__ENCList.Capacity = FormSkin.__ENCList.Count;
					}
					FormSkin.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
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
			bool arg_40_0 = e.Button == MouseButtons.Left;
			rectangle rectangle = new rectangle(0, 0, this.Width, Conversions.ToInteger(this.MoveHeight));
			rectangle rectangle2 = rectangle;
			bool flag = arg_40_0 & rectangle2.Contains(e.Location);
			if (flag)
			{
				this.Cap = true;
				this.MousePoint = e.Location;
			}
		}
		private void FormSkin_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			bool headerMaximize = this.HeaderMaximize;
			if (headerMaximize)
			{
				bool arg_45_0 = e.Button == MouseButtons.Left;
				rectangle rectangle = new rectangle(0, 0, this.Width, Conversions.ToInteger(this.MoveHeight));
				rectangle rectangle2 = rectangle;
				bool flag = arg_45_0 & rectangle2.Contains(e.Location);
				if (flag)
				{
					bool flag2 = this.FindForm().WindowState == FormWindowState.Normal;
					if (flag2)
					{
						this.FindForm().WindowState = FormWindowState.Maximized;
						this.FindForm().Refresh();
					}
					else
					{
						flag2 = (this.FindForm().WindowState == FormWindowState.Maximized);
						if (flag2)
						{
							this.FindForm().WindowState = FormWindowState.Normal;
							this.FindForm().Refresh();
						}
					}
				}
			}
		}
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.Cap = false;
		}
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			bool cap = this.Cap;
			if (cap)
			{
				this.Parent.Location = Control.MousePosition - (Size)this.MousePoint;
			}
		}
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			this.ParentForm.FormBorderStyle = FormBorderStyle.None;
			this.ParentForm.AllowTransparency = false;
			this.ParentForm.TransparencyKey = color .Fuchsia;
			this.ParentForm.FindForm().StartPosition = FormStartPosition.CenterScreen;
			this.Dock = DockStyle.Fill;
			this.Invalidate();
		}
		public FormSkin()
		{
			base.MouseDoubleClick += new MouseEventHandler(this.FormSkin_MouseDoubleClick);
			FormSkin.__ENCAddToList(this);
			this.Cap = false;
			this._HeaderMaximize = false;
			this.MousePoint = new point(0, 0);
			this.MoveHeight = 50;
			this._HeaderColor = color .FromArgb(45, 47, 49);
			this._BaseColor = color .FromArgb(60, 70, 73);
			this._BorderColor = color .FromArgb(53, 58, 60);
			this.TextColor = color .FromArgb(234, 234, 234);
			this._HeaderLight = color .FromArgb(171, 171, 172);
			this._BaseLight = color .FromArgb(196, 199, 200);
			this.TextLight = color .FromArgb(45, 47, 49);
			this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.BackColor = color .White;
			this.Font = new Font("Segoe UI", 12f);
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			Helpers.B = new Bitmap(this.Width, this.Height);
			Helpers.G = Graphics.FromImage(Helpers.B);
			this.W = this.Width;
			this.H = this.Height;
			rectangle Base = new rectangle(0, 0, this.W, this.H);
			rectangle Header = new rectangle(0, 0, this.W, 50);
			Graphics g = Helpers.G;
			g.SmoothingMode = SmoothingMode.HighQuality;
			g.PixelOffsetMode = PixelOffsetMode.HighQuality;
			g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			g.Clear(this.BackColor);
			g.FillRectangle(new SolidBrush(this._BaseColor), Base);
			g.FillRectangle(new SolidBrush(this._HeaderColor), Header);
			Graphics arg_E0_0 = g;
			Brush arg_E0_1 = new SolidBrush(color.FromArgb(243, 243, 243));
			rectangle rectangle = new rectangle(8, 16, 4, 18);
			arg_E0_0.FillRectangle(arg_E0_1, rectangle);
			g.FillRectangle(new SolidBrush(Helpers._FlatColor), 16, 16, 4, 18);
			Graphics arg_139_0 = g;
			string arg_139_1 = this.Text;
			Font arg_139_2 = this.Font;
			Brush arg_139_3 = new SolidBrush(this.TextColor);
			rectangle = new rectangle(26, 15, this.W, this.H);
			arg_139_0.DrawString(arg_139_1, arg_139_2, arg_139_3, rectangle, Helpers.NearSF);
			g.DrawRectangle(new Pen(this._BorderColor), Base);
			base.OnPaint(e);
			Helpers.G.Dispose();
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
			Helpers.B.Dispose();
		}
	}
}
