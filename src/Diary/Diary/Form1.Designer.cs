namespace Diary
{
	partial class Form1
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.BtnCreateDiay = new System.Windows.Forms.Button();
			this.LblYear = new System.Windows.Forms.Label();
			this.TbYear = new System.Windows.Forms.TextBox();
			this.BtnPlan = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// BtnCreateDiay
			// 
			this.BtnCreateDiay.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.BtnCreateDiay.Location = new System.Drawing.Point(402, 60);
			this.BtnCreateDiay.Name = "BtnCreateDiay";
			this.BtnCreateDiay.Size = new System.Drawing.Size(155, 37);
			this.BtnCreateDiay.TabIndex = 0;
			this.BtnCreateDiay.Text = "创建日志";
			this.BtnCreateDiay.UseVisualStyleBackColor = true;
			this.BtnCreateDiay.Click += new System.EventHandler(this.BtnCreateDiay_Click);
			// 
			// LblYear
			// 
			this.LblYear.AutoSize = true;
			this.LblYear.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.LblYear.Location = new System.Drawing.Point(36, 81);
			this.LblYear.Name = "LblYear";
			this.LblYear.Size = new System.Drawing.Size(88, 16);
			this.LblYear.TabIndex = 1;
			this.LblYear.Text = "输入年份：";
			// 
			// TbYear
			// 
			this.TbYear.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.TbYear.Location = new System.Drawing.Point(150, 75);
			this.TbYear.Name = "TbYear";
			this.TbYear.Size = new System.Drawing.Size(116, 26);
			this.TbYear.TabIndex = 2;
			// 
			// BtnPlan
			// 
			this.BtnPlan.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.BtnPlan.Location = new System.Drawing.Point(402, 139);
			this.BtnPlan.Name = "BtnPlan";
			this.BtnPlan.Size = new System.Drawing.Size(155, 37);
			this.BtnPlan.TabIndex = 0;
			this.BtnPlan.Text = "创建工作计划";
			this.BtnPlan.UseVisualStyleBackColor = true;
			this.BtnPlan.Click += new System.EventHandler(this.BtnPlan_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(731, 494);
			this.Controls.Add(this.TbYear);
			this.Controls.Add(this.LblYear);
			this.Controls.Add(this.BtnPlan);
			this.Controls.Add(this.BtnCreateDiay);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button BtnCreateDiay;
		private System.Windows.Forms.Label LblYear;
		private System.Windows.Forms.TextBox TbYear;
		private System.Windows.Forms.Button BtnPlan;
	}
}

