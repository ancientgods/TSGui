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
	public class FlatTabControl : TabControl
	{
		private static List<WeakReference> __ENCList = new List<WeakReference>();
		private int W;
		private int H;
		private Color BGColor;
		private Color _BaseColor;
		private Color _ActiveColor;
		[Category("Colors")]
		public Color BaseColor
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
		public Color ActiveColor
		{
			get
			{
				return this._ActiveColor;
			}
			set
			{
				this._ActiveColor = value;
			}
		}
		[DebuggerNonUserCode]
		private static void __ENCAddToList(object value)
		{
			List<WeakReference> _ENCList = FlatTabControl.__ENCList;
			bool flag = false;
			checked
			{
				try
				{
					Monitor.Enter(_ENCList, ref flag);
					bool flag2 = FlatTabControl.__ENCList.Count == FlatTabControl.__ENCList.Capacity;
					if (flag2)
					{
						int num = 0;
						int arg_44_0 = 0;
						int num2 = FlatTabControl.__ENCList.Count - 1;
						int num3 = arg_44_0;
						while (true)
						{
							int arg_95_0 = num3;
							int num4 = num2;
							if (arg_95_0 > num4)
							{
								break;
							}
							WeakReference weakReference = FlatTabControl.__ENCList[num3];
							flag2 = weakReference.IsAlive;
							if (flag2)
							{
								bool flag3 = num3 != num;
								if (flag3)
								{
									FlatTabControl.__ENCList[num] = FlatTabControl.__ENCList[num3];
								}
								num++;
							}
							num3++;
						}
						FlatTabControl.__ENCList.RemoveRange(num, FlatTabControl.__ENCList.Count - num);
						FlatTabControl.__ENCList.Capacity = FlatTabControl.__ENCList.Count;
					}
					FlatTabControl.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
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
			this.Alignment = TabAlignment.Top;
		}
		public FlatTabControl()
		{
			FlatTabControl.__ENCAddToList(this);
			this.BGColor = Color.FromArgb(60, 70, 73);
			this._BaseColor = Color.FromArgb(45, 47, 49);
			this._ActiveColor = Helpers._FlatColor;
			this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.BackColor = Color.FromArgb(60, 70, 73);
			this.Font = new Font("Segoe UI", 10f);
			this.SizeMode = TabSizeMode.Fixed;
			Size itemSize = new Size(120, 40);
			this.ItemSize = itemSize;
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			Helpers.B = new Bitmap(this.Width, this.Height);
			Helpers.G = Graphics.FromImage(Helpers.B);
			checked
			{
				this.W = this.Width - 1;
				this.H = this.Height - 1;
				Graphics graphics = Helpers.G;
				graphics.SmoothingMode = SmoothingMode.HighQuality;
				graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
				graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				graphics.Clear(this._BaseColor);
				try
				{
					this.SelectedTab.BackColor = this.BGColor;
				}
				catch (Exception arg_87_0)
				{
					ProjectData.SetProjectError(arg_87_0);
					ProjectData.ClearProjectError();
				}
				int arg_A0_0 = 0;
				int num = this.TabCount - 1;
				int i = arg_A0_0;
				while (true)
				{
					int arg_4A5_0 = i;
					int num2 = num;
					if (arg_4A5_0 > num2)
					{
						break;
					}
					Point location = this.GetTabRect(i).Location;
					Point location2 = new Point(location.X + 2, this.GetTabRect(i).Location.Y);
					Point arg_110_1 = location2;
					Size size = new Size(this.GetTabRect(i).Width, this.GetTabRect(i).Height);
					Rectangle Base = new Rectangle(arg_110_1, size);
					Point arg_137_1 = Base.Location;
					size = new Size(Base.Width, Base.Height);
					Rectangle BaseSize = new Rectangle(arg_137_1, size);
					bool flag = i == this.SelectedIndex;
					if (flag)
					{
						graphics.FillRectangle(new SolidBrush(this._BaseColor), BaseSize);
						graphics.FillRectangle(new SolidBrush(this._ActiveColor), BaseSize);
						flag = (this.ImageList != null);
						if (flag)
						{
							try
							{
								bool flag2 = this.ImageList.Images[this.TabPages[i].ImageIndex] != null;
								if (flag2)
								{
									Graphics arg_20E_0 = graphics;
									Image arg_20E_1 = this.ImageList.Images[this.TabPages[i].ImageIndex];
									location2 = BaseSize.Location;
									location = new Point(location2.X + 8, BaseSize.Location.Y + 6);
									arg_20E_0.DrawImage(arg_20E_1, location);
									graphics.DrawString("      " + this.TabPages[i].Text, this.Font, Brushes.White, BaseSize, Helpers.CenterSF);
								}
								else
								{
									graphics.DrawString(this.TabPages[i].Text, this.Font, Brushes.White, BaseSize, Helpers.CenterSF);
								}
							}
							catch (Exception expr_282)
							{
								ProjectData.SetProjectError(expr_282);
								Exception ex = expr_282;
								throw new Exception(ex.Message);
							}
						}
						else
						{
							graphics.DrawString(this.TabPages[i].Text, this.Font, Brushes.White, BaseSize, Helpers.CenterSF);
						}
					}
					else
					{
						graphics.FillRectangle(new SolidBrush(this._BaseColor), BaseSize);
						bool flag2 = this.ImageList != null;
						if (flag2)
						{
							try
							{
								flag = (this.ImageList.Images[this.TabPages[i].ImageIndex] != null);
								if (flag)
								{
									Graphics arg_382_0 = graphics;
									Image arg_382_1 = this.ImageList.Images[this.TabPages[i].ImageIndex];
									location2 = BaseSize.Location;
									location = new Point(location2.X + 8, BaseSize.Location.Y + 6);
									arg_382_0.DrawImage(arg_382_1, location);
									graphics.DrawString("      " + this.TabPages[i].Text, this.Font, new SolidBrush(Color.White), BaseSize, new StringFormat
									{
										LineAlignment = StringAlignment.Center,
										Alignment = StringAlignment.Center
									});
								}
								else
								{
									graphics.DrawString(this.TabPages[i].Text, this.Font, new SolidBrush(Color.White), BaseSize, new StringFormat
									{
										LineAlignment = StringAlignment.Center,
										Alignment = StringAlignment.Center
									});
								}
							}
							catch (Exception expr_42C)
							{
								ProjectData.SetProjectError(expr_42C);
								Exception ex2 = expr_42C;
								throw new Exception(ex2.Message);
							}
						}
						else
						{
							graphics.DrawString(this.TabPages[i].Text, this.Font, new SolidBrush(Color.White), BaseSize, new StringFormat
							{
								LineAlignment = StringAlignment.Center,
								Alignment = StringAlignment.Center
							});
						}
					}
					i++;
				}
				graphics = null;
				base.OnPaint(e);
				Helpers.G.Dispose();
				e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
				Helpers.B.Dispose();
			}
		}
	}
}
