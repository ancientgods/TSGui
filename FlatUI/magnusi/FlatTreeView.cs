using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
namespace magnusi
{
	public class FlatTreeView : TreeView
	{
		private static List<WeakReference> __ENCList = new List<WeakReference>();
		private TreeNodeStates State;
		private Color _BaseColor;
		private Color _LineColor;
		[DebuggerNonUserCode]
		private static void __ENCAddToList(object value)
		{
			List<WeakReference> _ENCList = FlatTreeView.__ENCList;
			bool flag = false;
			checked
			{
				try
				{
					Monitor.Enter(_ENCList, ref flag);
					bool flag2 = FlatTreeView.__ENCList.Count == FlatTreeView.__ENCList.Capacity;
					if (flag2)
					{
						int num = 0;
						int arg_44_0 = 0;
						int num2 = FlatTreeView.__ENCList.Count - 1;
						int num3 = arg_44_0;
						while (true)
						{
							int arg_95_0 = num3;
							int num4 = num2;
							if (arg_95_0 > num4)
							{
								break;
							}
							WeakReference weakReference = FlatTreeView.__ENCList[num3];
							flag2 = weakReference.IsAlive;
							if (flag2)
							{
								bool flag3 = num3 != num;
								if (flag3)
								{
									FlatTreeView.__ENCList[num] = FlatTreeView.__ENCList[num3];
								}
								num++;
							}
							num3++;
						}
						FlatTreeView.__ENCList.RemoveRange(num, FlatTreeView.__ENCList.Count - num);
						FlatTreeView.__ENCList.Capacity = FlatTreeView.__ENCList.Count;
					}
					FlatTreeView.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
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
		protected override void OnDrawNode(DrawTreeNodeEventArgs e)
		{
			checked
			{
				try
				{
					int arg_50_1 = e.Bounds.Location.X;
					int arg_50_2 = e.Bounds.Location.Y;
					int arg_50_3 = e.Bounds.Width;
					Rectangle bounds = e.Bounds;
					Rectangle Bounds = new Rectangle(arg_50_1, arg_50_2, arg_50_3, bounds.Height);
					TreeNodeStates state = this.State;
					bool flag = state == TreeNodeStates.Default;
					if (flag)
					{
						e.Graphics.FillRectangle(Brushes.Red, Bounds);
						Graphics arg_D7_0 = e.Graphics;
						string arg_D7_1 = e.Node.Text;
						Font arg_D7_2 = new Font("Segoe UI", 8f);
						Brush arg_D7_3 = Brushes.LimeGreen;
						bounds = new Rectangle(Bounds.X + 2, Bounds.Y + 2, Bounds.Width, Bounds.Height);
						arg_D7_0.DrawString(arg_D7_1, arg_D7_2, arg_D7_3, bounds, Helpers.NearSF);
						this.Invalidate();
					}
					else
					{
						flag = (state == TreeNodeStates.Checked);
						if (flag)
						{
							e.Graphics.FillRectangle(Brushes.Green, Bounds);
							Graphics arg_160_0 = e.Graphics;
							string arg_160_1 = e.Node.Text;
							Font arg_160_2 = new Font("Segoe UI", 8f);
							Brush arg_160_3 = Brushes.Black;
							bounds = new Rectangle(Bounds.X + 2, Bounds.Y + 2, Bounds.Width, Bounds.Height);
							arg_160_0.DrawString(arg_160_1, arg_160_2, arg_160_3, bounds, Helpers.NearSF);
							this.Invalidate();
						}
						else
						{
							flag = (state == TreeNodeStates.Selected);
							if (flag)
							{
								e.Graphics.FillRectangle(Brushes.Green, Bounds);
								Graphics arg_1E9_0 = e.Graphics;
								string arg_1E9_1 = e.Node.Text;
								Font arg_1E9_2 = new Font("Segoe UI", 8f);
								Brush arg_1E9_3 = Brushes.Black;
								bounds = new Rectangle(Bounds.X + 2, Bounds.Y + 2, Bounds.Width, Bounds.Height);
								arg_1E9_0.DrawString(arg_1E9_1, arg_1E9_2, arg_1E9_3, bounds, Helpers.NearSF);
								this.Invalidate();
							}
						}
					}
				}
				catch (Exception expr_1F9)
				{
					ProjectData.SetProjectError(expr_1F9);
					Exception ex = expr_1F9;
					Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, null);
					ProjectData.ClearProjectError();
				}
				base.OnDrawNode(e);
			}
		}
		public FlatTreeView()
		{
			FlatTreeView.__ENCAddToList(this);
			this._BaseColor = Color.FromArgb(45, 47, 49);
			this._LineColor = Color.FromArgb(25, 27, 29);
			this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.BackColor = this._BaseColor;
			this.ForeColor = Color.White;
			this.LineColor = this._LineColor;
			this.DrawMode = TreeViewDrawMode.OwnerDrawAll;
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			Helpers.B = new Bitmap(this.Width, this.Height);
			Helpers.G = Graphics.FromImage(Helpers.B);
			Rectangle Base = new Rectangle(0, 0, this.Width, this.Height);
			Graphics g = Helpers.G;
			g.SmoothingMode = SmoothingMode.HighQuality;
			g.PixelOffsetMode = PixelOffsetMode.HighQuality;
			g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			g.Clear(this.BackColor);
			g.FillRectangle(new SolidBrush(this._BaseColor), Base);
			Graphics arg_E7_0 = g;
			string arg_E7_1 = this.Text;
			Font arg_E7_2 = new Font("Segoe UI", 8f);
			Brush arg_E7_3 = Brushes.Black;
			Rectangle r = checked(new Rectangle(this.Bounds.X + 2, this.Bounds.Y + 2, this.Bounds.Width, this.Bounds.Height));
			arg_E7_0.DrawString(arg_E7_1, arg_E7_2, arg_E7_3, r, Helpers.NearSF);
			base.OnPaint(e);
			Helpers.G.Dispose();
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
			Helpers.B.Dispose();
		}
	}
}
