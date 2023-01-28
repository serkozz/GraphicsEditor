namespace GraphicsEditor
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.Clean = new System.Windows.Forms.Button();
            this.LineColor = new System.Windows.Forms.ComboBox();
            this.btCubeSpline = new System.Windows.Forms.Button();
            this.btCross = new System.Windows.Forms.Button();
            this.btMove = new System.Windows.Forms.Button();
            this.btTurn = new System.Windows.Forms.Button();
            this.btScale = new System.Windows.Forms.Button();
            this.btArrow = new System.Windows.Forms.Button();
            this.Intersection = new System.Windows.Forms.Button();
            this.Disjoint = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btRemove = new System.Windows.Forms.Button();
            this.textAngle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.Location = new System.Drawing.Point(183, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(800, 610);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // Clean
            // 
            this.Clean.BackColor = System.Drawing.Color.White;
            this.Clean.Location = new System.Drawing.Point(28, 564);
            this.Clean.Name = "Clean";
            this.Clean.Size = new System.Drawing.Size(125, 35);
            this.Clean.TabIndex = 1;
            this.Clean.Text = "Стереть все";
            this.Clean.UseVisualStyleBackColor = false;
            this.Clean.Click += new System.EventHandler(this.Clean_Click);
            // 
            // LineColor
            // 
            this.LineColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LineColor.FormattingEnabled = true;
            this.LineColor.Items.AddRange(new object[] {
            "Черный",
            "Красный",
            "Зеленый",
            "Синий"});
            this.LineColor.Location = new System.Drawing.Point(28, 496);
            this.LineColor.Name = "LineColor";
            this.LineColor.Size = new System.Drawing.Size(125, 21);
            this.LineColor.TabIndex = 3;
            this.LineColor.Text = "Цвет";
            this.LineColor.SelectionChangeCommitted += new System.EventHandler(this.cbLineColor_SelectionChangeCommitted);
            // 
            // btCubeSpline
            // 
            this.btCubeSpline.BackColor = System.Drawing.Color.White;
            this.btCubeSpline.Location = new System.Drawing.Point(32, 25);
            this.btCubeSpline.Name = "btCubeSpline";
            this.btCubeSpline.Size = new System.Drawing.Size(125, 40);
            this.btCubeSpline.TabIndex = 4;
            this.btCubeSpline.Text = "Кривая Эрмита";
            this.btCubeSpline.UseVisualStyleBackColor = false;
            this.btCubeSpline.Click += new System.EventHandler(this.btCubeSpline_Click);
            // 
            // btCross
            // 
            this.btCross.BackColor = System.Drawing.Color.White;
            this.btCross.Location = new System.Drawing.Point(32, 71);
            this.btCross.Name = "btCross";
            this.btCross.Size = new System.Drawing.Size(125, 40);
            this.btCross.TabIndex = 5;
            this.btCross.Text = "Правильный крест";
            this.btCross.UseVisualStyleBackColor = false;
            this.btCross.Click += new System.EventHandler(this.btCross_Click);
            // 
            // btMove
            // 
            this.btMove.BackColor = System.Drawing.Color.White;
            this.btMove.Location = new System.Drawing.Point(32, 188);
            this.btMove.Name = "btMove";
            this.btMove.Size = new System.Drawing.Size(125, 35);
            this.btMove.TabIndex = 6;
            this.btMove.Text = "Перемещение";
            this.btMove.UseVisualStyleBackColor = false;
            this.btMove.Click += new System.EventHandler(this.btMove_Click);
            // 
            // btTurn
            // 
            this.btTurn.BackColor = System.Drawing.Color.White;
            this.btTurn.Location = new System.Drawing.Point(28, 270);
            this.btTurn.Name = "btTurn";
            this.btTurn.Size = new System.Drawing.Size(70, 35);
            this.btTurn.TabIndex = 7;
            this.btTurn.Text = "Поворот";
            this.btTurn.UseVisualStyleBackColor = false;
            this.btTurn.Click += new System.EventHandler(this.btTurn_Click);
            // 
            // btScale
            // 
            this.btScale.BackColor = System.Drawing.Color.White;
            this.btScale.Location = new System.Drawing.Point(30, 229);
            this.btScale.Name = "btScale";
            this.btScale.Size = new System.Drawing.Size(125, 35);
            this.btScale.TabIndex = 8;
            this.btScale.Text = "Масштабирование";
            this.btScale.UseVisualStyleBackColor = false;
            this.btScale.Click += new System.EventHandler(this.btScale_Click);
            // 
            // btArrow
            // 
            this.btArrow.BackColor = System.Drawing.Color.White;
            this.btArrow.Location = new System.Drawing.Point(32, 117);
            this.btArrow.Name = "btArrow";
            this.btArrow.Size = new System.Drawing.Size(125, 40);
            this.btArrow.TabIndex = 9;
            this.btArrow.Text = "Стрелка";
            this.btArrow.UseVisualStyleBackColor = false;
            this.btArrow.Click += new System.EventHandler(this.btArrow_Click);
            // 
            // Intersection
            // 
            this.Intersection.BackColor = System.Drawing.Color.White;
            this.Intersection.Location = new System.Drawing.Point(28, 338);
            this.Intersection.Name = "Intersection";
            this.Intersection.Size = new System.Drawing.Size(125, 40);
            this.Intersection.TabIndex = 10;
            this.Intersection.Text = "Пересечение";
            this.Intersection.UseVisualStyleBackColor = false;
            this.Intersection.Click += new System.EventHandler(this.Intersection_Click);
            // 
            // Disjoint
            // 
            this.Disjoint.BackColor = System.Drawing.Color.White;
            this.Disjoint.Location = new System.Drawing.Point(28, 384);
            this.Disjoint.Name = "Disjoint";
            this.Disjoint.Size = new System.Drawing.Size(125, 40);
            this.Disjoint.TabIndex = 11;
            this.Disjoint.Text = "Симметрическая разность";
            this.Disjoint.UseVisualStyleBackColor = false;
            this.Disjoint.Click += new System.EventHandler(this.Disjoint_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "            Объекты            ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "            Операции           ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 322);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "                ТМО               ";
            // 
            // btRemove
            // 
            this.btRemove.BackColor = System.Drawing.Color.White;
            this.btRemove.Location = new System.Drawing.Point(28, 523);
            this.btRemove.Name = "btRemove";
            this.btRemove.Size = new System.Drawing.Size(125, 35);
            this.btRemove.TabIndex = 15;
            this.btRemove.Text = "Стереть фигуру";
            this.btRemove.UseVisualStyleBackColor = false;
            this.btRemove.Click += new System.EventHandler(this.btRemove_Click);
            // 
            // textAngle
            // 
            this.textAngle.Location = new System.Drawing.Point(103, 285);
            this.textAngle.Name = "textAngle";
            this.textAngle.Size = new System.Drawing.Size(50, 20);
            this.textAngle.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(121, 270);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Угол";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.YellowGreen;
            this.ClientSize = new System.Drawing.Size(984, 611);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textAngle);
            this.Controls.Add(this.btRemove);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Disjoint);
            this.Controls.Add(this.Intersection);
            this.Controls.Add(this.btArrow);
            this.Controls.Add(this.btScale);
            this.Controls.Add(this.btTurn);
            this.Controls.Add(this.btMove);
            this.Controls.Add(this.btCross);
            this.Controls.Add(this.btCubeSpline);
            this.Controls.Add(this.LineColor);
            this.Controls.Add(this.Clean);
            this.Controls.Add(this.pictureBox);
            this.Name = "Form1";
            this.Text = "Drawing...";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button Clean;
        private System.Windows.Forms.ComboBox LineColor;
        private System.Windows.Forms.Button btCubeSpline;
        private System.Windows.Forms.Button btCross;
        private System.Windows.Forms.Button btMove;
        private System.Windows.Forms.Button btTurn;
        private System.Windows.Forms.Button btScale;
        private System.Windows.Forms.Button btArrow;
        private System.Windows.Forms.Button Intersection;
        private System.Windows.Forms.Button Disjoint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btRemove;
        private System.Windows.Forms.TextBox textAngle;
        private System.Windows.Forms.Label label4;
    }
}

