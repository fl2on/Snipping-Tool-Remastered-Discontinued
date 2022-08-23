/*Original repository credits: https://github.com/michaelmob/Hyperdesktop2 by michaelmob
Based on HyperDesktop 2 as a continuation of the project, with a number of modifications. 
Fixed bugs and features from the original version.
The project was continued by (qzxtu) Nova#1735
*/
using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Snipping_Tool_Remastered.Class;

namespace Snipping_Tool_Remastered
{
	internal partial class frm_Edit : Form
	{
		List<Bitmap> undo;
		static Color pen_color = Color.Red;
		static Int16 pen_size = 5;
		Graphics g;
		Point point_1, point_2;
		Font font;
		Pen pen = new Pen(pen_color);
		SolidBrush brush = new SolidBrush(pen_color);
		Boolean using_pen = true;

		Dictionary<string, int> sizes = new Dictionary<string, int>();

		public Bitmap Result { set; get; }

		#region Invisible Form

		const uint WDA_MONITOR = 1;
		[DllImport("user32.dll")]
		public static extern uint SetWindowDisplayAffinity(IntPtr hWnd, uint dwAffinity);
		#endregion

		public frm_Edit(Bitmap _bmp, Font _font = null, Boolean _drop_shadow = false)
		{
			InitializeComponent();
			this.sizes.Add("Pixel", 1);
			this.sizes.Add("Small", 5);
			this.sizes.Add("Medium", 12);
			this.sizes.Add("Large", 24);
			this.sizes.Add("Huge", 32);
			this.sizes.Add("Massive", 64);
			foreach (KeyValuePair<string, int> pair in sizes)
				this.drop_size.Items.Add(pair.Key);
            this.undo = new List<Bitmap>
            {
                new Bitmap(_bmp)
            };
            font = _font ?? new Font("Arial", 16);
			this.check_drop_shadow.Checked = _drop_shadow;
		}

		private void Frm_EditLoad(object sender, EventArgs e)
		{
			this.picture_box.SizeMode = PictureBoxSizeMode.AutoSize;
			this.picture_box.Image = new Bitmap(undo[0]);
			this.drop_color.Text = "Red";
			this.drop_size.SelectedIndex = 1;
			this.drop_color.SelectedIndex = 1;
			SetWindowDisplayAffinity(this.Handle, WDA_MONITOR);
		}

		#region Controls
		private void Btn_okayClick(object sender, EventArgs e)
		{
			this.Result = new Bitmap(picture_box.Image);
			this.Close();
			this.picture_box.Image = null;
			this.undo.Clear();
		}

		private void Text_insertClick(object sender, EventArgs e)
		{
			if (this.text_insert.Text == "Insert Text")
				this.text_insert.Text = String.Empty;
		}

		private void Btn_penClick(object sender, EventArgs e) { this.using_pen = true; }
		void Btn_insertClick(object sender, EventArgs e)
		{
			this.using_pen = false;
			Drop_sizeSelectedIndexChanged(sender, e);
		}

		private void Drop_sizeSelectedIndexChanged(object sender, EventArgs e)
		{
			pen_size = Convert.ToInt16(sizes[drop_size.Text]);
			this.font = new Font("Arial", pen_size + 12);
		}

		private void Drop_colorSelectedIndexChanged(object sender, EventArgs e)
		{
			pen_color = Color.FromName(drop_color.Text);
			this.brush = new SolidBrush(pen_color);
		}
		#endregion

		#region Menu
		private void UndoToolStripMenuItemClick(object sender, EventArgs e)
		{
			try
			{
				this.picture_box.Image = new Bitmap(undo[undo.Count - 2]);
				this.undo.RemoveAt(undo.Count - 1);
				GC.Collect();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		private void ResetToolStripMenuItemClick(object sender, EventArgs e)
		{
			this.picture_box.Image = new Bitmap(undo[0]);
		}

		private void CopyToolStripMenuItemClick(object sender, System.EventArgs e)
		{
			Clipboard.SetImage(picture_box.Image);
		}

		private void Picture_boxMouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left)
				return;
			if (!using_pen)
			{
				this.g = Graphics.FromImage(picture_box.Image);
				if (check_drop_shadow.Checked)
			    this.g.DrawString(text_insert.Text, font, new SolidBrush(Color.Black), point_2.X + 1, point_2.Y + 1);
				this.g.DrawString(text_insert.Text, font, brush, point_2.X, point_2.Y);
			}
			this.point_1 = e.Location;
			this.pen = new Pen(pen_color, pen_size);
		}

		private void SaveAsToolStripMenuItemClick(object sender, System.EventArgs e)
		{
            var dialog = new SaveFileDialog
            {
                FileName = DateTime.Now.ToString("yyyy-MM-dd_HHmmss"),
                Filter = "PNG|*.png|JPG|*.jpg|BMP|*.bmp|All Files (*.*)|*.*"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
			{
				this.picture_box.Image.Save(
					dialog.FileName,
					Global_Func.ext_to_imageformat(Path.GetExtension(dialog.FileName).Substring(1))
				);
			}
		}
		#endregion

		#region Mouse Movements & Paint
		private void Picture_boxMouseMove(object sender, MouseEventArgs e)
		{
			point_2 = e.Location;
			picture_box.Invalidate();
			if (!(e.Button == MouseButtons.Left && using_pen))
				return;
			try
			{
				this.g = Graphics.FromImage(picture_box.Image);
				this.g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
				this.g.FillEllipse(
					new SolidBrush(pen_color),
					point_2.X - Convert.ToInt32(pen_size / 2),
					point_2.Y - Convert.ToInt32(pen_size / 2),
				    pen_size, pen_size
				);
				this.g.DrawLine(pen, point_1, point_2);
				this.point_1 = e.Location;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		private void Picture_boxMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			this.undo.Add(new Bitmap(picture_box.Image));
			if (undo.Count > 9)
				this.undo.RemoveAt(1);
			NovaAPI.gc();
		}

		private void Picture_boxPaint(object sender, PaintEventArgs e)
		{
			try
			{
				if (using_pen)
					e.Graphics.FillEllipse(
						new SolidBrush(pen_color),
						point_2.X - Convert.ToInt32(pen_size / 2),
						point_2.Y - Convert.ToInt32(pen_size / 2),
						pen_size, pen_size
					);
				else
				{
					if (check_drop_shadow.Checked)
						e.Graphics.DrawString(text_insert.Text, font, new SolidBrush(Color.Black), point_2.X + 1, point_2.Y + 1);
					e.Graphics.DrawString(text_insert.Text, font, brush, point_2.X, point_2.Y);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
        #endregion

        protected override bool ProcessCmdKey(ref Message msg, Keys key)
		{
			if (key == Keys.Escape)
				this.DialogResult = DialogResult.Cancel;
			return base.ProcessCmdKey(ref msg, key);
		}
	}
}
