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
	[DefaultEvent("CheckedChanged")]
	public class FlatToggle : Control
	{
		public delegate void CheckedChangedEventHandler(object sender);
		[Flags]
		public enum _Options
		{
			Style1 = 0,
			Style2 = 1,
			Style3 = 2,
			Style4 = 3,
			Style5 = 4
		}
		private static List<WeakReference> __ENCList = new List<WeakReference>();
		private int W;
		private int H;
		private FlatToggle._Options O;
		private bool _Checked;
		private MouseState State;
		private FlatToggle.CheckedChangedEventHandler CheckedChangedEvent;
		private Color BaseColor;
		private Color BaseColorRed;
		private Color BGColor;
		private Color ToggleColor;
		private Color TextColor;
		public event FlatToggle.CheckedChangedEventHandler CheckedChanged
		{
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.CheckedChangedEvent = (FlatToggle.CheckedChangedEventHandler)Delegate.Combine(this.CheckedChangedEvent, value);
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.CheckedChangedEvent = (FlatToggle.CheckedChangedEventHandler)Delegate.Remove(this.CheckedChangedEvent, value);
			}
		}
		[Category("Options")]
		public FlatToggle._Options Options
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
		[Category("Options")]
		public bool Checked
		{
			get
			{
				return this._Checked;
			}
			set
			{
				this._Checked = value;
			}
		}
		[DebuggerNonUserCode]
		private static void __ENCAddToList(object value)
		{
			List<WeakReference> _ENCList = FlatToggle.__ENCList;
			bool flag = false;
			checked
			{
				try
				{
					Monitor.Enter(_ENCList, ref flag);
					bool flag2 = FlatToggle.__ENCList.Count == FlatToggle.__ENCList.Capacity;
					if (flag2)
					{
						int num = 0;
						int arg_44_0 = 0;
						int num2 = FlatToggle.__ENCList.Count - 1;
						int num3 = arg_44_0;
						while (true)
						{
							int arg_95_0 = num3;
							int num4 = num2;
							if (arg_95_0 > num4)
							{
								break;
							}
							WeakReference weakReference = FlatToggle.__ENCList[num3];
							flag2 = weakReference.IsAlive;
							if (flag2)
							{
								bool flag3 = num3 != num;
								if (flag3)
								{
									FlatToggle.__ENCList[num] = FlatToggle.__ENCList[num3];
								}
								num++;
							}
							num3++;
						}
						FlatToggle.__ENCList.RemoveRange(num, FlatToggle.__ENCList.Count - num);
						FlatToggle.__ENCList.Capacity = FlatToggle.__ENCList.Count;
					}
					FlatToggle.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
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
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			this.Width = 76;
			this.Height = 33;
		}
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			this.State = MouseState.Over;
			this.Invalidate();
		}
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			this.State = MouseState.Down;
			this.Invalidate();
		}
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.State = MouseState.None;
			this.Invalidate();
		}
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.State = MouseState.Over;
			this.Invalidate();
		}
		protected override void OnClick(EventArgs e)
		{
			base.OnClick(e);
			this._Checked = !this._Checked;
			FlatToggle.CheckedChangedEventHandler checkedChangedEvent = this.CheckedChangedEvent;
			bool flag = checkedChangedEvent != null;
			if (flag)
			{
				checkedChangedEvent(this);
			}
		}
		public FlatToggle()
		{
			FlatToggle.__ENCAddToList(this);
			this._Checked = false;
			this.State = MouseState.None;
			this.BaseColor = Helpers._FlatColor;
			this.BaseColorRed = Color.FromArgb(220, 85, 96);
			this.BGColor = Color.FromArgb(84, 85, 86);
			this.ToggleColor = Color.FromArgb(45, 47, 49);
			this.TextColor = Color.FromArgb(243, 243, 243);
			this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.BackColor = Color.Transparent;
			Size size = new Size(44, checked(this.Height + 1));
			this.Size = size;
			this.Cursor = Cursors.Hand;
			this.Font = new Font("Segoe UI", 10f);
			size = new Size(76, 33);
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
				GraphicsPath GP = new GraphicsPath();
				GraphicsPath GP2 = new GraphicsPath();
				Rectangle Base = new Rectangle(0, 0, this.W, this.H);
				Rectangle Toggle = new Rectangle(this.W / 2, 0, 38, this.H);
				Graphics g = Helpers.G;
				g.SmoothingMode = SmoothingMode.HighQuality;
				g.PixelOffsetMode = PixelOffsetMode.HighQuality;
				g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				g.Clear(this.BackColor);
				switch (this.O)
				{
				case FlatToggle._Options.Style1:
				{
					GP = Helpers.RoundRec(Base, 6);
					GP2 = Helpers.RoundRec(Toggle, 6);
					g.FillPath(new SolidBrush(this.BGColor), GP);
					g.FillPath(new SolidBrush(this.ToggleColor), GP2);
					Graphics arg_14A_0 = g;
					string arg_14A_1 = "OFF";
					Font arg_14A_2 = this.Font;
					Brush arg_14A_3 = new SolidBrush(this.BGColor);
					Rectangle rectangle = new Rectangle(19, 1, this.W, this.H);
					arg_14A_0.DrawString(arg_14A_1, arg_14A_2, arg_14A_3, rectangle, Helpers.CenterSF);
					bool @checked = this.Checked;
					if (@checked)
					{
						GP = Helpers.RoundRec(Base, 6);
						rectangle = new Rectangle(this.W / 2, 0, 38, this.H);
						GP2 = Helpers.RoundRec(rectangle, 6);
						g.FillPath(new SolidBrush(this.ToggleColor), GP);
						g.FillPath(new SolidBrush(this.BaseColor), GP2);
						Graphics arg_1EB_0 = g;
						string arg_1EB_1 = "ON";
						Font arg_1EB_2 = this.Font;
						Brush arg_1EB_3 = new SolidBrush(this.BaseColor);
						rectangle = new Rectangle(8, 7, this.W, this.H);
						arg_1EB_0.DrawString(arg_1EB_1, arg_1EB_2, arg_1EB_3, rectangle, Helpers.NearSF);
					}
					break;
				}
				case FlatToggle._Options.Style2:
				{
					GP = Helpers.RoundRec(Base, 6);
					Toggle = new Rectangle(4, 4, 36, this.H - 8);
					GP2 = Helpers.RoundRec(Toggle, 4);
					g.FillPath(new SolidBrush(this.BaseColorRed), GP);
					g.FillPath(new SolidBrush(this.ToggleColor), GP2);
					g.DrawLine(new Pen(this.BGColor), 18, 20, 18, 12);
					g.DrawLine(new Pen(this.BGColor), 22, 20, 22, 12);
					g.DrawLine(new Pen(this.BGColor), 26, 20, 26, 12);
					Graphics arg_2D9_0 = g;
					string arg_2D9_1 = "r";
					Font arg_2D9_2 = new Font("Marlett", 8f);
					Brush arg_2D9_3 = new SolidBrush(this.TextColor);
					Rectangle rectangle = new Rectangle(19, 2, this.Width, this.Height);
					arg_2D9_0.DrawString(arg_2D9_1, arg_2D9_2, arg_2D9_3, rectangle, Helpers.CenterSF);
					bool @checked = this.Checked;
					if (@checked)
					{
						GP = Helpers.RoundRec(Base, 6);
						Toggle = new Rectangle(this.W / 2 - 2, 4, 36, this.H - 8);
						GP2 = Helpers.RoundRec(Toggle, 4);
						g.FillPath(new SolidBrush(this.BaseColor), GP);
						g.FillPath(new SolidBrush(this.ToggleColor), GP2);
						g.DrawLine(new Pen(this.BGColor), this.W / 2 + 12, 20, this.W / 2 + 12, 12);
						g.DrawLine(new Pen(this.BGColor), this.W / 2 + 16, 20, this.W / 2 + 16, 12);
						g.DrawLine(new Pen(this.BGColor), this.W / 2 + 20, 20, this.W / 2 + 20, 12);
						Graphics arg_40D_0 = g;
						string arg_40D_1 = "Ã¼";
						Font arg_40D_2 = new Font("Wingdings", 14f);
						Brush arg_40D_3 = new SolidBrush(this.TextColor);
						rectangle = new Rectangle(8, 7, this.Width, this.Height);
						arg_40D_0.DrawString(arg_40D_1, arg_40D_2, arg_40D_3, rectangle, Helpers.NearSF);
					}
					break;
				}
				case FlatToggle._Options.Style3:
				{
					GP = Helpers.RoundRec(Base, 16);
					Toggle = new Rectangle(this.W - 28, 4, 22, this.H - 8);
					GP2.AddEllipse(Toggle);
					g.FillPath(new SolidBrush(this.ToggleColor), GP);
					g.FillPath(new SolidBrush(this.BaseColorRed), GP2);
					Graphics arg_4AA_0 = g;
					string arg_4AA_1 = "OFF";
					Font arg_4AA_2 = this.Font;
					Brush arg_4AA_3 = new SolidBrush(this.BaseColorRed);
					Rectangle rectangle = new Rectangle(-12, 2, this.W, this.H);
					arg_4AA_0.DrawString(arg_4AA_1, arg_4AA_2, arg_4AA_3, rectangle, Helpers.CenterSF);
					bool @checked = this.Checked;
					if (@checked)
					{
						GP = Helpers.RoundRec(Base, 16);
						Toggle = new Rectangle(6, 4, 22, this.H - 8);
						GP2.Reset();
						GP2.AddEllipse(Toggle);
						g.FillPath(new SolidBrush(this.ToggleColor), GP);
						g.FillPath(new SolidBrush(this.BaseColor), GP2);
						Graphics arg_54E_0 = g;
						string arg_54E_1 = "ON";
						Font arg_54E_2 = this.Font;
						Brush arg_54E_3 = new SolidBrush(this.BaseColor);
						rectangle = new Rectangle(12, 2, this.W, this.H);
						arg_54E_0.DrawString(arg_54E_1, arg_54E_2, arg_54E_3, rectangle, Helpers.CenterSF);
					}
					break;
				}
				case FlatToggle._Options.Style4:
				{
					bool @checked = this.Checked;
					if (@checked)
					{
					}
					break;
				}
				case FlatToggle._Options.Style5:
				{
					bool @checked = this.Checked;
					if (@checked)
					{
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
}
