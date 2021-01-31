
namespace FileSender
{
	partial class Form1
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.panel1 = new System.Windows.Forms.Panel();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.AllowDrop = true;
			this.panel1.AutoScroll = true;
			this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(6, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(433, 160);
			this.panel1.TabIndex = 0;
			this.panel1.DragDrop += new System.Windows.Forms.DragEventHandler(this.panel1_DragDrop);
			this.panel1.DragEnter += new System.Windows.Forms.DragEventHandler(this.panel1_DragEnter);
			this.panel1.DragLeave += new System.EventHandler(this.panel1_DragLeave);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(6, 296);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(128, 46);
			this.button1.TabIndex = 1;
			this.button1.Text = "Открыть файл";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(6, 360);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(128, 46);
			this.button2.TabIndex = 2;
			this.button2.Text = "Отправить файлы";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(-2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(433, 156);
			this.label1.TabIndex = 0;
			this.label1.Text = "Перетащите файлы сюда";
			// 
			// Form1
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(443, 450);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.panel1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label1;
	}
}

